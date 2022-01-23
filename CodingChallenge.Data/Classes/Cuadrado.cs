using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica 
    {
        public Cuadrado(int Tipo, decimal Lado) : base (Tipo, Lado)
        {

        }

        public override Calculo ImprimirTotal(List<FormaGeometrica> formas, int Tipo)
        {
            return base.ImprimirTotal(formas, Tipo);
        }

        public override string ImprimirCalculo(List<FormaGeometrica> formas, int Tipo, Idioma idioma)
        {
           return base.ImprimirCalculo(formas, Tipo, idioma);
        }

        public override string ObtenerLinea(Idioma idioma, int Cantidad, decimal Area, decimal Perimetro, int tipo)
        {
            return base.ObtenerLinea(idioma, Cantidad, Area, Perimetro, tipo);
        }

        public override decimal CalcularArea(FormaGeometrica forma)
        {
            return forma.Lado * forma.Lado;
        }

        public override decimal CalcularPerimetro(FormaGeometrica forma)
        {
            return forma.Lado * 4;
        }

        public override string TraducirForma(int Cantidad, Idioma idioma)
        {
            if (Cantidad == 1)
            {
                if (idioma.IDIdioma == Print.Castellano)
                    return ("Cuadrado");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("Quadrato");
                else
                    return ("Square");
            }
            else
            {
                if (idioma.IDIdioma == Print.Castellano)
                    return ("Cuadrados");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("Quadrados");
                else
                    return ("Squares");

            }
        }

    }
}
