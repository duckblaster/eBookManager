using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eBookManagerLib.Data.Storage.Local {
    public class Chapter : Interfaces.Chapter {
        public Chapter(Interfaces.Book book, int number, string title) : base(book, number, title) {
        }

        public Chapter(Interfaces.Book book, int number, string title,
                       IEnumerable<Interfaces.ChapterVersion> chapterVersions)
            : base(book, number, title, chapterVersions) {
        }

        public override void SaveItem() {
            base.SaveItem();
            File.WriteAllLines(this.LocalChapterFilePath("Versions.txt"),
                               ChapterVersions.Select(c => c.Modified.ToUnixTime() + " " + c.Modified.ToString("u")));
            File.WriteAllText(this.LocalChapterFilePath("Summary.txt"), Summary);
        }

        public override void LoadItem() {
            foreach (string line in File.ReadAllLines(this.LocalChapterFilePath("Versions.txt"))) {
                try {
                    var chapterVersion = new ChapterVersion(this, new UnixTime(line.Split(new[] {' '}, 2)[0]));
                    ChapterVersions.Add(chapterVersion);
                } catch {
                }
            }
            base.LoadItem();
            _Summary = File.ReadAllText(this.LocalChapterFilePath("Summary.txt"));
        }
    }
}
