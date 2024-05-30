using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_FileSystem
{
    public interface IFilm
    {
        public string Name { get; }
        public int YearOfRealise {  get; }
        public string Director {  get; }
        public string Genre {  get; }
    }
}
