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

            foreach (var dependencyViewModel in table.Dependencies)
            {
                var decompositionElement = new List<string>();
                decompositionElement.AddRange(dependencyViewModel.From);
                decompositionElement.Add(dependencyViewModel.To);
                normalizedTable.TableAttributes.Add(decompositionElement);
            }
            normalizedTable.TableAttributes.Add(table.Keys.First());

            normalizedTable.TableAttributes = normalizedTable.TableAttributes.Distinct().ToList();


            return normalizedTable;
        }
    }
}
