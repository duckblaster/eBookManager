using System.Collections.Generic;
using System.IO;

namespace eBookManager.Data.Interfaces {
    internal interface IChapter {
        int ChapterNum { get; set; }
        Stream Contents { get; set; }
        IBook Book { get; set; }
        IChapterVersion CurrentVersion { get; set; }
        ICollection<IChapterVersion> Versions { get; set; }
    }
}
