using Domain;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LibraryService : ILibraryService
    {
        public readonly ILibraryRepo _libraryRepo;
        public LibraryService(ILibraryRepo libraryRepo)
        {
            _libraryRepo = libraryRepo;
        }
        public async Task<Book> AddBook(Book book) => _libraryRepo.AddBook(book);

        public async Task<Loans>  AddLoan(int userID, List<int> bookIDs)
        {
            return _libraryRepo.AddLoan(userID, bookIDs);
        }

        public async Task<User> AddUser(User user)
        {
            return _libraryRepo.AddUser(user);
        }

        public async Task DeleteUser(string ssn)
        {
            _libraryRepo.DeleteUser(ssn);
        }

        public async Task<Book> getBook(int id)
        {
            return _libraryRepo.getBook(id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return _libraryRepo.GetBooks();
        }

        public async Task<List<Loans>> GetLoans(int userID)
        {
            return _libraryRepo.GetLoans(userID);
        }

        public async Task<User> GetUser(string ssn)
        {
            return _libraryRepo.GetUser(ssn);
        }

        public async Task removeBook(int id)
        {
            _libraryRepo.removeBook(id);
        }

        public async Task ReturnAllBooks(int loanID)
        {
            _libraryRepo.ReturnAllBooks(loanID);
        }

        public async Task<Loans> ReturnBook(int loanID, int bookID)
        {
            return _libraryRepo.ReturnBook(loanID, bookID);
        }

        public async Task<User> UpdateUser(User user)
        {
            return _libraryRepo.UpdateUser(user);
        }
    }
}
