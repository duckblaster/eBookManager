using System;
using System.ComponentModel;

namespace eBookManagerLib.Data.Interfaces {
    public abstract class ChapterVersion : NotifyPropertyChanged {
        protected string _content;
        protected bool _contentLoaded;
        protected Chapter _chapter;
        protected DateTime _modified;

        protected ChapterVersion() {
        }

        public abstract void LoadContent();

        public abstract void SaveContent();

        public DateTime Modified {
            get { return _modified; }
            set { SetProperty(ref _modified, value); }
        }

        public virtual Chapter Chapter {
            get { return _chapter; }
            set { SetProperty(ref _chapter, value); }
        }

        public string Content {
            get {
                if (!_contentLoaded) {
                    LoadContent();
                }
                return _content;
            }
            set {
                _content = value;
                SetProperty(ref _content, value);
                SaveContent();
            }
        }
    }
}

