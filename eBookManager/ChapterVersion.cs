using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace eBookManager {
    public class ChapterVersion : INotifyPropertyChanged {
        private string _contents;
        private bool _contentsLoaded;
        private Chapter _chapter;
        private DateTime _modified;
        private int _id;

        public ChapterVersion() {
            Library.ChapterVersions.Add(this);
        }

        public int Id {
            get { return _id; }
            set {
                if (value == _id) {
                    return;
                }
                _id = value;
                OnPropertyChanged();
            }
        }

        public DateTime Modified {
            get { return _modified; }
            set {
                if (value.Equals(_modified)) {
                    return;
                }
                _modified = value;
                OnPropertyChanged();
                OnPropertyChanged("Path");
            }
        }

        public virtual Chapter Chapter {
            get { return _chapter; }
            set {
                if (Equals(value, _chapter)) {
                    return;
                }
                _chapter = value;
                OnPropertyChanged();
                OnPropertyChanged("Path");
            }
        }

        public string Path {
            get { return Chapter.Path + "\\" + Modified.ToString("u") + ".txt"; }
        }

        public string Contents {
            get {
                if (!_contentsLoaded) {
                    _contents = File.ReadAllText(Path);
                    _contentsLoaded = true;
                }
                return _contents;
            }
            set {
                _contents = value;
                File.WriteAllText(Path, _contents);
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
