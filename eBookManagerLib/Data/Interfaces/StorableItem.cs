namespace eBookManagerLib.Data.Interfaces {
    public abstract class StorableItem : NotifyPropertyChanged {
        public Library Library { get; set; }

        public abstract void SaveItem();
        public abstract void LoadItem();
    }
}
