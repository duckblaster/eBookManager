using System;
using System.Collections.ObjectModel;
using SQLite;

namespace eBookManagerLib.Data.Interfaces {
    [Table("Book")]
    public abstract class Book : StorableItem {
        protected ObservableCollection<Author> _Authors;
        protected ObservableCollection<Chapter> _Chapters;
        protected DateTime _Downloaded;
        protected int _Id;
        protected DateTime _MetadataManualUpdate;
        protected DateTime _MetadataUpdated;
        protected DateTime _Published;
        protected string _Status;
        protected string _Title;
        protected DateTime _Updated;
        protected string _Url;
        protected int _WordCount;

        protected Book() {
            Authors = new ObservableCollection<Author>();
            Chapters = new ObservableCollection<Chapter>();
        }

        [PrimaryKey, AutoIncrement]
        public int Id {
            get {
                return _Id;
            }
            set {
                SetProperty(ref _Id, value);
            }
        }
        
        [Indexed]
        public string Title {
            get {
                return _Title;
            }
            set {
                SetProperty(ref _Title, value);
            }
        }

        [Indexed]
        public string Url {
            get {
                return _Url;
            }
            set {
                SetProperty(ref _Url, value);
            }
        }

        public string Status {
            get {
                return _Status;
            }
            set {
                SetProperty(ref _Url, value);
            }
        }

        [Indexed]
        public int WordCount {
            get {
                return _WordCount;
            }
            set {
                SetProperty(ref _WordCount, value);
            }
        }

        [Indexed]
        public DateTime Published {
            get {
                return _Published;
            }
            set {
                SetProperty(ref _Published, value);
            }
        }

        [Indexed]
        public DateTime Updated {
            get {
                return _Updated;
            }
            set {
                SetProperty(ref _Updated, value);
            }
        }

        public DateTime Downloaded {
            get {
                return _Downloaded;
            }
            set {
                SetProperty(ref _Downloaded, value);
            }
        }

        [Indexed]
        public DateTime MetadataUpdated {
            get {
                return _MetadataUpdated;
            }
            set {
                SetProperty(ref _MetadataUpdated, value);
            }
        }

        public DateTime MetadataManualUpdate {
            get {
                return _MetadataManualUpdate;
            }
            set {
                SetProperty(ref _MetadataManualUpdate, value);
            }
        }

        public ObservableCollection<Author> Authors {
            get {
                return _Authors;
            }
            protected set {
                SetProperty(ref _Authors, value);
            }
        }

        public ObservableCollection<Chapter> Chapters {
            get {
                return _Chapters;
            }
            protected set {
                SetProperty(ref _Chapters, value);
            }
        }

        public override void SaveItem() {
            throw new NotImplementedException();
        }

        public override void LoadItem() {
            throw new NotImplementedException();
        }
    }
}

