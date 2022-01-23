using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Calculo
    {

        public int totalCantidad { get; set; }
        public decimal totalPerimetro { get; set; }
        public decimal totalArea { get; set; }

        public int totalError { get; set; }

        public Calculo(int totalError)
        {
            this.totalError = totalError;
        }

        public Calculo(int totalCantidad, decimal totalPerimetro, decimal totalArea)
        {
            this.totalCantidad = totalCantidad;
            this.totalPerimetro = totalPerimetro;
            this.totalArea = totalArea;
        }


        public static Calculo Total(List<FormaGeometrica> formas)
        {
            Calculo Total = new Calculo(0, 0m, 0m);

            Calculo totalCuadrado = Cuadrado.ImprimirTotal(formas, Print.cuadrado);
            Calculo totalCirculo = Circulo.ImprimirTotal(formas, Print.circulo);
            Calculo totalTriangulo = TrianguloEquilatero.ImprimirTotal(formas, Print.trianguloEquilatero);
            Calculo totalTrapecio = Trapecio.ImprimirTotal(formas, Print.trapecio);
            Calculo totalRectangulo = Rectangulo.ImprimirTotal(formas, Print.rectangulo);

            Total.totalCantidad = totalCuadrado.totalCantidad + totalCirculo.totalCantidad + totalTriangulo.totalCantidad + totalTrapecio.totalCantidad + totalRectangulo.totalCantidad;
            Total.totalArea = totalCuadrado.totalArea + totalCirculo.totalArea + totalTriangulo.totalArea + totalTrapecio.totalArea + totalRectangulo.totalArea;
            Total.totalPerimetro = totalCuadrado.totalPerimetro + totalCirculo.totalPerimetro + totalTriangulo.totalPerimetro + totalTrapecio.totalPerimetro + totalRectangulo.totalPerimetro;

            return Total;
        }

        public static Calculo TotalError(List<FormaGeometrica> formas)
        {
            Calculo TotalError = new Calculo(0);

            for (var i = 0; i < formas.Count; i++)
            {
                if (formas[i].Tipo != Print.cuadrado && formas[i].Tipo != Print.circulo && formas[i].Tipo != Print.trianguloEquilatero && formas[i].Tipo != Print.trapecio && formas[i].Tipo != Print.rectangulo)
                {
                    TotalError.totalError++;

                }
            }

            return TotalError;
        }


    }
}
