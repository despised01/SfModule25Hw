using SfModule25Hw.Models;
using SfModule25Hw.Repository;

namespace SfModule25Hw
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new SfModule25Hw.AppContext.AppContext())
            {
                var UserRepos = new UserRepository(db);
                var BookRepos = new BookRepository(db);


                var user1 = new User { Name = "Alice", Email = "User1" };
                var user2 = new User { Name = "Bob", Email = "Use2r" };
                var user3 = new User { Name = "Bruce", Email = "User3" };

                var book1 = new Book { Name = "Алиса в стране наркоманов" };
                var book2 = new Book { Name = "book2" };
                var book3 = new Book { Name = "book3" };

                user2.Books.Add(book2);
       


                BookRepos.CreateNewRecord(book2);
                BookRepos.CreateNewRecord(book3);
                BookRepos.CreateNewRecord(book1);

                UserRepos.CreateNewRecord(user3);
                UserRepos.CreateNewRecord(user1);
                UserRepos.CreateNewRecord(user2);



                db.SaveChanges();

                BookRepos.LendBook(book1, user2);
                BookRepos.ReturnBook(book2, user2);
                
            }
        }
    }
}