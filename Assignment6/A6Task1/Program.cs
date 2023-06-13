using System.Text;
using System.Collections;
using System;

namespace LibrarySystem
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            /*LibraryTest();*/
            ListTest();
        }

        static void ListTest()
        {
            Func<int, int, string[]> GenerateStringArray = (int start, int end) =>
            {
                string[] array = new string[end-start];
                for(int i = 0; i < array.Length; i++)
                {
                    array[i] = $"Original index {i}, value: {i+start}";
                }
                return array;
            };
            CustomList<string> list0 = new CustomList<string>(GenerateStringArray(0,5));
            CustomList<string> list1 = new CustomList<string>()
                .AddList(new CustomList<string>(GenerateStringArray(100, 105)));

            Console.WriteLine($"List 0: \n{list0}");
            Console.WriteLine($"List 0 count:{list0.Count}");
            Console.WriteLine($"List 1: \n{list1}");
            Console.WriteLine($"List 1 count:{list1.Count}\n\n");


            list0.AddList(list1).AddList(new CustomList<string>());
            Console.WriteLine("After adding List 1 and an empty list to List 0");
            Console.WriteLine($"List 0: \n{list0}");
            Console.WriteLine($"List 0 count:{list0.Count} \n\n");
            int indexToRemove = 5;
            list0.RemoveElementByIndex(indexToRemove);
            Console.WriteLine($"Removing item at index: {indexToRemove}");
            indexToRemove = 0;
            list0.RemoveElementByIndex(indexToRemove);
            Console.WriteLine($"Removing item at index: {indexToRemove}");
            indexToRemove = list0.Count - 1;
            list0.RemoveElementByIndex(list0.Count-1);
            Console.WriteLine($"Removing item at index: {indexToRemove}");

            Console.WriteLine($"List 0: \n{list0}");
            Console.WriteLine($"List 0 count:{list0.Count} \n\n");

            Console.WriteLine("Removing List 1 from List 0");
            list0.RemoveList(list1);

            Console.WriteLine($"List 0: \n{list0}");
            Console.WriteLine($"List 0 count:{list0.Count} \n\n");


            Console.WriteLine("Clearing list 1");
            list1.Clear();
            Console.WriteLine($"List 1: \n{list1}");
            Console.WriteLine($"List 1 count:{list1.Count}\n\n");
            
            Console.WriteLine(list0.GetElement(10, out bool success));
            Console.WriteLine(success?"Element Found":"Element not found");

            CustomList<string> list3 = new CustomList<string>(GenerateStringArray(0, 10));

            Console.WriteLine($"list3[2-4]: \n{list3.GetList(0,10,out bool success0)}");
            Console.WriteLine(success0 ? "Element Found" : "Element not found");

        }

        static void LibraryTest()
        {
            Library library = new Library(
               new Book[] {
                    new Book("Fahrenheit 451", "Ray Bradbury", 1953),
                    new Book("LOTR", "JRR Tolkien", 1937)
                   }
               );

            for (int i = 0; i < 165; i++)
            {
                library.AddBook(new Book($"SomeBook{i}", $"SomeAuthor{i}", i));
            }
            int indexToRemove = 112;
            Console.WriteLine($"Removing index {indexToRemove}");
            library.RemoveBook(indexToRemove);

            foreach (Book book in library)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine($"Physical size: {library.PhysicalSize}");
            Console.WriteLine($"Number of books: {library.Count}");


            Console.WriteLine($"First Book: {library[0]}");
            Console.WriteLine($"Last Book: {library[library.Count - 1]}");

            Book book1 = new Book("Fahrenheit 451", "Ray Bradbury", 1953);
            Book book2 = new Book("Fahrenheit 4511", "Ray Bradbury", 1953);

            Console.WriteLine(library.FindBook(book1));
            Console.WriteLine(library.FindBook(book2));
            Console.WriteLine(library.FindBook(library[library.Count / 2]));

        }
    }

    
}