using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Entity_Framework_Core.Program;

namespace Project_Entity_Framework_Core;

public class Manager
{
    private AppContext db;
    public Manager(AppContext db)
    {
        this.db = db;
    }

    /// <summary>
    /// Заполняет по умолчанию базу данных
    /// </summary>
    public void DefaultFillingDataBase()
    {
        var user1 = new User { Name = "Ilgiz", Email = "C#_senior@notcat.rs" };
        var user2 = new User { Name = "Igor", Email = "not_jun_yet@notcat.rs" };
        var user3 = new User { Name = "Matvej", Email = "DB_senior@notcat.rs" };
        var user4 = new User { Name = "Darija", Email = "QA_junior@notcat.rs" };
        var user5 = new User { Name = "Petr", Email = "electrician@notIT.rs"};
        var user6 = new User { Name = "Arkadij", Email = "plumber@notIT.rs"};

        var book1 = new Book { Title = "Айвенго", Author = "Вальтер Скотт", Publication = 1819, Genre = "Исторический" };
        var book2 = new Book { Title = "Война и мир", Author = "Лев Толстой", Publication = 1869, Genre = "Исторический" };
        var book3 = new Book { Title = "Столпы Земли", Author = "Кен Фоллетт", Publication = 1989, Genre = "Исторический" };
        var book4 = new Book { Title = "Властелин колец", Author = "Дж.Р.Р.Толкин", Publication = 1954, Genre = "Фантастический" };
        var book5 = new Book { Title = "Гарри Поттер и философский камень", Author = "Дж.К.Роулинг", Publication = 1997, Genre = "Фантастический" };
        var book6 = new Book { Title = "Игра престолов", Author = "Джордж Р.Р.Мартин", Publication = 1996, Genre = "Фантастический" };
        var book7 = new Book { Title = "Дюна", Author = "Фрэнк Герберт", Publication = 1965, Genre = "Научная фантастика" };
        var book8 = new Book { Title = "1984", Author = "Джордж Оруэлл", Publication = 1949, Genre = "Научная фантастика" };
        var book9 = new Book { Title = "Фундамент", Author = "Айзек Азимов", Publication = 1951, Genre = "Научная фантастика" };
        var book10 = new Book { Title = "Гордость и предубеждение", Author = "Джейн Остин", Publication = 1813, Genre = "Любовный" };
        var book11 = new Book { Title = "Ромео и Джульетта", Author = "Уильям Шекспир", Publication = 1597, Genre = "Любовный" };
        var book12 = new Book { Title = "Титаник", Author = "Уолтер Лорд", Publication = 1955, Genre = "Любовный" };
        var book13 = new Book { Title = "Сияние", Author = "Стивен Кинг", Publication = 1977, Genre = "Ужасы" };
        var book14 = new Book { Title = "Дракула", Author = "Брэм Стокер", Publication = 1897, Genre = "Ужасы" };
        var book15 = new Book { Title = "Франкенштейн", Author = "Мэри Шелли", Publication = 1818, Genre = "Ужасы" };
        var book16 = new Book { Title = "Остров сокровищ", Author = "Роберт Л.Стивенсон", Publication = 1883, Genre = "Приключенческий" };
        var book17 = new Book { Title = "Три мушкетёра", Author = "Александр Дюма", Publication = 1844, Genre = "Приключенческий" };
        var book18 = new Book { Title = "Одиссея", Author = "Гомер", Publication = -800, Genre = "Приключенческий" };
        var book19 = new Book { Title = "На Западном фронте без перемен", Author = "Эрих Мария Ремарк", Publication = 1929, Genre = "Военный" };
        var book20 = new Book { Title = "Пастырь родной страны", Author = "Эрнест Хемингуэй", Publication = 1940, Genre = "Военный" };
        var book21 = new Book { Title = "Путь человека", Author = "Джеймс Джонс", Publication = 1962, Genre = "Военный" };

        db.Users.AddRange(user1, user2, user3, user4, user5, user6);
        db.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14, book15, book16, book17, book18, book19, book20, book21);

        db.SaveChanges();

