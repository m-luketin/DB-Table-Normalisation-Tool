using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.ViewModel;

namespace Normalization.Maps.Algorithm
{
    public static class Algorithm
    {
        public static NormalizedViewModel NormalizeTable(TableViewModel table)
        {
            var normalizedTable = new NormalizedViewModel {SchemaName = table.Name};
            var isAlreadyNormalized = true;

            foreach (var dependencyViewModel in table.Dependencies)
            {
                var areRelationsPartOfKey = table.Keys.Any(key => key.All(partOfKey => dependencyViewModel.From.Any(dependencyElement => partOfKey == dependencyElement)));
                var allKeysPartOfRelationTo = table.Keys.All(key => key.All(partOfKey => dependencyViewModel.To == partOfKey));
                if (areRelationsPartOfKey || allKeysPartOfRelationTo) continue;
                isAlreadyNormalized = false;
                break;
            }

            if (isAlreadyNormalized)
            {
                normalizedTable.TableAttributes.Add(table.Attributes);

                return normalizedTable;
            }
            foreach (var dependencyViewModel in table.Dependencies)
            {
                var decompositionElement = new List<string>();
                decompositionElement.AddRange(dependencyViewModel.From);
                decompositionElement.Add(dependencyViewModel.To);
                if (normalizedTable.TableAttributes.All(tableAttribute =>
                    !decompositionElement.All(element => tableAttribute.Any(ta => ta.Equals(element)))))
                    normalizedTable.TableAttributes.Add(decompositionElement);
            }
            if(normalizedTable.TableAttributes.All(tableAttribute => !table.Keys.First().All(keyAttribute => tableAttribute.Any(ta => ta.Equals(keyAttribute)))))
                normalizedTable.TableAttributes.Add(table.Keys.First());
          
            return normalizedTable;
        }
    }
}
