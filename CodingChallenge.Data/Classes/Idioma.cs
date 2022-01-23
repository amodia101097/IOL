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
        private string nameIdioma;

        public string NameIdioma
        {
            get { return nameIdioma; }
            set { nameIdioma = value; }
        }

        private int idIdioma;

        public int IDIdioma
        {
            get { return idIdioma; }
            set { idIdioma = value; }
        }


        public Idioma(string NameIdioma, int IDIdioma)
        {
            this.NameIdioma = NameIdioma;
            this.IDIdioma = IDIdioma;
        }

    }
}
