using System.Linq;

namespace LibraryManagementSystem
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true;
        }
    }
    class Library
    {
        List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' by {book.Author} added to the library.");
        }

        public void SearchBook(string Search)
        {
            List<Book> results = new List<Book>();

            for (int i = 0;i< books.Count; i++)
            {
                if (books[i].Title.ToLower().Contains(Search.ToLower())|| books[i].Author.ToLower().Contains(Search.ToLower()))
                {
                   results.Add(books[i]);
                }
            }
            
            if(results.Count == 0)
            {
                Console.WriteLine("No books found matching your search.");
            }
            else
            {
                
                for(int i = 0;i< results.Count; i++)
                {
                    Console.WriteLine($"- {results[i].Title} by {results[i].Author}");
                   
                }
 
            }

            
        }
        public void BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower().Contains(title.ToLower()))
                {
                    if (books[i].Availability)
                    {
                        books[i].Availability = false;
                        Console.WriteLine($"{books[i].Title} has been borrowed.");
                    }
                    else
                    {
                        Console.WriteLine($"'{books[i].Title}' is currently not available.");
                    }
                    return;
                }
            }
            Console.WriteLine("The book is not available in the library.");
        }

        public void ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower().Contains(title.ToLower()))
                {
                    if (!books[i].Availability)
                    {
                        books[i].Availability = true;
                        
                        Console.WriteLine($"You returned '{books[i].Title}'.");
                    }
                    else
                    {
                        Console.WriteLine($"'{books[i].Title}' was not borrowed.");
                    }
                    return;
                }
            }
            Console.WriteLine("Book not found.");
        }

    }



        internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
