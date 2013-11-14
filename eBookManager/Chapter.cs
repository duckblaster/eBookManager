using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace eBookManager {
    public class Chapter : INotifyPropertyChanged {
        private int _id;
        private string _title;
        private int _number;
        private ObservableCollection<ChapterVersion> _chapterVersions;
        private Book _book;

        public Chapter() {
            ChapterVersions = new ObservableCollection<ChapterVersion>();
            Library.Chapters.Add(this);
        }

        [Key]
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

        public string Title {
            get { return _title; }
            set {
                if (value == _title) {
                    return;
                }
                _title = value;
                OnPropertyChanged();
            }
        }

        public int Number {
            get { return _number; }
            set {
                if (value == _number) {
                    return;
                }
                _number = value;
                OnPropertyChanged();
                OnPropertyChanged("Path");
            }
        }

        public virtual ObservableCollection<ChapterVersion> ChapterVersions {
            get { return _chapterVersions; }
            set {
                if (Equals(value, _chapterVersions)) {
                    return;
                }
                _chapterVersions = value;
                OnPropertyChanged();
            }
        }

        public virtual Book Book {
            get { return _book; }
            set {
                if (Equals(value, _book)) {
                    return;
                }
                _book = value;
                OnPropertyChanged();
                OnPropertyChanged("Path");
            }
        }

        public string Path {
            get { return Book.Path + "\\" + Number + "\\"; }
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