        Console.WriteLine("База данных библиотеки заполнена по умолчанию.");
    }

    /// <summary>
    /// Запускает работу с консолью
    /// </summary>
    public void Start()
    {
        var userRepository = new UserRepository(db);
        var bookRepository = new BookRepository(db);

        Console.WriteLine("Список команд для работы консоли:\n");
        Console.WriteLine((int)Commands.one + ": Добавить пользователя");
        Console.WriteLine((int)Commands.two + ": Удалить пользователя");
        Console.WriteLine((int)Commands.three + ": Выбрать пользователя по идентификационному номеру");
        Console.WriteLine((int)Commands.four + ": Выбрать всех пользователей");
        Console.WriteLine((int)Commands.five + ": Обновить имя пользователя по идентификационному номеру");
        Console.WriteLine((int)Commands.six + ": Добавить книгу");
        Console.WriteLine((int)Commands.seven + ": Удалить книгу");
        Console.WriteLine((int)Commands.eight + ": Получить книгу по идентификационному номеру");
        Console.WriteLine((int)Commands.nine + ": Получить все книги");
        Console.WriteLine((int)Commands.ten + ": Обновить дату публикации книги по идентификационному номеру");
        Console.WriteLine((int)Commands.eleven + ": Закрепить книгу за пользователем");
        Console.WriteLine((int)Commands.twelve + ": Добавить жанр книги");
        Console.WriteLine((int)Commands.thirteen + ": Добавить автора книге");
        Console.WriteLine((int)Commands.fourteen + ": Получить список книг определенного жанра и вышедших между определенными годами");
        Console.WriteLine((int)Commands.fifteen + ": Получить количество книг определенного автора в библиотеке");
        Console.WriteLine((int)Commands.sixteen + ": Получить количество книг определенного жанра в библиотеке");
        Console.WriteLine((int)Commands.seventeen + ": Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке");
        Console.WriteLine((int)Commands.eighteen + ": Получить булевый флаг о том, есть ли определенная книга на руках у пользователя");
        Console.WriteLine((int)Commands.nineteen + ": Получить количество книг на руках у пользователя");
        Console.WriteLine((int)Commands.twenty + ": Получить последнюю вышедшую книгу");
        Console.WriteLine((int)Commands.twenty_one + ": Получить список всех книг, отсортированный в алфавитном порядке по названию");
        Console.WriteLine((int)Commands.twenty_two + ": Получить список всех книг, отсортированный в порядке убывания года их выхода");
        Console.WriteLine((int)Commands.close + ": Завершить работу консоли");

        int number;

        do
        {
            Console.WriteLine("\nВведите номер команды:");

            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                if (Enum.IsDefined(typeof(Commands), number))
                {
                    Console.WriteLine("\nВы выбрали команду: " + number);

                    switch (number)
                    {
                        case 1:
                            {
                                userRepository.AddUser();
                                break;
                            }
                        case 2:
                            {
                                userRepository.DeleteUser();
                                break;
                            }
                        case 3:
                            {
                                userRepository.SelectionUserById();
                                break;
                            }
                        case 4:
                            {
                                userRepository.SelectionAllUsers();
                                break;
                            }
                        case 5:
                            {
                                userRepository.UpdateUsersNameById();
                                break;
                            }
                        case 6:
                            {
                                bookRepository.AddBook();
                                break;
                            }
                        case 7:
                            {
                                bookRepository.DeleteBook();
                                break;
                            }
                        case 8:
                            {
                                bookRepository.SelectionBookById();
                                break;
                            }
                        case 9:
                            {
                                bookRepository.SelectionAllBooks();
                                break;
                            }
                        case 10:
                            {
                                bookRepository.UpdateBooksPublicationById();
                                break;
                            }
                        case 11:
                            {
                                User user = userRepository.SelectionUserById();
                                if (user != null)
                                {
                                    bookRepository.ReceivingBook(user);
                                }
                                break;
                            }
                        case 12:
                            {
                                Book book = bookRepository.SelectionBookById();
                                if (book != null)
                                {
                                    bookRepository.AddGenre(book);
                                }
                                break;
                            }
                        case 13:
                            {
                                Book book = bookRepository.SelectionBookById();
                                if (book != null)
                                {
                                    bookRepository.AddAuthor(book);
                                }
                                break;
                            }
                        case 14:
                            {
                                bookRepository.SelectionBooksByGenreAndPublication();
                                break;
                            }
                        case 15:
                            {
                                bookRepository.GetQuantityBooksByAuthor();
                                break;
                            }
                        case 16:
                            {
                                bookRepository.GetQuantityBooksByGenre();
                                break;
                            }
                        case 17:
                            {
                                bool state = bookRepository.IsThereABook();
                                if (state != false)
                                {
                                    Console.WriteLine("Книга с таким названием и такого автора ЕСТЬ в библиотеке.");
                                }
                                else
                                {
                                    Console.WriteLine("Книги с таким названием и такого автора НЕТ в библиотеке.");
                                }
                                break;
                            }
                        case 18:
                            {
                                Book book = bookRepository.SelectionBookById();
                                if (book != null)
                                {
                                    bool state = bookRepository.IsTheBookWithTheUser(book);

                                    if (state != false)
                                    {
                                        Console.WriteLine($"Книга {book.Title} ЕСТЬ у пользователя.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Книги {book.Title} НЕТ у пользователя.");
                                    }
                                }
                                break;
                            }
                        case 19:
                            {
                                User user = userRepository.SelectionUserById();
                                if (user != null)
                                {
                                    bookRepository.GetQuantityBooksWithUser(user);
                                }
                                break;
                            }
                        case 20:
                            {
                                bookRepository.GetLastPublishedBook();
                                break;
                            }
                        case 21:
                            {
                                bookRepository.GetAllBooksAscending();
                                break;
                            }
                        case 22:
                            {
                                bookRepository.GetAllBooksByPublicationDescending();
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("\nТакой команды не существует!");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод, введите число!");
            }
        }
        while (number != 666);

        Console.WriteLine("\nРабота консоли завершена!");
    }

    /// <summary>
    /// Содержит список команд
    /// </summary>
    public enum Commands
    {
        one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9, ten = 10, eleven = 11, twelve = 12, thirteen = 13, fourteen = 14, fifteen = 15, sixteen = 16, seventeen = 17, eighteen = 18, nineteen = 19, twenty = 20, twenty_one = 21, twenty_two = 22, close = 666
    }
}
