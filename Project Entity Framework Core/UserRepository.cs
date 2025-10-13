using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity_Framework_Core;

public class UserRepository
{
    private AppContext db;
    public UserRepository(AppContext db)
    {
        this.db = db;
    }

    /// <summary>
    /// Добавляет пользователя
    /// </summary>
    public void AddUser()
    {
        Console.WriteLine("\nВведите имя нового пользователя:");
        var nameNewUser = Console.ReadLine();

        if (string.IsNullOrEmpty(nameNewUser) != true)
        {
            Console.WriteLine("Введите эл.почту нового пользователя:");
            var emailNewUser = Console.ReadLine();

            var newUser = new User { Name = nameNewUser, Email = emailNewUser };

            db.Users.Add(newUser);

            db.SaveChanges();

            Console.WriteLine("\nНовый пользователь добавлен\n");
        }
        else
        {
            Console.WriteLine("\nНеобходимо ввести имя нового пользователя!\n");
        }
    } //1 команда

    /// <summary>
    /// Удаляет пользователя
    /// </summary>
    public void DeleteUser()
    {
        Console.WriteLine("\nВведите имя пользователя, которого необходимо удалить:");

        var nameDeletedUser = Console.ReadLine();

        if (nameDeletedUser != null)
        {
            var DeletedUser = db.Users.FirstOrDefault(user => user.Name == nameDeletedUser);

            if (DeletedUser != null)
            {
                db.Users.Remove(DeletedUser);
                db.SaveChanges();
                Console.WriteLine("\nПользователь удален!\n");
            }
            else
            {
                Console.WriteLine("\nПользователя с таким именем не существует!\n");
            }
        }
    } //2 команда

    /// <summary>
    /// Выбирает пользователя по идентификационному номеру
    /// </summary>
    public User SelectionUserById()
    {
        User? choosedUser = null;

        Console.WriteLine("\nВведите идентификационный номер пользователя:");
        if (int.TryParse(Console.ReadLine(), out int userId))
        {
            choosedUser = db.Users.FirstOrDefault(user => user.Id == userId);

            if (choosedUser != null)
            {
                Console.WriteLine($"\nВыбран пользователь:\t{choosedUser.Name}\nс электронной почтой:\t{choosedUser.Email}");
                Console.WriteLine();                
            }
            else
            {
                Console.WriteLine("Пользователя с таким идентификационным номером не существует!");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введено не число!");
        }
        return choosedUser;
    } //3 команда

    /// <summary>
    /// Выбирает всех пользователей
    /// </summary>
    public void SelectionAllUsers()
    {
        var AllUsers = db.Users.ToList();

        if (AllUsers != null)
        {
            Console.WriteLine("\nСписок всех пользователей:\n");

            Console.WriteLine("\tID\tИмя\tEmail");
            Console.WriteLine();

            foreach (var user in AllUsers)
            {
                Console.WriteLine("\t" + user.Id + "\t" + user.Name + "\t" + user.Email);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Пользователи в базе данных бибилиотеки отсутствуют!\n");
        }
    } //4 команда

    /// <summary>
    /// Обновляет имя пользователя по идентификационному номеру
    /// </summary>
    public void UpdateUsersNameById()
    {
        Console.WriteLine("\nВведите идентификационный номер пользователя:");

        if (int.TryParse(Console.ReadLine(), out int userId))
        {
            var choosedUpdatedUser = db.Users.FirstOrDefault(user => user.Id == userId);

            if (choosedUpdatedUser != null)
            {
                Console.WriteLine("Введите новое имя для пользователя:");
                var newName = Console.ReadLine();

                if (string.IsNullOrEmpty(newName) != true)
                {
                    choosedUpdatedUser.Name = newName;
                    db.SaveChanges();
                    Console.WriteLine("Имя пользователя обновлено!\n");
                }
                else
                {
                    Console.WriteLine("Необходимо ввести новое имя пользователя!\n");
                }
            }
            else
            {
                Console.WriteLine("Пользователя с таким идентификационным номером не существует!\n");
            }
        }        
        else
        {
            Console.WriteLine("Ошибка: введено не число!\n");
        }
    } //5 команда
}
