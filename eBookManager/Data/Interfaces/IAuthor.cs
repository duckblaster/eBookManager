using System;
using System.Collections.Generic;

namespace eBookManager.Data.Interfaces {
    internal interface IAuthor {
        String Name { get; set; }
        ICollection<IBook> Books { get; set; }
    }
}
