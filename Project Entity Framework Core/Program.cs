namespace Project_Entity_Framework_Core;

internal class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            var user1 = new User { Name = "Ilgiz", Email = "senior_C@notcat.rs" };
            var user2 = new User { Name = "Igor", Email = "not_jun_yet@notcat.rs" };
            var user3 = new User { Name = "Matvej", Email = "senior_DB@notcat.rs"};
            var user4 = new User { Name = "Darija", Email = "junior_QA@notcat.rs"};

            var book1 = new Book { Title = "Meeting or Coding? Вот в чем вопрос", Author = "Шекспир Уильям" };
            var book2 = new Book { Title = "Шарповит", Author = "Кирилл и Мефодий" };
            var book3 = new Book { Title = "Update ТрансСум", Author = "Мирзиёев ШМ" };
            var book4 = new Book { Title = "Как продебажить жизнь?", Author = "КонсультантПлюс" };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Users.Add(user3);
            db.Users.Add(user4);

            db.Books.Add(book1);
            db.Books.Add(book2);
            db.Books.Add(book3);
            db.Books.Add(book4);

            db.SaveChanges();
        }
    }
}
