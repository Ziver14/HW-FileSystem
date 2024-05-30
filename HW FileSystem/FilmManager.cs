using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace HW_FileSystem
{
    public class FilmManager
    {
        public List<Film> filmList = new List<Film>();
        public void AddFilm(Film film) {  filmList.Add(film); }
        public void DeleteFilm(string name) 
        {
            filmList.RemoveAll( p => p.Name == name);
        }
        public IEnumerable<Film> FindOfGenre(string genre) 
        {
            return filmList.Where(p=>p.Genre.ToLower() == genre.ToLower());
        }

        public IEnumerable<Film> FindOfDirector(string director)
        {
            return filmList.Where(p => p.Director.ToLower() == director.ToLower());
        }

        public void SaveToJson(string path)
        {
            string json = JsonConvert.SerializeObject(filmList);
            File.WriteAllText(path, json);
        }

        public void LoadFromJson(string path)
        {
            string json = File.ReadAllText(path);
            filmList = JsonConvert.DeserializeObject<List<Film>>(json);
        }

        public void SaveToXml(string path)
        {
            XElement xml = new XElement("Films",
                from film in filmList
                select new XElement("Film",
                new XAttribute("Name", film.Name),
                new XAttribute("YearOfRealise", film.YearOfRealise),
                new XAttribute("Director", film.Director),
                new XAttribute("Genre", film.Genre)));
            xml.Save(path);
        }

        public void LoadFromXml(string path)
        {
            
            XDocument xml = XDocument.Load(path);
            filmList = xml.Descendants("Film")
                .Select(p => new Film
                {
                    Name = p.Attribute("Name").Value,
                    YearOfRealise = int.Parse(p.Attribute("YearOfRealise").Value),
                    Director = p.Attribute("Director").Value,
                    Genre = p.Attribute("Genre").Value
                }).ToList();


        }

    }
}
