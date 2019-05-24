﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.ViewModel;

namespace Normalization.ViewModel
{
    public class TableViewModel : IViewModel
    {
        public string Name { get; set; }
        public ICollection<string> Attributes { get; set; }
        public ICollection<DependencyViewModel> Dependencies { get; set; }
        public ICollection<ICollection<string>> Keys { get; set; }
        public int? PrimaryId { get; set; }

        public TableViewModel()
        {
            
        }
        public TableViewModel(string name, ICollection<string> attributes, ICollection<DependencyViewModel> dependencies, ICollection<ICollection<string>> keys, int? primaryId)
        {
            Name = name;
            Attributes = attributes;
            Dependencies = dependencies;
            Keys = keys;
            PrimaryId = primaryId;
        }
    }
}
