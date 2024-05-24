using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface ILibraryRepo
    {
        //user related service
        User AddUser(User user);
        User GetUser(string ssn);

        User UpdateUser(User user);

        void DeleteUser(string ssn);

        //book related service
        Book AddBook(Book book);
        List<Book> GetBooks();

        Book getBook(int id);

        void removeBook(int id);

        //loan related service
        Loans AddLoan(int userID, List<int> bookIDs);

        Loans ReturnBook(int loanID, int bookID);

        List<Loans> GetLoans(int userID);

        void ReturnAllBooks(int loanID);
    }
}
