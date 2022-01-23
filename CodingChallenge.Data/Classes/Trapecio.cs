using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
   public class Trapecio : FormaGeometrica
    {
        public Trapecio(int Tipo, decimal Altura, decimal BaseMenor, decimal BaseMayor) : base(Tipo, Altura)
        {
            this.Tipo = Tipo;
            this.Altura = Altura;
            this.BaseMayor = BaseMayor;
            this.BaseMenor = BaseMenor;


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
                    return ("Trapecio");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("Trapezio");
                else
                    return ("Trapeze");
            }
            else
            {
                if (idioma.IDIdioma == Print.Castellano)
                    return ("trapecio");
                else if (idioma.IDIdioma == Print.Italiano)
                    return ("trapezi");
                else
                    return ("trapezes");

            }
        }

        public override decimal CalcularArea(FormaGeometrica forma)
        {
            return ((forma.BaseMayor + forma.BaseMenor) * forma.Altura) / 2;
        }

        public override decimal CalcularPerimetro(FormaGeometrica forma)
        {
            return (forma.BaseMayor + forma.BaseMenor + forma.Altura + forma.Altura);
        }


    }
}
