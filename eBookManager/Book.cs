using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

using eBookManager.Annotations;

namespace eBookManager {
    public class Book : INotifyPropertyChanged {
        private ObservableCollection<Author> _authors;
        private ObservableCollection<Chapter> _chapters;
        private DateTime _downloaded;
        private int _id;
        private DateTime _metadataManualUpdate;
        private DateTime _metadataUpdated;
        private DateTime _published;
        private string _status;
        private string _title;
        private DateTime _updated;
        private string _url;
        private int _wordCount;

        public Book() {
            Authors = new ObservableCollection<Author>();
            Chapters = new ObservableCollection<Chapter>();
            Library.Books.Add(this);

            /*Title = "New Book...";
            Published = DateTime.Now;
            Updated = DateTime.Now;
            Downloaded = DateTime.Now;
            MetadataUpdated = DateTime.Now;
            MetadataManualUpdate = DateTime.Now;*/
        }
        #region Properties

        [Key]
        public int Id {
            get {
                return _id;
            }
            set {
                if(value == _id) {
                    return;
                }
                _id = value;
                OnPropertyChanged();
                OnPropertyChanged("Path");
            }
        }

        [Required]
        public string Title {
            get {
                return _title;
            }
            set {
                if(value == _title) {
                    return;
                }
                _title = value;
                OnPropertyChanged();
                OnPropertyChanged("Path");
            }
        }

        public string Url {
            get {
                return _url;
            }
            set {
                if(value == _url) {
                    return;
                }
                _url = value;
                OnPropertyChanged();
            }
        }

        public string Status {
            get {
                return _status;
            }
            set {
                if(value == _status) {
                    return;
                }
                _status = value;
                OnPropertyChanged();
            }
        }

        public int WordCount {
            get {
                return _wordCount;
            }
            set {
                if(value == _wordCount) {
                    return;
                }
                _wordCount = value;
                OnPropertyChanged();
            }
        }

        public DateTime Published {
            get {
                return _published;
            }
            set {
                if(value.Equals(_published)) {
                    return;
                }
                _published = value;
                OnPropertyChanged();
            }
        }

        public DateTime Updated {
            get {
                return _updated;
            }
            set {
                if(value.Equals(_updated)) {
                    return;
                }
                _updated = value;
                OnPropertyChanged();
            }
        }

        public DateTime Downloaded {
            get {
                return _downloaded;
            }
            set {
                if(value.Equals(_downloaded)) {
                    return;
                }
                _downloaded = value;
                OnPropertyChanged();
            }
        }

        public DateTime MetadataUpdated {
            get {
                return _metadataUpdated;
            }
            set {
                if(value.Equals(_metadataUpdated)) {
                    return;
                }
                _metadataUpdated = value;
                OnPropertyChanged();
            }
        }

        public DateTime MetadataManualUpdate {
            get {
                return _metadataManualUpdate;
            }
            set {
                if(value.Equals(_metadataManualUpdate)) {
                    return;
                }
                _metadataManualUpdate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ObservableCollection<Author> Authors {
            get { return _authors; }
            private set {
                if (Equals(value, _authors)) {
                    return;
                }
                _authors = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Chapter> Chapters {
            get { return _chapters; }
            private set {
                if (Equals(value, _chapters)) {
                    return;
                }
                _chapters = value;
                OnPropertyChanged();
            }
        }

        public string Path {
            get { return Library.Path + "\\" + Title + " (" + Id + ")\\"; }
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
