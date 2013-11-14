using System.Globalization;
using System.IO;

namespace eBookManagerLib.Data.Storage.Local {
    public static class Extentions {
        private static string LibraryPath(Interfaces.Library library) {
            return library.Path;
        }
        private static string BookPath(Interfaces.Book book) {
            return /*(book.Id % 10).ToString() + Path.DirectorySeparatorChar + */
                string.Format("{0:D5} - {1}", book.Id, book.Title.Remove(100));
        }
        private static string ChapterPath(Interfaces.Chapter chapter) {
            return chapter.Number.ToString(CultureInfo.InvariantCulture);
        }
        private static string ChapterVersionPath(Interfaces.ChapterVersion chapterVersion) {
            return chapterVersion.Modified.ToString("u");
        }
        public static string LocalLibraryFilePath(this Interfaces.Library library, string path = "") {
            return LibraryPath(library) + Path.DirectorySeparatorChar + path;
        }
        public static string LocalBookFilePath(this Interfaces.Book book, string path = "") {
            return LocalLibraryFilePath(book.Library, BookPath(book) + Path.DirectorySeparatorChar + path);
        }
        public static string LocalChapterFilePath(this Interfaces.Chapter chapter, string path = "") {
            return LocalBookFilePath(chapter.Book, ChapterPath(chapter) + Path.DirectorySeparatorChar + path);
        }
        public static string LocalChapterVersionFilePath(this Interfaces.ChapterVersion chapterVersion, string path = "") {
            return LocalChapterFilePath(chapterVersion.Chapter, ChapterVersionPath(chapterVersion) + Path.DirectorySeparatorChar + path);
        }
    }
}
