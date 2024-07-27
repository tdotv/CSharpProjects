// LINQ - набор методов расширения либо к интерфейсу IEnumerable, либо к IQueryable. Из-за того, что это статические методы,
// они должны быть прикреплены на этапе компиляции. Если используется какая-то коллекция использующая IQueryable, но она лежит
// в типе IEnumerable, то применятся методы расширения к IEnumerable. Это может привести к выполнению запросов не на стороне
// базы, а на стороне приложения. Это ОПАСНО!

using System.Collections;
using Microsoft.EntityFrameworkCore;

class Sample8
{
    public async Task<int> F()
    {
        var ctx = new SampleDbContext();
        // for (int i = 0; i < 500_000; i++)
        // {
        //     ctx.BigTable.Add(new BigTableItem() { Data = i });
        // }
        // ctx.SaveChanges();
        ctx.Add(new Person() { Age = 10, Name = "Oleg", Surname = "Turelskiy" });

        ctx.People.Add(new Person()
        {
            Name = "Iggy",
            Surname = "Pop",
            Age = 999,
            Phones = new[] {
                new Phone() { PhoneNumber = "555-555-555" },
                new Phone() { PhoneNumber = "555-555-556" }
            }
        });

        ctx.People.Add(new Person()
        {
            Name = "Ray",
            Surname = "Charles",
            Age = 105,
            Phones = new[] {
                new Phone() { PhoneNumber = "555-555-777" },
                new Phone() { PhoneNumber = "555-888-556" },
                new Phone() { PhoneNumber = "888-888-556" }
            }
        });

        await ctx.SaveChangesAsync();
        Console.Clear();

        // foreach (var item in ctx.BigTable.Where(x => x.Id % 2 == 0))
        // {
        //     System.Console.WriteLine(item.Id);
        //     Console.ReadLine();
        // }

        foreach (var item in ctx.People.Where(x => x.Phones.Count() > 1))
        {
            System.Console.WriteLine(item.Name);
            Console.ReadLine();
        }
    }
}

public class BigTableItem
{
    public long Id { get; set; }
    public long Data { get; set; }
}

public class Phone
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public int PersonId { get; set; }
    public Person Person{ get; set; }

}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public ICollection<Phone> Phones { get; set; }
}

public class SampleDbContext : DbContext
{
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Person> People { get; set; }

    public DbSet<BigTableItem> BigTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseNpqsql("User Id=postgres;Host=localhost;Port=5432;Database=Sample;Password=postqres");
        base.OnConfiguring(optionsBuilder);
    }
}