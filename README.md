# Digital Library

## main feature: Book Lending and Returning

* Create a database schema that includes tables for Users, Books, and Loans.
* The Users table will store information about library members.
* The Books table will store information about all the books available in the library.
* The Loans table will store information about which books are currently loaned out to which users, and when they are due back.
* The API should allow for creating new users, adding new books, loaning books to users, returning books, and checking the current status of a book (available, loaned out, overdue).

## extended feature: Book Reservations

* This feature will require a schema migration to add a new table, Reservations.
* The Reservations table will store information about which books are reserved by which users, and in what order.
* Additionally, users should be able to see their position in the reservation queue for a particular book.
