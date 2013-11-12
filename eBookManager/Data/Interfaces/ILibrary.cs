using System.Collections.Generic;

namespace eBookManager.Data.Interfaces {
    internal interface ILibrary {
        ICollection<IAuthor> Authors { get; set; }
        ICollection<IBook> Books { get; set; }
    }
}
