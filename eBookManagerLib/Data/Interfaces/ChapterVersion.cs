using System;

namespace eBookManagerLib.Data.Interfaces {
    public abstract class ChapterVersion : StorableItem {
        protected string _Content;
        protected bool _ContentLoaded;
        protected Chapter _Chapter;
        protected DateTime _Modified;
        protected string _Summary;
        protected bool _SummaryLoaded;

        protected ChapterVersion(Chapter chapter, DateTime modified) {
            _Chapter = chapter;
            _Modified = modified;
        }

        protected ChapterVersion(Chapter chapter, DateTime modified, string content) {
            _Chapter = chapter;
            _Modified = modified;
            _Content = content;
            _ContentLoaded = true;
        }

        protected ChapterVersion(Chapter chapter, string summary, DateTime modified) {
            _Chapter = chapter;
            _Summary = summary;
            _SummaryLoaded = true;
            _Modified = modified;
        }

        protected ChapterVersion(Chapter chapter, string summary, DateTime modified, string content) {
            _Chapter = chapter;
            _Summary = summary;
            _SummaryLoaded = true;
            _Modified = modified;
            _Content = content;
            _ContentLoaded = true;
        }

        public DateTime Modified {
            get { return _Modified; }
            set { SetProperty(ref _Modified, value); }
        }

        public virtual Chapter Chapter {
            get { return _Chapter; }
            set { SetProperty(ref _Chapter, value); }
        }

        public string Content {
            get {
                if (!_ContentLoaded) {
                    LoadItem();
                }
                return _Content;
            }
            set {
                SetProperty(ref _Content, value);
                SaveItem();
            }
        }

        public string Summary {
            get {
                if (!_SummaryLoaded) {
                    LoadSummary();
                }
                return _Summary;
            }
            set {
                SetProperty(ref _Summary, value);
            }
        }

        protected abstract void LoadSummary();

        public Book Book {
            get {
                return Chapter.Book;
            }
        }

        public override void SaveItem() {
        }
    }
}

