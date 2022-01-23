using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Traduccion
    {
        public static string TraducirVacio(Idioma idioma)
        {

            if (idioma.ID_idioma == Print.Castellano)
                return ("<h1>Lista vacía de formas!</h1>");
            else if (idioma.ID_idioma == Print.Italiano)
                return ("<h1>Elenco vuoto di forme!</h1>");
            else
                return ("<h1>Empty list of shapes!</h1>");

        }
        public static string TraducirHeader(Idioma idioma)
        {

            if (idioma.ID_idioma == Print.Castellano)
                return ("<h1>Reporte de Formas</h1>");
            else if (idioma.ID_idioma == Print.Italiano)
                return ("<h1>Rapporto sulle forme</h1>");
            else
                return ("<h1>Shapes report</h1>");

        }
        public static string TraducirFooter(List<FormaGeometrica> formas, Idioma idioma)
        {
            var footer = new StringBuilder();
            Calculo total = Calculo.Total(formas);

            if (idioma.ID_idioma == Print.Castellano)
            {
                footer.Append("TOTAL:<br/>");
                footer.Append(total.totalCantidad + " ");
                footer.Append("formas ");
                footer.Append(("Perimetro ") + (total.totalPerimetro).ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR")) + " " + "Area " + (total.totalArea).ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR")));
            }
            else if (idioma.ID_idioma == Print.Italiano)
            {
                footer.Append("TOTALE:<br/>");
                footer.Append(total.totalCantidad + " ");
                footer.Append("forme ");
                footer.Append(("Perimetro ") + (total.totalPerimetro).ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR")) + " " + "La zona " + (total.totalArea).ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR")));
            }
            else
            {
                footer.Append("TOTAL:<br/>");
                footer.Append(total.totalCantidad + " ");
                footer.Append("shapes ");
                footer.Append(("Perimeter ") + (total.totalPerimetro).ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR")) + " " + "Area " + (total.totalArea).ToString("#.##", CultureInfo.CreateSpecificCulture("es-AR")));
            }


            footer.Append(TraducirFooterErrorForma(formas, idioma));

            return footer.ToString();
        }

        private static string TraducirFooterErrorForma(List<FormaGeometrica> formas, Idioma idioma)
        {
            Calculo Error = Calculo.TotalError(formas);

            if (Error.totalError == 1)
            {
                if (idioma.ID_idioma == Print.Castellano)
                    return ("<br> Error, hay " + Error.totalError + " forma ingresada de forma incorecta <br/>");
                else if (idioma.ID_idioma == Print.Italiano)
                    return ("<br> Error, ci sono " + Error.totalError + " forme inserito in modo errato <br/>");
                else
                    return ("<br> Error, there is " + Error.totalError + " shape entered incorrectly <br/>");
            }

            if (Error.totalError > 1)
            {
                if (idioma.ID_idioma == Print.Castellano)
                    return ("<br> Error, hay " + Error.totalError + " formas ingresadas de forma incorecta <br/>");
                else if (idioma.ID_idioma == Print.Italiano)
                    return ("<br> Error, ci sono " + Error.totalError + " forme inseriti in modo errato <br/>");
                else
                    return ("<br> Error, there are " + Error.totalError + " shapes entered incorrectly <br/>");
            }

            return string.Empty;
        }



    }
}
