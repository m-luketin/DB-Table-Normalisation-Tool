using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.ViewModel;

namespace Normalization.Maps.Algorithm
{
    public class Algorithm
    {
        public NormalizedViewModel NormalizeTable(TableViewModel table)
        {
            var normalizedTable = new NormalizedViewModel();
            var decompositionElement = new List<string>();
            
            foreach (var dependencyViewModel in table.Dependencies)
            {
                decompositionElement.AddRange(dependencyViewModel.From);
                decompositionElement.Add(dependencyViewModel.To);
                normalizedTable.TableAttributes.Add(decompositionElement);
                decompositionElement.Clear();
            }

            decompositionElement.AddRange(table.Keys.First());
            normalizedTable.TableAttributes.Add(decompositionElement);
            decompositionElement.Clear();

            normalizedTable.TableAttributes = normalizedTable.TableAttributes.Distinct().ToList();


            return normalizedTable;
        }
    }
}
