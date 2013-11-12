using System;
using eBookManagerLib.Data.Interfaces;
using System.IO;

namespace eBookManagerLib.Data.Storage.FileTree {
    public class ChapterVersion : Interfaces.ChapterVersion {
        public ChapterVersion() {
        }

        public override void LoadContent() {
            _content = File.ReadAllText(this.FileTreeGetPath());
            _contentLoaded = true;
        }

        public override void SaveContent() {
            File.WriteAllText(this.FileTreeGetPath(), _content);
        }
    }
}

