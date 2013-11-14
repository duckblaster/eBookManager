using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace eBookManagerLib.Data.Interfaces {
    public abstract class Chapter : StorableItem {
        protected string _Title;
        protected int _Number;
        protected ObservableCollection<ChapterVersion> _ChapterVersions;
        protected bool _ChapterVersionsLoaded;
        protected Book _Book;
        protected string _Summary;

        protected Chapter(Book book, int number, string title) {
            _Book = book;
            _Number = number;
            _Title = title;
            _ChapterVersions = new ObservableCollection<ChapterVersion>();
            _ChapterVersions.CollectionChanged += OnChapterVersionsCollectionChanged;
            _ChapterVersionsLoaded = false;
        }

        protected Chapter(Book book, int number, string title, IEnumerable<ChapterVersion> chapterVersions) {
            _Book = book;
            _Number = number;
            _Title = title;
            _ChapterVersions = new ObservableCollection<ChapterVersion>(chapterVersions);
            _ChapterVersions.CollectionChanged += OnChapterVersionsCollectionChanged;
            _ChapterVersionsLoaded = true;
        }

        public string Title {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        public int Number {
            get { return _Number; }
            set {
                SetProperty(ref _Number, value);
            }
        }

        public string Summary {
            get { return _Summary; }
            set {
                SetProperty(ref _Summary, value);
            }
        }

        

        public ObservableCollection<ChapterVersion> ChapterVersions {
            get {
                if(!_ChapterVersionsLoaded) {
                    LoadItem();
                }
                return _ChapterVersions;
            }
            set {
                SetProperty(ref _ChapterVersions, value, (oldValue, newValue) => {
                    if (oldValue != null) {
                        oldValue.CollectionChanged -= OnChapterVersionsCollectionChanged;
                        foreach (var chapterVersion in oldValue) {
                            chapterVersion.Chapter = null;
                        }
                    }
                    if (newValue != null) {
                        foreach(var chapterVersion in newValue) {
                            chapterVersion.Chapter = this;
                        }
                        newValue.CollectionChanged += OnChapterVersionsCollectionChanged;
                    }
                });
            }
        }

        protected virtual void OnChapterVersionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            foreach(var chapterVersion in e.OldItems) {
                ((ChapterVersion)chapterVersion).Chapter = null;
            }
            foreach(var chapterVersion in e.NewItems) {
                ((ChapterVersion)chapterVersion).Chapter = this;
            }
        }

        public Book Book {
            get {
                return _Book;
            }
            set {
                SetProperty(ref _Book, value);
            }
        }

        public override void SaveItem() {
            foreach (var chapterVersion in ChapterVersions) {
                chapterVersion.SaveItem();
            }
        }

        public override void LoadItem() {
            _ChapterVersions.CollectionChanged += OnChapterVersionsCollectionChanged;
            _ChapterVersionsLoaded = true;
        }
    }
}

