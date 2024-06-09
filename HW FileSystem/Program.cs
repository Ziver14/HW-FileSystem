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

            ContactManager manager = new ContactManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Remove Contact");
                Console.WriteLine("3. Find Contact by Name");
                Console.WriteLine("4. Find Contact by Phone Number");
                Console.WriteLine("5. Display All Contacts");
                Console.WriteLine("6. Save Contacts to JSON");
                Console.WriteLine("7. Save Contacts to XML");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
               
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine();
                        manager.AddContact(new Contact { Name = name, PhoneNumber = phoneNumber });
                        break;
                    case "2":
                        Console.Write("Enter name of the contact to remove: ");
                        string nameToRemove = Console.ReadLine();
                        manager.RemoveContact(nameToRemove);
                        break;
                    case "3":
                        Console.Write("Enter name: ");
                        string nameToFind = Console.ReadLine();
                        var contactByName = manager.FindContactByName(nameToFind);
                        if (contactByName != null)
                        {
                            Console.WriteLine($"Name: {contactByName.Name}, Phone Number: {contactByName.PhoneNumber}");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter phone number: ");
                        string phoneToFind = Console.ReadLine();
                        var contactByPhone = manager.FindContactByPhoneNumber(phoneToFind);
                        if (contactByPhone != null)
                        {
                            Console.WriteLine($"Name: {contactByPhone.Name}, Phone Number: {contactByPhone.PhoneNumber}");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        break;
                    case "5":
                        manager.DisplayContacts();
                        break;
                    case "6":
                        Console.Write("Enter file path to save JSON: ");
                        string jsonPath = Console.ReadLine();
                        manager.SaveToJson(jsonPath);
                        break;
                    case "7":
                        Console.Write("Enter file path to save XML: ");
                        string xmlPath = Console.ReadLine();
                        manager.SaveToXml(xmlPath);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                   
                }
            }
        }
    }
}
