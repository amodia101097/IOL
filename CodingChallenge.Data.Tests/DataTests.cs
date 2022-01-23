using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;


namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        Idioma Castellano = new Idioma("Castellano", 1);
        Idioma Ingles = new Idioma("Ingles", 2);
        Idioma Italiano = new Idioma("Italiano", 3);
        Idioma Error = new Idioma("Error", -1);



        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Main.Imprimir(new List<FormaGeometrica>(), Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Main.Imprimir(new List<FormaGeometrica>(), Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                Main.Imprimir(new List<FormaGeometrica>(), Italiano));
        }


        [TestCase]
        public void TestResumenListaVaciaFormasErrorIdioma()
        {
            Assert.AreEqual("<h1>Error, the language entered is not correct. English is used by default </h1><h1>Empty list of shapes!</h1>",
                Main.Imprimir(new List<FormaGeometrica>(), Error));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new Cuadrado(Print.cuadrado, 5)};

            var resumen = Main.Imprimir(cuadrados, Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var  Trapecios = new List<FormaGeometrica> { new Trapecio(Print.trapecio,2,4,6) };

            var resumen = Main.Imprimir(Trapecios, Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 10 | Perimetro 14 <br/>TOTAL:<br/>1 formas Perimetro 14 Area 10", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCuadradoEnItaliano()
        {
            var cuadrados = new List<FormaGeometrica> { new Cuadrado(Print.cuadrado, 5) };

            var resumen = Main.Imprimir(cuadrados, Italiano);

            Assert.AreEqual("<h1>Rapporto sulle forme</h1>1 Quadrato | La zona 25 | Perimetro 20 <br/>TOTALE:<br/>1 forme Perimetro 20 La zona 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectanguloEnItaliano()
        {
            var cuadrados = new List<FormaGeometrica> { new Rectangulo(Print.rectangulo, 5, 10) };

            var resumen = Main.Imprimir(cuadrados, Italiano);

            Assert.AreEqual("<h1>Rapporto sulle forme</h1>1 rettangolo | La zona 50 | Perimetro 30 <br/>TOTALE:<br/>1 forme Perimetro 30 La zona 50", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Cuadrado(Print.cuadrado, 1),
                new Cuadrado(Print.cuadrado, 3)
            };

            var resumen = Main.Imprimir(cuadrados, Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTrapecios()
        {
            var trapecios = new List<FormaGeometrica>
            {
                new Trapecio(Print.trapecio,2,4,6),
                new Trapecio(Print.trapecio,8,10,12),
                new Trapecio(Print.trapecio,8,2,11),
                new Trapecio(Print.trapecio,1,3,5),
                new Trapecio(Print.trapecio,1,2,3)
            };

            var resumen = Main.Imprimir(trapecios, Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>5 trapezes | Area 156,5 | Perimeter 98 <br/>TOTAL:<br/>5 shapes Perimeter 98 Area 156,5", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m),
            };

            var resumen = Main.Imprimir(formas, Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConFormaGeometricaErronea()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m),
                new Circulo(-1, 4.2m)
            };

            var resumen = Main.Imprimir(formas, Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65<br> Error, there is 1 shape entered incorrectly <br/>",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConFormasGeometricasErroneas()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m),
                new Circulo(-3, 4.2m),
                new Cuadrado(-2, 9),
                new TrianguloEquilatero(-1, 4.2m)
            };

            var resumen = Main.Imprimir(formas, Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65<br> Error, hay 3 formas ingresadas de forma incorecta <br/>",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m)
            };

            var resumen = Main.Imprimir(formas, Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>2 Quadrados | La zona 29 | Perimetro 28 <br/>2 Cerchi | La zona 13,01 | Perimetro 18,06 <br/>3 triangoli | La zona 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>7 forme Perimetro 97,66 La zona 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m)
            };

            var resumen = Main.Imprimir(formas, Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposIncluidoTrapecioEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m),
                new Trapecio(Print.trapecio,2,4,6),
                new Trapecio(Print.trapecio,1,3,5)
            };

            var resumen = Main.Imprimir(formas, Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>2 Quadrados | La zona 29 | Perimetro 28 <br/>2 Cerchi | La zona 13,01 | Perimetro 18,06 <br/>3 triangoli | La zona 49,64 | Perimetro 51,6 <br/>2 trapezi | La zona 14 | Perimetro 24 <br/>TOTALE:<br/>9 forme Perimetro 121,66 La zona 105,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTodosLosTiposIncluidoRectanguloEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m),
                new Trapecio(Print.trapecio,2,4,6),
                new Trapecio(Print.trapecio,1,3,5),
                new Rectangulo(Print.rectangulo,5,10),
                new Rectangulo(Print.rectangulo,2,5)

            };

            var resumen = Main.Imprimir(formas, Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sulle forme</h1>2 Quadrados | La zona 29 | Perimetro 28 <br/>2 Cerchi | La zona 13,01 | Perimetro 18,06 <br/>3 triangoli | La zona 49,64 | Perimetro 51,6 <br/>2 trapezi | La zona 14 | Perimetro 24 <br/>2 rettangoli | La zona 60 | Perimetro 44 <br/>TOTALE:<br/>11 forme Perimetro 165,66 La zona 165,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposErrorIdioma()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(Print.cuadrado, 5),
                new Circulo(Print.circulo, 3),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4),
                new Cuadrado(Print.cuadrado, 2),
                new TrianguloEquilatero(Print.trianguloEquilatero, 9),
                new Circulo(Print.circulo, 2.75m),
                new TrianguloEquilatero(Print.trianguloEquilatero, 4.2m)
            };

            var resumen = Main.Imprimir(formas, Error);

            Assert.AreEqual(
                 "<h1>Error, the language entered is not correct. English is used by default </h1><h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }
    }
}
