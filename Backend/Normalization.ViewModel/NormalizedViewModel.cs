using System.Collections.Generic;

namespace Normalization.ViewModel
{
    public class NormalizedViewModel
    {
        public string SchemaName { get; set; }
        public ICollection<ICollection<string>> TableAttributes { get; set; }

        public NormalizedViewModel()
        {
            TableAttributes = new List<ICollection<string>>();
        }
        public NormalizedViewModel
        (
            string name,
            ICollection<ICollection<string>> attributes
        )
        {
            SchemaName = name;
            TableAttributes = attributes;
        }
    }
}
