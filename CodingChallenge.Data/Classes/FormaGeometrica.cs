/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {

        private decimal lado;

        public decimal Lado
        {
            get { return lado; }
            set { lado = value; }
        }

        private int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private decimal altura;
        public decimal Altura 
        {
            get { return altura; }
            set { altura = value; }
        }

        private decimal baseMayor;

        public decimal BaseMayor
        {
            get { return baseMayor; }
            set { baseMayor = value; }
        }

        private decimal baseMenor;

        public decimal BaseMenor
        {
            get { return baseMenor; }
            set { baseMenor = value; }
        }

        private decimal baseBase;

        public decimal Base
        {
            get { return baseBase; }
            set { baseBase = value; }
        }


        public FormaGeometrica(int Tipo, decimal Lado)
        {
            this.Tipo = Tipo;
            this.Lado = Lado;
        }



        public virtual Calculo ImprimirTotal(List<FormaGeometrica> formas, int Tipo)
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
        public virtual string ImprimirCalculo(List<FormaGeometrica> formas, int Tipo, Idioma idioma)
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

            return ObtenerLinea(idioma, numero, area, perimetro, Tipo);
        }

        public virtual string ObtenerLinea(Idioma idioma, int Cantidad, decimal Area, decimal Perimetro, int tipo)
        {
            if (Cantidad > 0)
            {
                if (idioma.IDIdioma == Print.Castellano)
                    return $"{Cantidad} {TraducirForma(Cantidad, idioma)} | Area {Area.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} | Perimetro {Perimetro.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} <br/>";
                else if (idioma.IDIdioma == Print.Italiano)
                    return $"{Cantidad} {TraducirForma(Cantidad, idioma)} | La zona {Area.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} | Perimetro {Perimetro.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} <br/>";
                else
                    return $"{Cantidad} {TraducirForma(Cantidad, idioma)} | Area {Area.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} | Perimeter {Perimetro.ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR"))} <br/>";

            }

            return string.Empty;
        }

        public virtual string TraducirForma(int Cantidad, Idioma idioma)
        {

            return string.Empty;
        }
        public virtual decimal CalcularArea(FormaGeometrica forma)
        {
            return 0;
        }

        public virtual decimal CalcularPerimetro(FormaGeometrica forma)
        {
            return 0;
        }
    }
}
