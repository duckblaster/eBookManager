using System.Collections.ObjectModel;

namespace eBookManagerLib.Data.Interfaces {
    public abstract class Library {
        protected Library() {
        }

        public ObservableCollection<Book> Books {
            get; protected set;
        }
        public ObservableCollection<Author> Authors {
            get;
            protected set;
        }

        public virtual string Path {
            get;
            set;
        }
    }
}

