using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project_Entity_Framework_Core;

public class BookRepository
{
    private AppContext db;
    public BookRepository(AppContext db)
    {
        this.db = db;
    }

    /// <summary>
    /// Добавляет книгу
    /// </summary>
    public void AddBook()
    {
        Console.WriteLine("\nВведите название новой книги:");
        var titleNewBook = Console.ReadLine();

        Console.WriteLine("\nВведите автора новой книги:");
        var authorNewBook = Console.ReadLine();

        Console.WriteLine("\nВведите год публикации новой книги:");
        var yearPublicationNewBook = Console.ReadLine();

        if (titleNewBook != null && authorNewBook != null && yearPublicationNewBook != null)
        {
            if (int.TryParse(yearPublicationNewBook, out int year))
            {
                var newBook = new Book {Title = titleNewBook, Author = authorNewBook, Publication = year};

                db.Books.Add(newBook);
                db.SaveChanges();

                Console.WriteLine("\nНовая книга добавлена.");
            }
            else
            {
                Console.WriteLine("Ошибка: введено не число!\n");
            }
        }
        else
        {
            Console.WriteLine("\nНеобходимо заполнить все данные новой книги!\n");
        }
    } //6 команда

    /// <summary>
    /// Удаляет книгу
    /// </summary>
    public void DeleteBook()
    {
        Console.WriteLine("\nВведите название книги, которую необходимо удалить:");

        var titleDeletedBook = Console.ReadLine();

        if (titleDeletedBook != null)
        {
            var DeletedBook = db.Books.FirstOrDefault(book => book.Title == titleDeletedBook);

            if (DeletedBook != null)
            {
                db.Books.Remove(DeletedBook);
                db.SaveChanges();
                Console.WriteLine("\nКнига удалена!\n");
            }
            else
            {
                Console.WriteLine("\nКниги с таким названием не существует!\n");
            }
        }
    } //7 команда

