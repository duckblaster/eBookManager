using System;

namespace eBookManager.Data.Interfaces {
    internal interface IChapterVersion {
        IChapter Chapter { get; set; }
        DateTime Modified { get; set; }
        String Contents { get; set; }
    }
}
