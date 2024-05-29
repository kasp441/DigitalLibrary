using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILibraryService
    {
        //user related service
        Task<User> AddUser(User user);
        Task<User> GetUser(string ssn);

        Task<User> UpdateUser(User user);

        Task DeleteUser(string ssn);

        //book related service
        Task<Book> AddBook(Book book);
        Task<List<Book>> GetBooks();

        Task<Book> getBook(int id);

        Task removeBook(int id);

        //loan related service
        Task<Loans> AddLoan(int userID, List<int> bookIDs);

        Task<Loans> ReturnBook(int loanID, int bookID);

        Task<List<Loans>> GetLoans(int userID);

        Task ReturnAllBooks(int loanID);

    }
}
