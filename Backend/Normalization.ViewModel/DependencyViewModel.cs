using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Normalization.ViewModel;

namespace Normalization.Maps
{
    public class DependencyViewModel : IViewModel
    {
        public ICollection<string> From { get; set; }
        public string To { get; set; }
        public int? PrimaryId { get; set; }
    }
}
