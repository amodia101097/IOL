using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Calculo
    {
        private int TotalCantidad;

        public int totalCantidad
        {
            get { return TotalCantidad; }
            set { TotalCantidad = value; }
        }

        private decimal TotalPerimetro;

        public decimal totalPerimetro
        {
            get { return TotalPerimetro; }
            set { TotalPerimetro = value; }
        }

        private decimal TotalArea;

        public decimal totalArea
        {
            get { return TotalArea; }
            set { TotalArea = value; }
        }

        private int TotalError;

        public int totalError
        {
            get { return TotalError; }
            set { TotalError = value; }
        }


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
            Cuadrado ObjCuadrado = new Cuadrado(0, 0);
            Circulo ObjCirculo = new Circulo(0, 0);
            TrianguloEquilatero ObjTriangulo = new TrianguloEquilatero(0, 0);
            Trapecio ObjTrapecio = new Trapecio(0, 0, 0, 0);
            Rectangulo ObjRectangulo = new Rectangulo(0, 0, 0);

            Calculo totalCuadrado = ObjCuadrado.ImprimirTotal(formas, Print.cuadrado);
            Calculo totalCirculo = ObjCirculo.ImprimirTotal(formas, Print.circulo);
            Calculo totalTriangulo = ObjTriangulo.ImprimirTotal(formas, Print.trianguloEquilatero);
            Calculo totalTrapecio = ObjTrapecio.ImprimirTotal(formas, Print.trapecio);
            Calculo totalRectangulo = ObjRectangulo.ImprimirTotal(formas, Print.rectangulo);

            Total.totalCantidad = totalCuadrado.totalCantidad + totalCirculo.totalCantidad + totalTriangulo.totalCantidad + totalTrapecio.totalCantidad + totalRectangulo.totalCantidad;
            Total.totalArea = totalCuadrado.totalArea + totalCirculo.totalArea + totalTriangulo.totalArea + totalTrapecio.totalArea + totalRectangulo.totalArea;
            Total.totalPerimetro = totalCuadrado.totalPerimetro + totalCirculo.totalPerimetro + totalTriangulo.totalPerimetro + totalTrapecio.totalPerimetro + totalRectangulo.totalPerimetro;

            return Total;
        }

        public static Calculo TotalFormaError(List<FormaGeometrica> formas)
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
