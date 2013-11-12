using System;
using System.Collections.Generic;

namespace eBookManager.Data.Interfaces {
    internal interface IBook {
        String Title { get; set; }
        String Url { get; set; }
        String Status { get; set; }
        int WordCount { get; set; }
        DateTime Published { get; set; }
        DateTime LastUpdated { get; set; }
        DateTime LastDownloaded { get; set; }
        ICollection<IAuthor> Authors { get; set; }
        byte[] OriginalFile { get; set; }
        ICollection<IChapter> Chapters { get; set; }
    }
}
