using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
   public class Idioma
    {
        public String Name_idioma { get; set; }
        public int ID_idioma { get; set; }

        public Idioma(string Name_idioma, int ID_idioma)
        {
            this.Name_idioma = Name_idioma;
            this.ID_idioma = ID_idioma;
        }

    }
}
