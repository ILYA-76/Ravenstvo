
using SQL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using (ApplicationContext db = new ApplicationContext())
{
    // создаем два объекта User
    User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 26 };

    // добавляем их в бд
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
public class Phone
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
}

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Phone> Phones { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

public class status
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class post
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class deps 
{ 
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }

    public DateOnly DateEmploy { get; set; }
    public DateOnly DateUneploy { get; set; }

    public int Status { get; set; }
    public int IdDep { get; set; }
    public int IdPost { get; set; }
}