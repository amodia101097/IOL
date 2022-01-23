using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodingChallenge.Data.Classes
{
    public class Print
    {

        #region Formas

        public const int cuadrado = 1;
        public const int trianguloEquilatero = 2;
        public const int circulo = 3;
        public const int trapecio = 4;
        public const int rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        #endregion



        public static string PrintMain(List<FormaGeometrica> formas, Idioma idioma)
        {
            var sb = new StringBuilder();

            // Si el idioma ingresado es incorrecto se utilizara el ingles por defecto avisandole al usuario
            
            sb.Append(ImprimirErrorIdioma(idioma));

            // No hay nnguna forma
           
            if (!formas.Any())
                sb.Append(ImprimirVacio(idioma));

            // Hay por lo menos una forma
            
            else
            {
                // HEADER
                
                sb.Append(ImprimirHeader(idioma));

                //BODY

                sb.Append(ImprimirBody(formas, idioma));

                // FOOTER

                sb.Append(ImprimirFooter(formas, idioma));


            }

            return sb.ToString();
        }

        private static string ImprimirErrorIdioma(Idioma idioma)
        {
            if (idioma.ID_idioma != Castellano && idioma.ID_idioma != Ingles && idioma.ID_idioma != Italiano)
                return ("<h1>Error, the language entered is not correct. English is used by default </h1>");

            return string.Empty;
        }

        private static string ImprimirVacio(Idioma idioma)
        {
            return Traduccion.TraducirVacio(idioma);
        }

        private static string ImprimirHeader(Idioma idioma)
        {

            return Traduccion.TraducirHeader(idioma);

        }

        private static string ImprimirBody(List<FormaGeometrica> formas, Idioma idioma)
        {
            var body = new StringBuilder();

            body.Append(Cuadrado.ImprimirCalculo(formas, cuadrado, idioma));
            body.Append(Circulo.ImprimirCalculo(formas, circulo, idioma));
            body.Append(TrianguloEquilatero.ImprimirCalculo(formas, trianguloEquilatero, idioma));
            body.Append(Trapecio.ImprimirCalculo(formas, trapecio, idioma));
            body.Append(Rectangulo.ImprimirCalculo(formas, rectangulo, idioma));

            return body.ToString();


        }

        private static string ImprimirFooter(List<FormaGeometrica> formas, Idioma idioma)
        {
            var footer = new StringBuilder();
            Calculo total = Calculo.Total(formas);

            footer.Append(Traduccion.TraducirFooter(formas, idioma));

            return footer.ToString();
        }


    }
}