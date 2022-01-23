using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica 
    {

        public Circulo(int Tipo, decimal Lado) : base(Tipo, Lado)
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

        public override string TraducirForma(int cantidad, Idioma idioma)
        {
            if (cantidad == 1)
            {
                if (idioma.IDIdioma == Print.Castellano)
                    return ("Círculo");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("Cerchio");
                else
                    return ("Circle");
            }
            else
            {
                if (idioma.IDIdioma == Print.Castellano)
                    return ("Círculos");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("Cerchi");
                else
                    return ("Circles");

            }
        }

        public override decimal CalcularArea(FormaGeometrica forma)
        {
            return (decimal)Math.PI * (forma.Lado / 2) * (forma.Lado / 2);
        }

        public override decimal CalcularPerimetro(FormaGeometrica forma)
        {
                return (decimal)Math.PI * forma.Lado;
        }

    }
}
