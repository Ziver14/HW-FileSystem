namespace HW_FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilmManager filmManager = new FilmManager();

            filmManager.AddFilm(new Film { Name = "Casino", YearOfRealise = 1984, Director = "Scorceze", Genre = "Triller" });
            filmManager.AddFilm(new Film { Name = "Terminator", YearOfRealise = 1991, Director = "Cameron", Genre = "Acthion" });
            filmManager.AddFilm(new Film { Name = "OneStep", YearOfRealise = 1995, Director = "Oliver", Genre = "Drama" });

            filmManager.SaveToJson("films.json");
            filmManager.LoadFromJson("films.json");

            foreach (var i in filmManager.filmList)
            {
                Console.WriteLine($"Name: {i.Name}, YearOfRealise:{i.YearOfRealise},Director: {i.Director}, Genre: {i.Genre}");
            }
            Console.WriteLine();

            filmManager.SaveToXml("films.xml");
            filmManager.LoadFromXml("films.xml");
            foreach (var i in filmManager.filmList)
            {
                Console.WriteLine($"Name: {i.Name}, YearOfRealise:{i.YearOfRealise},Director: {i.Director}, Genre: {i.Genre}");
            }
            Console.WriteLine();

            IEnumerable<Film> findOgGenre = filmManager.FindOfGenre("Acthion");
            foreach (var i in findOgGenre)
            {
                Console.WriteLine($"Name: {i.Name}, YearOfRealise:{i.YearOfRealise},Director: {i.Director}, Genre: {i.Genre}");
            }
            Console.WriteLine();

            IEnumerable<Film> findOgDirector = filmManager.FindOfDirector("Scorceze");
            foreach (var i in findOgDirector)
            {
                Console.WriteLine($"Name: {i.Name}, YearOfRealise:{i.YearOfRealise},Director: {i.Director}, Genre: {i.Genre}");
            }
            Console.WriteLine();
        }
    }
}
