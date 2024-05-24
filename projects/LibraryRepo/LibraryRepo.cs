

using Domain;

namespace Repo
{
    public class LibraryRepo : ILibraryRepo
    {
        public readonly LibraryContext _context;
        public LibraryRepo(LibraryContext context)
        {
            _context = context;
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Loans AddLoan(int userID, List<int> bookIDs)
        {
            List<Book> books = _context.Books.Where(b => bookIDs.Contains(b.Id)).ToList();
            User user = _context.Users.FirstOrDefault(u => u.Id == userID);
            Loans loan = new Loans
            {
                User = user,
                Books = books,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14)
            };
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return loan;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(string ssn)
        {
            _context.Users.Remove(_context.Users.FirstOrDefault(u => u.ssn == ssn));
        }

        public Book getBook(int id)
        {
            Book result =  _context.Books.FirstOrDefault(b => b.Id == id);
            return result;
        } 

        public List<Book> GetBooks()
        {
            List<Book> result = _context.Books.ToList();
            return result;
        }

        public List<Loans> GetLoans(int userID)
        {
            List<Loans> result = _context.Loans.Where(l => l.User.Id == userID).ToList();
            return result;
        }

        public User GetUser(string ssn)
        {
            return _context.Users.FirstOrDefault(u => u.ssn == ssn);
        }

        public void removeBook(int id)
        {
            _context.Books.Remove(_context.Books.FirstOrDefault(b => b.Id == id));
        }

        public void ReturnAllBooks(int loanID)
        {
            _context.Loans.Remove(_context.Loans.FirstOrDefault(l => l.Id == loanID));
            _context.SaveChanges();
        }

        public Loans ReturnBook(int loanID, int bookID)
        {
            _context.Loans.FirstOrDefault(l => l.Id == loanID).Books.Remove(_context.Books.FirstOrDefault(b => b.Id == bookID));
            _context.SaveChanges();
            return _context.Loans.FirstOrDefault(l => l.Id == loanID);
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