    /// <summary>
    /// Получить книгу по идентификационному номеру
    /// </summary>
    public Book SelectionBookById()
    {
        Book? choosedBook = null;

        Console.WriteLine("Введите идентификационный номер книги:");
        if (int.TryParse(Console.ReadLine(), out int bookId))
        {
            choosedBook = db.Books.FirstOrDefault(book => book.Id == bookId);

            if (choosedBook != null)
            {
                Console.WriteLine($"\tВыбрана книга:\t{choosedBook.Title}\n\t\tАвтора:\t{choosedBook.Author}\n\t\tДата публикации:\t{choosedBook.Publication}\n\t\tЖанр:\t{choosedBook.Genre}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Книги с таким идентификационным номером не существует!");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введено не число!");
        }
        return choosedBook;
    } //8 команда

    /// <summary>
    /// Получить все книги
    /// </summary>
    public void SelectionAllBooks()
    {
        var AllBooks = db.Books.ToList();

        if (AllBooks != null)
        {
            Console.WriteLine("\nСписок всех книг:\n");

            Console.WriteLine("\tID\tНазвание\tАвтор\tДата публикации\tЖанр");
            Console.WriteLine();

            foreach (var book in AllBooks)
            {
                Console.WriteLine("\t" + book.Id + "\t" + book.Title + "\t" + book.Author + "\t" + book.Publication + "\t" + book.Genre);
            }
        }
        else
        {
            Console.WriteLine("Книги в базе данных бибилиотеки отсутствуют!\n");
        }
    } //9 команда

    /// <summary>
    /// Обновить дату публикации книги по идентификационному номеру
    /// </summary>
    public void UpdateBooksPublicationById()
    {
        Console.WriteLine("\nВведите идентификационный номер книги:");

        if (int.TryParse(Console.ReadLine(), out int bookId))
        {
            var choosedBookForUpdatedPublication = db.Books.FirstOrDefault(book => book.Id == bookId);

            if (choosedBookForUpdatedPublication != null)
            {
                Console.WriteLine("Введите новую дату публикации книги:");

                if (int.TryParse(Console.ReadLine(), out int newBooksPublication))
                {
                    choosedBookForUpdatedPublication.Publication = newBooksPublication;
                    db.SaveChanges();
                    Console.WriteLine("Год выпуска книги обновлен!\n");
                }
                else
                {
                    Console.WriteLine("Ошибка: введено не число!\n");
                }
            }
            else
            {
                Console.WriteLine("Книги с таким идентификационным номером не существует!\n");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введено не число!\n");
        }
    } //10 команда

    /// <summary>
    /// Закрепить книгу за пользователем
    /// </summary>
    /// <param name="user"></param>
    public void ReceivingBook(User user)
    {
        Console.WriteLine("Введите название книги, которую хотите получить:");

        var titleReceivedBook = Console.ReadLine();

        var ReceivedBook = db.Books.FirstOrDefault(book => book.Title == titleReceivedBook);

        if (ReceivedBook != null)
        {
            ReceivedBook.User = user;
            user.Books.Add(ReceivedBook);
            db.SaveChanges();

            Console.WriteLine($"\nКнига закреплена за пользователем {user.Name}.");
        }
        else
        {
            Console.WriteLine("Книги с таким названием не существует!");
        }
    } //11 команда

    /// <summary>
    /// Добавить жанр книги
    /// </summary>
    /// <param name="book"></param>
    public void AddGenre(Book book)
    {
        Console.WriteLine("Введите жанр книги:");

        var genre = Console.ReadLine();

        if (string.IsNullOrEmpty(genre) != true)
        {
            book.Genre = genre;
            db.SaveChanges();

            Console.WriteLine("\nЖанр книги обновлен.");
        }
        else
        {
            Console.WriteLine("Ошибка: название жанра не введено!");
        }
    } //12 команда

    /// <summary>
    /// Добавить автора книге
    /// </summary>
    /// <param name="book"></param>
    public void AddAuthor(Book book)
    {
        Console.WriteLine("Введите имя автора, которого хотите добавить:");

        var additionalAuthor = Console.ReadLine();

        if (string.IsNullOrEmpty(additionalAuthor) != true)
        {
            var editableAuthor = book.Author;

            if (editableAuthor != null)
            {
                editableAuthor = $"{editableAuthor}, {additionalAuthor}";

                book.Author = editableAuthor;
                db.SaveChanges();

                Console.WriteLine("\nИмя автора книги обновлено.");
            }
            else
            {
                book.Author = additionalAuthor;
                db.SaveChanges();

                Console.WriteLine("\nИмя автора книги обновлено.\n");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: имя автора не введено!");
        }
    } //13 команда

    /// <summary>
    /// Получать список книг определенного жанра и вышедших между определенными годами
    /// </summary>
    public void SelectionBooksByGenreAndPublication()
    {
        Console.WriteLine("Введите жанр интересующих Вас книг:");
        var genre = Console.ReadLine();

        if(genre == null) { Console.WriteLine("Жанр не указан!"); }

        Console.WriteLine("\nВведите интервальный период публикации интересующих Вас книг:\n");

        int beginningPeriod;
        Console.WriteLine("Укажите начальный год интервального периода:");
        if (int.TryParse(Console.ReadLine(), out beginningPeriod) == false)
        {
            Console.WriteLine("Это не число!");
        }

        int endPeriod;
        Console.WriteLine("Укажите конечный год интервального периода:");
        if (int.TryParse(Console.ReadLine(), out endPeriod) == false)
        {
            Console.WriteLine("Это не число!\n");
        }

        var BooksQuery = db.Books.Where(b => b.Genre == genre && b.Publication >= beginningPeriod && b.Publication <= endPeriod).ToList();

        if (BooksQuery.Count > 0)
        {
            Console.WriteLine("\nСписок книг согласно интересующему Вас жанру и периоду публикации:");
            foreach (Book book in BooksQuery)
            {
                Console.WriteLine($"\t{book.Title}\t{book.Publication}");
            }
        }
        else { Console.WriteLine("В библиотеке нет книг согласно интересующему Вас жанру и периоду публикации."); }
    } //14 команда

    /// <summary>
    /// Получать количество книг определенного автора в библиотеке
    /// </summary>
    public void GetQuantityBooksByAuthor()
    {
        Console.WriteLine("Введите имя автора:");
        var author = Console.ReadLine();

        if (string.IsNullOrEmpty(author) == false)
        {
            var countAuthor = db.Books.Count(b => b.Author == author);

            if (countAuthor > 0)
            {
                Console.WriteLine($"В библиотеке есть {countAuthor} книг, у которых автор {author}.");
            }
            else { Console.WriteLine("В библиотеке нет книг автора " + author); }
        }
        else { Console.WriteLine("Вы ничего не ввели."); }
    } //15 команда

    /// <summary>
    /// Получать количество книг определенного жанра в библиотеке
    /// </summary>
    public void GetQuantityBooksByGenre()
    {
        Console.WriteLine("Введите жанр:");
        var genre = Console.ReadLine();

        if (string.IsNullOrEmpty(genre) == false)
        {
            var countBooksByGenre = db.Books.Count(b => b.Genre == genre);

            if (countBooksByGenre > 0)
            {
                Console.WriteLine($"В библиотеке есть {countBooksByGenre} книг, у которых жанр {genre}.");
            }
            else { Console.WriteLine("В библиотеке нет книг жанра " + genre); }
        }
        else { Console.WriteLine("Вы ничего не ввели."); }
    } //16 команда

    /// <summary>
    /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
    /// </summary>
    /// <returns></returns>
    public bool IsThereABook()
    {
        Console.WriteLine("Введите название книги:");
        var titleBook = Console.ReadLine();

        Console.WriteLine("Введите автора книги:");
        var authorBook = Console.ReadLine();

        if (titleBook != null && authorBook != null)
        {
            var queryBook = db.Books.Any(b => b.Title == titleBook && b.Author == authorBook);
            return queryBook;
        }
        return false;
    } //17 команда

    /// <summary>
    /// Получать булевый флаг о том, есть ли определенная книга на руках у пользователя
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public bool IsTheBookWithTheUser(Book book)
    {
        var queryBookToUser = db.Users.Any(u => u.Books.Contains(book));

        if (queryBookToUser == true)
        {
            return queryBookToUser;
        }
        return false;
    } //18 команда

    /// <summary>
    /// Получать количество книг на руках у пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public void GetQuantityBooksWithUser(User user)
    {
        var countBooks = db.Books.Count(b => b.User == user);
        
        Console.WriteLine($"Общее количество книг на руках у пользователя: {countBooks}");
    } //19 команда

    /// <summary>
    /// Получение последней вышедшей книги
    /// </summary>
    /// <returns></returns>
    public void GetLastPublishedBook()
    {
        var book = db.Books.OrderByDescending(b => b.Publication).FirstOrDefault();

        if (book != null)
        {
            Console.WriteLine("Последняя вышедшая книга:\n");
            Console.WriteLine("\tНазвание\t\tАвтор\t\tДата публикации\t\tЖанр");
            Console.WriteLine();

            Console.WriteLine("\t" + book.Title + "\t" + book.Author + "\t" + book.Publication + "\t" + book.Genre);
        }
        else
        {
            Console.WriteLine("В базе данных библиотеки книги отсутствуют!");
        }
    } //20 команда

    /// <summary>
    /// Получение списка всех книг, отсортированного в алфавитном порядке по названию
    /// </summary>
    /// <returns></returns>
    public void GetAllBooksAscending()
    {
        var books = db.Books.OrderBy(b => b.Title).ToList();

        if (books != null)
        {
            Console.WriteLine("Спискок книг, отсортированный в алфавитном порядке по названию:\n");
            Console.WriteLine("\tНазвание\t\tАвтор\t\tДата публикации\t\tЖанр");
            Console.WriteLine();

            foreach (var book in books)
            {
                Console.WriteLine("\t" + book.Title + "\t" + book.Author + "\t" + book.Publication + "\t" + book.Genre);
            }
        }
        else
        {
            Console.WriteLine("В базе данных библиотеки книги отсутствуют!");
        }
    } //21 команда

    /// <summary>
    /// Получение списка всех книг, отсортированного в порядке убывания года их выхода
    /// </summary>
    /// <returns></returns>
    public void GetAllBooksByPublicationDescending()
    {
        var books = db.Books.OrderByDescending(b => b.Publication).ToList();

        if (books != null)
        {
            Console.WriteLine("Спискок книг, отсортированный в порядке убывания года их выхода:\n");
            Console.WriteLine("\tНазвание\t\tАвтор\t\tДата публикации\t\tЖанр");
            Console.WriteLine();

            foreach (var book in books)
            {
                Console.WriteLine("\t" + book.Title + "\t" + book.Author + "\t" + book.Publication + "\t" + book.Genre);
            }
        }
        else
        {
            Console.WriteLine("В базе данных библиотеки книги отсутствуют!");
        }
    } //22 команда
}
