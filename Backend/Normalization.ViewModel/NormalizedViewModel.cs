using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.ViewModel
{
    public class NormalizedViewModel
    {
        public string SchemaName { get; set; }
        public ICollection<ICollection<string>> TableAttributes { get; set; }

        public NormalizedViewModel()
        {

        }
        public NormalizedViewModel(string name, ICollection<ICollection<string>> attributes)
        {
            SchemaName = name;
            TableAttributes = attributes;
        }
    }
}
