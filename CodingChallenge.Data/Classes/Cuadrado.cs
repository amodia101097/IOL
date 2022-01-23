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
        public Cuadrado(int Tipo, decimal Lado)
        {
            this.Tipo = Tipo;
            this.Lado = Lado;
        }

        public static Calculo ImprimirTotal(List<FormaGeometrica> formas, int Tipo)
        {
            var numero = 0;
            var area = 0m;
            var perimetro = 0m;

            Calculo Resul = new Calculo(0, 0, 0);

            for (var i = 0; i < formas.Count; i++)
            {
                if (formas[i].Tipo == Tipo)
                {
                    numero++;
                    area += CalcularArea(formas[i]);
                    perimetro += CalcularPerimetro(formas[i]);
                }

            }

            Resul.totalCantidad = numero;
            Resul.totalArea = area;
            Resul.totalPerimetro = perimetro;

            return Resul;
        }

        public static string ImprimirCalculo(List<FormaGeometrica> formas, int Tipo, Idioma idioma)
        {
            var numero = 0;
            var area = 0m;
            var perimetro = 0m;

            for (var i = 0; i < formas.Count; i++)
            {
                if (formas[i].Tipo == Tipo)
                {
                    numero++;
                    area += CalcularArea(formas[i]);
                    perimetro += CalcularPerimetro(formas[i]);
                }

            }

            return ObtenerLinea(idioma, numero, area, perimetro);
        }


        private static decimal CalcularArea(FormaGeometrica forma)
        {
            return forma.Lado * forma.Lado;
        }

        private static decimal CalcularPerimetro(FormaGeometrica forma)
        {
            return forma.Lado * 4;
        }

        public static string ObtenerLinea(Idioma idioma, int Cantidad , decimal Area , decimal Perimetro)
        {
            if (Cantidad > 0)
            {
                if (idioma.ID_idioma == Print.Castellano)
                    return $"{Cantidad} {TraducirForma(Cantidad, idioma)} | Area {Area.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} | Perimetro {Perimetro.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} <br/>";
                else if (idioma.ID_idioma == Print.Italiano)
                    return $"{Cantidad} {TraducirForma(Cantidad, idioma)} | La zona {Area.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} | Perimetro {Perimetro.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} <br/>";
                else
                    return $"{Cantidad} {TraducirForma(Cantidad, idioma)} | Area {Area.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} | Perimeter {Perimetro.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} <br/>";

            }

            return string.Empty;
        }

        private static string TraducirForma(int Cantidad, Idioma idioma)
        {
            if (Cantidad == 1)
            {
                if (idioma.ID_idioma == Print.Castellano)
                    return ("Cuadrado");
                else if (idioma.ID_idioma == Print.Italiano)
                    return ("Quadrato");
                else
                    return ("Square");
            }
            else
            {
                if (idioma.ID_idioma == Print.Castellano)
                    return ("Cuadrados");
                else if (idioma.ID_idioma == Print.Italiano)
                    return ("Quadrados");
                else
                    return ("Squares");

            }
        }

    }
}
