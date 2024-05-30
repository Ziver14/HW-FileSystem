using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_FileSystem
{
    public class Film:IFilm
    {
        public string Name { get; set; }
        public int YearOfRealise { get; set; }
        public string Director { get; set; }
        public string Genre { get; set;  }
    }
}

