namespace LINQ
{
    public class Program
    {
        public static void Main()
        {
            // new Sample1().F();
            // new Sample2().F();
            // new Sample3().F();
            // new Sample4().F();
            // new Sample5().F();
            // new Sample6().F();
            // new Sample7().F();
            // await new Sample8().F();

            // ---------------------------------------------------------

            var data = new List<object>() {
                "Hello",
                new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                new List<int>() {4, 6, 8, 2},
                new string[] {"Hello inside array"},
                new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                 }},
                new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                "Leonardo DiCaprio"
            };

            // 1. Print all numbers from 10 to 50 separated by commas
            // System.Console.WriteLine(string.Join(",", Enumerable.Range(10,41)));

            // 2.  Print only that numbers from 10 to 50 that can be divided by 3
            // System.Console.WriteLine(string.Join(" ", Enumerable.Range(10,41).Where(n => n % 3 == 0)));

            // 3. Output word "Linq" 10 times
            // System.Console.WriteLine(string.Join(" ", Enumerable.Repeat("LINQ", 10)));

            // 4. Output all words with letter 'a' in string "aaa;abb;ccc;dap"
            // System.Console.WriteLine(string.Join(" ", "aaa;abb;ccc;dap".Split(";").Where(word => word.Contains("a"))));

            // 5. Output number of letters 'a' in the words with this letter in string "aaa;abb;ccc;dap" separated by comma
            // System.Console.WriteLine("aaa;abb;ccc;dap".Split(";").Where(w => w.Contains('a')).Sum(w => w.Count(c => c == 'a')));

            // 6. Output true if word "abb" exists in line  "aaa;xabbx;abb;ccc;dap", otherwise false
            // System.Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(";").Contains("abb"));

            // 7. Get the longest word in string "aaa;xabbx;abb;ccc;dap"
            // Console.WriteLine(string.Join(" ", "aaa;xabbx;abb;ccc;dap".Split(';').OrderByDescending(w => w.Length).First()))
            // Console.WriteLine(string.Join(" ", "aaa;xabbx;abb;ccc;dap".Split(';').Aggregate((longest, next) => next.Length > longest.Length ? next : longest)));

            // 8. Calculate average length of word in string "aaa;xabbx;abb;ccc;dap"
            // Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Average(w => w.Length));
            // Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Select(word => word.Length).Average());

            // 9. Print the shortest word reversed in string "aaa;xabbx;abb;ccc;dap;zh"
            // Console.WriteLine(new string("aaa;xabbx;abb;ccc;dap;zh".Split(';').OrderBy(word => word.Length).First().Reverse().ToArray()));
            // Console.WriteLine("aaa;xabbx;abb;ccc;dap;zh".Split(';').Aggregate((shortest, next) => next.Length < shortest.Length ? next : shortest).Reverse().ToArray());

            // ??? 10. Print true if in the first word that starts from "aa" all letters are 'b' otherwise false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"
            // Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').FirstOrDefault(w => w.StartsWith("aa"))?.All(c => c == 'b'));

            // 11. Print last word in sequence that excepting first two elements that ends with "bb"
            // Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').Skip(2).LastOrDefault(word => word.EndsWith("bb")));

            //  1. Output all elements excepting ArtObjects
            Console.WriteLine(string.Join(" | ", data.Where(item => item is not ArtObject)
            .Select(item => item switch
            {
                List<int> list => string.Join(", ", list),
                string[] array => string.Join(", ", array),
                _ => item.ToString()
            })));

            // 2. Output all actors names
            System.Console.WriteLine(string.Join(" | ", data.OfType<Film>()
                .SelectMany(film => film.Actors)
                .GroupBy(actor => new { actor.Name, actor.Birthdate })
                .Select(group => group.Key.Name)));

            // 3. Output number of actors born in august
            System.Console.WriteLine(data.OfType<Film>()
                .SelectMany(film => film.Actors)
                .GroupBy(actor => new { actor.Name, actor.Birthdate })
                .Count(group => group.Key.Birthdate.Month == 8));

            //  4. Output two oldest actors names
            System.Console.WriteLine(string.Join(" | ", data.OfType<Film>()
                .SelectMany(film => film.Actors)
                .OrderBy(actor => actor.Birthdate)
                .Take(2)
                .Select(actor => actor.Name)));

            //  5. Output number of books per authors
            System.Console.WriteLine(string.Join(" | ", data.OfType<Book>()
                .GroupBy(book => book.Author)
                .Select(group => $"{group.Key}: {group.Count()}")));
            
            // 6. Output number of books per authors and films per director
            System.Console.WriteLine(string.Join(" | ", data.OfType<Book>()
                .GroupBy(book => book.Author)
                .Select(group => $"{group.Key}: {group.Count()}")
                .Concat(
                    data.OfType<Film>()
                    .GroupBy(film => film.Author)
                    .Select(group => $"{group.Key}: {group.Count()}")
                )));

            // 7. Output how many different letters used in all actors names
            System.Console.WriteLine(data.OfType<Film>()
                .SelectMany(film => film.Actors)
                .SelectMany(actor => actor.Name)
                .Where(char.IsLetter)
                .Distinct()
                .Count());

            // 8. Output names of all books ordered by names of their authors and number of pages
            System.Console.WriteLine(string.Join(", ", data.OfType<Book>()
                .OrderBy(book => book.Author)
                .ThenBy(book => book.Pages)
                .Select(book => book.Name)));

            // 9. Output actor name and all films with this actor
            System.Console.WriteLine(string.Join("\n",
                data.OfType<Film>()
                    // проекция каждого объекта Film на коллекцию Actors, а затем объединение их в плоскую последовательность
                    .SelectMany(film => film.Actors
                    // создание нового анонимного типа
                    .Select(actor => new { Actor = actor.Name, Film = film.Name }))
                    // группировка результрующей последовательности \ ключ - имя актера
                    .GroupBy(info => info.Actor)
                    .Select(group => $"{group.Key}: {string.Join(", ", group.Select(info => info.Film))}")));

            // 10. Output sum of total number of pages in all books and all int values inside all sequences in data
            System.Console.WriteLine(data.OfType<Book>()
                .Sum(book => book.Pages) + 
                data.OfType<IEnumerable<int>>().SelectMany(sequence => sequence).Sum());
        }
    }

    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    abstract class ArtObject
    {

        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

    class Book : ArtObject
    {
        public int Pages { get; set; }
    }
}

