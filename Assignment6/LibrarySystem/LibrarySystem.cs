using System.Text;
using System.Collections;

namespace LibrarySystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {

        }
    }

    public class Book
    {
        private string _title;
        private string _author;
        private int _releaseYear;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public int ReleaseYear
        {
            get; set;
        }

        public Book()
        {
            this.Title = default(string);
            this.Author = default(string);
            this.ReleaseYear = default(int);
        }
        public Book(string title, string author, int releaseYear)
        {
            this.Title = title;
            this.Author = author;
            this.ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}, {ReleaseYear}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Book)) return false;
            Book tempBook = (Book)obj;
            return this.Author == tempBook.Author &&
                this.Title == tempBook.Title && 
                this.ReleaseYear == tempBook.ReleaseYear;
        }

    }

    public class Library : IEnumerable<Book>
    {
        private CustomList<Book> _books;

        public Book this[int index]
        {
            get
            {
                return _books[index];
            }
            set
            {
                _books[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _books.Count;
            }
        }

        public Library(Book[] books)
        {
            _books = new CustomList<Book>(books);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Book book in this)
            {
                stringBuilder.Append(book + "\n");
            }
            return stringBuilder.ToString();
        }

        public void AddBook(Book book)
        {
            _books.AddElement(book);
        }

        public void RemoveBook(int index)
        {
            _books.RemoveElementByIndex(index);
        }

        public int FindBook(Book book)
        {
            if(book == null) return -1;

            return _books.FindIndex(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return ((IEnumerable<Book>)_books).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_books).GetEnumerator();
        }

        public int PhysicalSize  //დებაგინგისთვის
        {
            get
            {
                return _books.PhysicalSize;
            }
        }

        
    }



    public class CustomList<T> : IEnumerable<T>
    {
        private T[] _arr;
        private int _lastIndex;

        public int PhysicalSize
        {
            get
            {
                return _arr.Length;
            }
        }

        public int Count
        {
            get
            {
                return _lastIndex + 1;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index <= _lastIndex)
                    return _arr[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index <= _lastIndex)
                {
                    _arr[index] = value;
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }

        private T[] InternalCutArray
        {
            get
            {
                T[] tempArr = new T[_lastIndex + 1];
                Array.Copy(_arr, tempArr, tempArr.Length);
                return tempArr;
            }
        }

        public CustomList(T[] arr)
        {
            _arr = arr;
            _lastIndex = arr.Length - 1;
        }

        public CustomList()
        {
            this.Clear();
        }

        public void AddElement(T item)
        {
            if (_lastIndex + 1 >= _arr.Length)
                Resize();
            _arr[++_lastIndex] = item;
        }

        public CustomList<T> AddList(CustomList<T> otherList)
        {
            T[] tempArr = otherList.InternalCutArray;
            while (_lastIndex + otherList.Count >= _arr.Length)
            {
                double resizeBy = (otherList.Count + 1) / (this.Count > 0 ? this.Count : 1);
                Resize(Math.Max(1.5, resizeBy));
            }
            tempArr.CopyTo(_arr, _lastIndex + 1);
            _lastIndex += otherList.Count;

            return this;
        }

        public void RemoveElementByIndex(int index)
        {
            if (index > _lastIndex)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                Array.Copy(_arr, 1, _arr, 0, _arr.Length - 1);
            }
            else if (index < _lastIndex)
            {
                Array.Copy(_arr, index + 1, _arr, index, _lastIndex - index);
            }
            _lastIndex--;
        }

        public bool RemoveElement(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            else
            {
                try
                {
                    this.RemoveElementByIndex(FindIndex(item));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void RemoveList(CustomList<T> listToRemove)
        {
            foreach(T item in listToRemove) 
            {
                this.RemoveElement(item);
            }
        }

        public int FindIndex(T item)
        {
            if(item == null)
                return -1;

            for(int i = 0; i <= _lastIndex; i++)
            {
                if(item.Equals(_arr[i]))
                    return i;
            }
            return -1;
        }

        public T Find(T itemToFind)
        {
            if (itemToFind == null)
                throw new ArgumentNullException();

            foreach(T item in this) 
            {
                if(itemToFind.Equals(item))
                    return item;
            }
            return default(T);
        }
        private void Resize(double rate = 1.5)
        {
            int newSize = (int)Math.Ceiling(_arr.Length + 1 * rate);
            T[] newArr = new T[newSize];
            _arr.CopyTo(newArr, 0);
            _arr = newArr;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(T item in this)
            {
                sb.Append(item.ToString() + "\n");
            }
            return sb.ToString();
        }
        public void Clear()
        {
            _arr = new T[0];
            _lastIndex = -1;
        }


        public T GetElement(int index, out bool success)
        {
            success = true;
            try
            {
                return this[index];
            }
            catch
            {
                success = false;
                return default(T);
            }
        }

        public CustomList<T> GetList(int startIndex, int length, out bool success)
        {
            if(startIndex >= 0 && startIndex <= _lastIndex && length <= this.Count)
            {
                success = true;
                try
                {
                    T[] values = new T[length];
                    Array.Copy(_arr, startIndex, values, 0, length);
                    return new CustomList<T>(values);
                }
                catch
                {
                    success = false;
                    return default;
                }
            }
            throw new ArgumentOutOfRangeException();

        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)this.InternalCutArray).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.InternalCutArray.GetEnumerator();
        }
    }
}