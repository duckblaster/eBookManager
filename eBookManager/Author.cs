using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace eBookManager {
    public class Author : INotifyPropertyChanged {
        private int _id;
        private ObservableCollection<Book> _books;
        private string _name;

        public Author() {
            Books = new ObservableCollection<Book>();
            Library.Authors.Add(this);
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

        public string Name {
            get { return _name; }
            set {
                if (value == _name) {
                    return;
                }
                _name = value;
                OnPropertyChanged();
            }
        }

        public virtual ObservableCollection<Book> Books
        {
            get { return _books; }
            set {
                if (Equals(value, _books)) {
                    return;
                }
                _books = value;
                OnPropertyChanged();
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
