using System.Collections.Generic;

namespace Normalization.ViewModel
{
    public class DependencyViewModel : IViewModel
    {
        public int? PrimaryId { get; set; }
        public ICollection<string> From { get; set; }
        public string To { get; set; }

        public DependencyViewModel()
        {
           
        }

        public DependencyViewModel
        (
            int? primaryId, 
            ICollection<string> @from, 
            string to
        )
        {
            PrimaryId = primaryId;
            From = @from;
            To = to;
        }
    }
}
