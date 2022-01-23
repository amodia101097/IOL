using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        public Rectangulo(int Tipo, decimal Lado, decimal Base) : base(Tipo, Lado)
        {
            this.Tipo = Tipo;
            this.Lado = Lado;
            this.Base = Base;
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
                    return ("rectangulo");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("rettangolo");
                else
                    return ("Rectangle");
            }
            else
            {
                if (idioma.IDIdioma == Print.Castellano)
                    return ("rectangulos");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("rettangoli");
                else
                    return ("rectangles");

            }
        }

        public override decimal CalcularArea(FormaGeometrica forma)
        {
            return (forma.Base * forma.Lado);
        }

        public override decimal CalcularPerimetro(FormaGeometrica forma)
        {
            return (forma.Base + forma.Lado + forma.Base + forma.Lado);
        }

    }
}
