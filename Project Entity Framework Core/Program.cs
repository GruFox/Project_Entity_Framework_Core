using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project_Entity_Framework_Core;

internal class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Manager manager = new Manager(db);

            manager.DefaultFillingDataBase();
            manager.Start();
        }
    }    
}
