using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfModule25Hw.Repository;
using SfModule25Hw.AppContext;
using SfModule25Hw.Models;
using Microsoft.EntityFrameworkCore;


namespace SfModule25Hw.Repository
{
    public class BookRepository : IRepository<Book>, IBookRepository, IBookRepositoryExtension
    {
        private AppContext.AppContext DB;

        public BookRepository(AppContext.AppContext appContext)
        {
            DB = appContext;
        }
        public void CreateNewRecord(Book record)
        {
            DB.Books.Add(record);
            DB.SaveChanges();
        }

        public void DeleteById(int id)
        {
            DB.Books.Remove(DB.Books.FirstOrDefault(u => u.Id == id));
            DB.SaveChanges();
        }

        public List<Book> GetAll()
        {
            try
            {
                return DB.Books.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Book GetById(int id)
        {
            return DB.Books.FirstOrDefault(u => u.Id == id);
        }

        public void LendBook(Book book, User user)
        {
            user.Books.Add(book);
            DB.SaveChanges();
        }
        public void ReturnBook(Book book, User user)
        {
            user.Books.Remove(book);
            DB.SaveChanges();
        }

        public void UpdateAuthorById(int id, string author)
        {
            var book = GetById(id);
            book.Author = author;
            DB.SaveChanges();
        }

        public void UpdateGenreById(int id, string genre)
        {
            var book = GetById(id);
            book.Genre = genre;
            DB.SaveChanges();
        }

        public void UpdateReleaseYearById(int id, int year)
        {
            var book = GetById(id);
            book.ReleaseYear = year;
            DB.SaveChanges();
        }

        public int BookCountByUser(User user)
        {
            return user.Books.Count();
        }

        public bool BookExist(string name, string autor)
        {
            return DB.Books.Where(b => b.Name == name & b.Author == autor).Any();
        }

        public bool BookIssuedToUser(User user, Book book)
        {
            return user.Books.Contains(book);
        }

        public List<Book> GetBooksByGenreAndDate(string genre, int yearAfter, int yearBefore)
        {
            return DB.Books.Where(b => b.ReleaseYear > yearAfter & b.ReleaseYear < yearBefore & b.Genre == genre).ToList();
        }

        public int GetBooksNumberByAutorInLibrary(string autor)
        {
            return DB.Books.Where(b => b.Equals(autor)).ToList().Count;
        }

        public int GetBooksNumberByGenreInLibrary(string genre)
        {
            return DB.Books.Where(b => b.Equals(genre)).ToList().Count;
        }

        public List<Book> GetBooksSortedByAlphabet()
        {
            return DB.Books.OrderBy(p => p.Name).ToList();
        }

        public List<Book> GetBooksSortedByReleaseYear()
        {
            return DB.Books.OrderByDescending(p => p.ReleaseYear).ToList();
        }

        public Book GetLastReleasedBook()
        {
            return DB.Books.OrderBy(p => p.ReleaseYear).First();
        }
    }

    public interface IBookRepository
    {
        void UpdateReleaseYearById(int id, int year);
        void LendBook(Book book, User user);
        void ReturnBook(Book book, User user);
        void UpdateGenreById(int id, string genre);
        void UpdateAuthorById(int id, string author);
    }

    public interface IBookRepositoryExtension
    {
        List<Book> GetBooksByGenreAndDate(string Genre, int yearAfter, int yearBefore);
        int GetBooksNumberByAutorInLibrary(string autor);
        int GetBooksNumberByGenreInLibrary(string genre);
        Book GetLastReleasedBook();
        List<Book> GetBooksSortedByAlphabet();
        List<Book> GetBooksSortedByReleaseYear();
        int BookCountByUser(User user);
        bool BookExist(string name, string autor);
        bool BookIssuedToUser(User user, Book book);
    }


}
