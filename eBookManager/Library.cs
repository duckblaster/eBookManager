using System.Collections.ObjectModel;

namespace eBookManager {
    public static class Library {
        static Library() {
            Path = "J:\\Projects\\eBookManager\\eBookLibrary\\";
            Books = new ObservableCollection<Book>();
            Authors = new ObservableCollection<Author>();
            Chapters = new ObservableCollection<Chapter>();
            ChapterVersions = new ObservableCollection<ChapterVersion>();
        }

        public static ObservableCollection<Book> Books {
            get;
            private set;
        }
        public static ObservableCollection<Author> Authors {
            get;
            private set;
        }
        public static ObservableCollection<Chapter> Chapters {
            get;
            private set;
        }
        public static ObservableCollection<ChapterVersion> ChapterVersions {
            get;
            private set;
        }
        public static string Path { get; set; }

        public static void SaveChanges() {
            //throw new System.NotImplementedException();
        }
    }
}
