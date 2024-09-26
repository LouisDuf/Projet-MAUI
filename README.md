# PocketBook - Louis DUFOUR

## Informations projet
Application développer sous android API 28 pour ma part.

## Modèle

```mermaid
classDiagram
direction LR
class Book {
    +Id : string
    +Title : string
    +Publishers : List~string~
    +PublishDate : DateTime
    +ISBN13 : string
    +Series : List~string~
    +NbPages : int
    +Format : string
    +ImageSmall : string
    +ImageMedium : string
    +ImageLarge : string
}

class Languages {
    <<enum>>
    Unknown,
    French,
}

class Work {
    +Id : string
    +Description : string
    +Title : string
    +Subjects : List~string~
}

class Contributor {
    +Name : string
    +Role : string
}

class Author {
    +Id : string
    +Name : string
    +ImageSmall : string
    +ImageMedium : string
    +ImageLarge : string
    +Bio : string
    +AlternateNames : List~string~
    +BirthDate : DateTime?
    +DeathDate : DateTime?
}

class Link {
    +Title : string
    +Url : string
}

class Ratings {
    +Average : float
    +Count : int
}

Book --> "1" Languages  : Language
Book --> "*" Contributor : Contributors
Author --> "*" Link : Links
Work --> "*" Author : Authors
Work --> "1" Ratings : Ratings
Book --> "*" Author : Authors
Book --> "*" Work : Works

class Status {
    <<enum>>
    Unknown,
    Finished,
    Reading,
    NotRead,
    ToBeRead
}

class Contact{
    +string Id;
    +string FirstName;
    +string LastName;
}
```  

## Services & Interfaces
```mermaid
classDiagram
direction LR
Book --> "1" Languages  : Language
Book --> "*" Contributor : Contributors
Author --> "*" Link : Links
Work --> "1" Ratings : Ratings
Work --> "*" Author : Authors
Book --> "*" Work : Works
Book --> "*" Author : Authors

class IUserLibraryManager {
    <<interface>>
    +AddBook(Book book) : Task<Book>
    +AddBook(string id) : Task<Book>
    +AddBookByIsbn(string isbn) : Task<Book>
    +RemoveBook(Book book) : Task<bool>
    +RemoveBook(string id) : Task<bool>
    +RemoveBook(string id) : Task<bool>
    +AddToFavorites(Book book) : Task<bool>
    +AddToFavorites(string bookId) : Task<bool>
    +RemoveFromFavorites(Book book) : Task<bool>
    +RemoveFromFavorites(string bookId) : Task<bool>
    +UpdateBook(Book updatedBook) : Task<Book>
    +AddContact(Contact contact) : Task<Contact>
    +RemoveContact(Contact contact) : Task<bool>
    +LendBook(Book book, Contact contact, DateTime? loanDate) : Task<bool>
    +GetBackBook(Book book, DateTime? returnedDate) : Task<bool>
    +BorrowBook(Book book, Contact owner, DateTime? borrowedDate) : Task<bool>
    +GiveBackBook(Book book, DateTime? returnedDate) : Task<bool>

    +GetCurrentLoans(int index, int count)
    +GetPastLoans(int index, int count)
    +GetCurrentBorrowings(int index, int count)
    +GetPastBorrowings(int index, int count)
    +GetContacts(int index, int count)
}

class ILibraryManager {
    <<interface>>
    +GetBookById(string id)
    +GetBookByIsbn(string isbn)
    +GetBooksByTitle(string title, int index, int count, string sort)
    +GetBooksByAuthorId(string authorId, int index, int count, string sort)
    +GetBooksByAuthor(string author, int index, int count, string sort)
    +GetAuthorById(string id)
    +GetAuthorsByName(string substring, int index, int count, string sort)
}

class Status {
    <<enum>>
}

IUserLibraryManager ..|> ILibraryManager
IUserLibraryManager ..> Status
IUserLibraryManager ..> Contact
IUserLibraryManager ..> Book
ILibraryManager ..> Book
ILibraryManager ..> Author
```

## Ressources 
- [Doc officielle MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)
- [MAUI Community Toolkit](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/)
- [SF Symbols 5.0 (format SVG et PNG)](https://www.figma.com/file/7ATqS05m0VqE905x1NKS0D/SF-Symbols-5.0---5296-SVG-Icons-(Community)?type=design&node-id=5-1670&mode=design&t=75VRROmRWJsStAIv-0)
- [SF Symbols 5.0 (PNG only)](https://github.com/andrewtavis/sf-symbols-online/tree/master/glyphs)
  
