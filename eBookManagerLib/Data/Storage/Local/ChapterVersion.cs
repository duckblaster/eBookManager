using System;
using System.IO;

namespace eBookManagerLib.Data.Storage.Local {
    public class ChapterVersion : Interfaces.ChapterVersion {
        public ChapterVersion(Interfaces.Chapter chapter, DateTime modified) : base(chapter, modified) {
        }

        public ChapterVersion(Interfaces.Chapter chapter, DateTime modified, string content) : base(chapter, modified, content) {
        }

        public override void LoadItem() {
            _Content = File.ReadAllText(this.LocalChapterVersionFilePath() + ".htm");
            _Summary = File.ReadAllText(this.LocalChapterVersionFilePath() + ".Summary.txt");
            _ContentLoaded = true;
            _SummaryLoaded = true;
        }

        protected override void LoadSummary() {
            _Summary = File.ReadAllText(this.LocalChapterVersionFilePath() + ".Summary.txt");
            _SummaryLoaded = true;
        }

        public override void SaveItem() {
            File.WriteAllText(this.LocalChapterVersionFilePath() + ".htm", _Content);
            File.WriteAllText(this.LocalChapterVersionFilePath() + ".Summary.txt", _Summary);
        }
    }
}

