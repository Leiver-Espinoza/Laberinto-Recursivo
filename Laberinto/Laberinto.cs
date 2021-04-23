using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Laberinto
{
    class Laberinto
    {
        private readonly Pen plumaPared = new Pen(Color.Yellow, 3);
        private readonly Pen plumaBorrador = new Pen(Color.Black, 3);
        private readonly Pen plumaBorde = new Pen(Color.DarkCyan, 3);
        private readonly Pen plumaCamino = new Pen(Color.Black, 3);
        private readonly int tiempoEsperaDibujo = 10;
        private readonly int tiempoEsperaSolucionando = 200;

        private Graphics g;
        private PictureBox myPictureBox;
        private Bitmap dibujo;
        private bool division50;

        public bool Generado { get; set; }
        private Celda[,] laberinto;
        private Pila solucion;
        private int dimensionCelda;
        private int filas;
        private int columnas;
        private bool resuelto;
        public Laberinto()
        {
            this.filas = 0;
            this.columnas = 0;
            this.Generado = false;
        }
        public Laberinto(int filas, int columnas, ref Bitmap dibujo, ref PictureBox myPictureBox, bool division50)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.dibujo = dibujo;
            this.myPictureBox = myPictureBox;
            this.division50 = division50;
            this.dimensionCelda = Math.Min(
                (int)(this.myPictureBox.Width / columnas),
                (int)(this.myPictureBox.Height / filas)
            );

            this.laberinto = new Celda[filas, columnas];
            this.InicializarCeldas(filas, columnas);

            CrearLaberinto(filas,columnas);
            DibujarLaberinto();
            this.Generado = true;
            this.solucion = new Pila();
            this.solucion.Insertar(laberinto[0, 0]);
            this.resuelto = this.Resolver(0, 0);
            if (this.resuelto)
            {
                this.InvertirPila();
            }
            else
            {
                MessageBox.Show(
                    "No se ha logrado encontrar una solución viable",
                    "Ooops",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
        public void InicializarCeldas(int filas, int columnas)
        {
            for (int y = 0; y < filas; y++)
                for (int x = 0; x < columnas; x++)
                {
                    laberinto[y, x] = new Celda(y, x);
                }
            laberinto[0, 0].Estado = 'E';
            laberinto[filas - 1, columnas - 1].Estado = 'S';
        }
        public void CrearLaberinto(int filas, int columnas)
        {
            g = Graphics.FromImage(this.dibujo);
            g.DrawRectangle(
                plumaPared,
                0,
                0,
                columnas * dimensionCelda,
                filas * dimensionCelda);
            CrearLaberintoRecursivo(0, 0, filas-1, columnas-1,0);
            for (int y = 0; y < this.filas ; y++)
            {
                this.laberinto[y, 0].PonerBorde('O');
                this.laberinto[y, columnas - 1].PonerBorde('E');
            }
            for (int x = 0; x < columnas; x++)
            {
                this.laberinto[0, x].PonerBorde('N');
                this.laberinto[filas - 1, x].PonerBorde('S');
            }
            g.Dispose();
        }
        private void CrearLaberintoRecursivo(int yInicio, int xInicio, int yFinal, int xFinal, byte tipoCorte)
        {
            /*
             * tipoCorte = 0 = Horizontal
             * tipoCorte = 1 = Vertical
             */
            Random random = new Random();
            int ancho = xFinal - xInicio;
            int altura = yFinal - yInicio;
            int divisionVertical;
            int divisionHorizontal;
            int posicion;

            if ((tipoCorte == 0) && (altura < 1))
            {
                return;
            }
            
            if (tipoCorte == 0)
            {
                if (this.division50)
                {
                    divisionHorizontal = (yInicio + yFinal) / 2;
                }
                else
                {
                    divisionHorizontal = random.Next(yInicio, yFinal);
                }
                
                PonerParedesHorizontales(divisionHorizontal, xInicio, xFinal);
                posicion = random.Next(xInicio, xFinal);
                TirarParedHorizontal(divisionHorizontal, posicion);
                CrearLaberintoRecursivo(yInicio, xInicio, divisionHorizontal, xFinal, 1);
                CrearLaberintoRecursivo(divisionHorizontal + 1, xInicio, yFinal, xFinal, 1);
            }

            if ((tipoCorte == 1) && (ancho < 1))
            {
                return;
            }

            if (tipoCorte == 1)
            {
                if (this.division50)
                {
                    divisionVertical = (xInicio + xFinal) / 2;
                }
                else
                {
                    divisionVertical = random.Next(xInicio, xFinal);
                }
                
                PonerParedesVerticales(divisionVertical, yInicio, yFinal);
                posicion = random.Next(yInicio, yFinal);
                TirarParedVertical(posicion, divisionVertical);
                CrearLaberintoRecursivo(yInicio, xInicio, yFinal, divisionVertical, 0);
                CrearLaberintoRecursivo(yInicio, divisionVertical + 1, yFinal, xFinal, 0);
            }
        }
        private void PonerParedesVerticales(int divisionVertical, int yInicio, int yFinal)
        {
            this.g = Graphics.FromImage(this.dibujo);
            this.myPictureBox.Image = dibujo;
            for (int y = yInicio; y <= yFinal; y++)
            {
                laberinto[y, divisionVertical].PonerPared('E');
                laberinto[y, divisionVertical + 1].PonerPared('O');
                DibujarLinea(this.g, this.plumaPared, y, divisionVertical, 'E', 0);
            }
            this.myPictureBox.Refresh();
            this.g.Dispose();
        }
        private void PonerParedesHorizontales(int divisionHorizontal, int xInicio, int xFinal)
        {
            this.g = Graphics.FromImage(this.dibujo);
            this.myPictureBox.Image = dibujo;
            for (int x = xInicio; x <= xFinal; x++)
            {
                laberinto[divisionHorizontal, x].PonerPared('S');
                laberinto[divisionHorizontal + 1, x].PonerPared('N');
                DibujarLinea(this.g, this.plumaPared, divisionHorizontal, x, 'S', 0);
            }
            this.myPictureBox.Refresh();
            this.g.Dispose();
        }
        private void TirarParedHorizontal(int fila, int columna)
        {
            this.g = Graphics.FromImage(this.dibujo);
            this.myPictureBox.Image = dibujo;
            laberinto[fila, columna].TirarPared('S');
            laberinto[fila + 1, columna].TirarPared('N');
            DibujarLinea(this.g, this.plumaBorrador, fila, columna, 'S',0);
            this.myPictureBox.Refresh();
            this.g.Dispose();
        }
        private void TirarParedVertical(int fila, int columna)
        {
            this.g = Graphics.FromImage(this.dibujo);
            this.myPictureBox.Image = dibujo;
            laberinto[fila, columna].TirarPared('E');
            laberinto[fila, columna + 1].TirarPared('O');
            DibujarLinea(this.g, this.plumaBorrador, fila, columna, 'E',0);
            this.myPictureBox.Refresh();
            this.g.Dispose();
        }
        private void DibujarLinea(Graphics g, Pen pluma, int y, int x, char puntoCardinal, int span)
        {
            int y1 = 0;
            int y2 = 0;
            int x1 = 0;
            int x2 = x1;
            switch (puntoCardinal)
            {
                case 'E':
                    y1 = (y * this.dimensionCelda) + span;
                    y2 = y1 + this.dimensionCelda - span;
                    x1 = (x * this.dimensionCelda) + this.dimensionCelda;
                    x2 = x1;
                    break;
                case 'S':
                    y1 = (y * this.dimensionCelda) + this.dimensionCelda;
                    y2 = y1;
                    x1 = (x * this.dimensionCelda) + span;
                    x2 = x1 + this.dimensionCelda - span;
                    break;
            }
            System.Threading.Thread.Sleep(this.tiempoEsperaDibujo);

            this.g.DrawLine(pluma, x1, y1, x2, y2);

        }
        private void DibujarPared(Graphics g, int y, int x, char puntoCardinal)
        {
            int y1 = 0;
            int y2 = 0;
            int x1 = 0;
            int x2 = 0;
            Pen tmpPluma = this.plumaBorde;
            switch (puntoCardinal)
            {
                case 'N':
                    y1 = y * this.dimensionCelda;
                    y2 = y1;
                    x1 = x * this.dimensionCelda;
                    x2 = x1 + this.dimensionCelda;
                    if (this.laberinto[y, x].Norte == Celda.CAMINO)
                    {
                        tmpPluma = this.plumaCamino;
                    }
                    break;
                case 'S':
                    y1 = (y * this.dimensionCelda) + this.dimensionCelda;
                    y2 = y1;
                    x1 = x * this.dimensionCelda;
                    x2 = x1 + this.dimensionCelda;
                    if (this.laberinto[y, x].Sur == Celda.CAMINO)
                    {
                        tmpPluma = this.plumaCamino;
                    }
                    break;
                case 'E':
                    y1 = y * this.dimensionCelda;
                    y2 = y1 + this.dimensionCelda;
                    x1 = (x * this.dimensionCelda) + this.dimensionCelda;
                    x2 = x1;
                    if (this.laberinto[y, x].Este == Celda.CAMINO)
                    {
                        tmpPluma = this.plumaCamino;
                    }
                    break;
                case 'O':
                    y1 = y * this.dimensionCelda;
                    y2 = y1 + this.dimensionCelda;
                    x1 = x * this.dimensionCelda;
                    x2 = x1;
                    if (this.laberinto[y, x].Oeste == Celda.CAMINO)
                    {
                        tmpPluma = this.plumaCamino;
                    }
                    break;
            }
            if (tmpPluma.Color != this.plumaCamino.Color)
            {
                this.g.DrawLine(this.plumaBorde, x1, y1, x2, y2);
            }

        }
        public void DibujarLaberinto()
        {
            this.dibujo = new Bitmap(this.myPictureBox.Size.Width, this.myPictureBox.Size.Height);
            this.myPictureBox.Image = this.dibujo;
            this.dimensionCelda = Math.Min(
                (int)(this.myPictureBox.Width / columnas),
                (int)(this.myPictureBox.Height / filas)
            );

            this.g = Graphics.FromImage(this.dibujo);
            this.myPictureBox.Image = dibujo;
            this.g.Clear(Color.Black);

            for (int y = 0; y < filas; y++)
            {
                for (int x = 0; x < columnas; x++)
                {
                    DibujarPared(this.g, y, x, 'N');
                    DibujarPared(this.g, y, x, 'S');
                    DibujarPared(this.g, y, x, 'E');
                    DibujarPared(this.g, y, x, 'O');
                }
            }
            try
            {
                this.myPictureBox.Refresh();
            }
            catch
            {

            }
            g.Dispose();
            CrearPuntoInicio();
            CrearPuntoFinal();
            if (this.resuelto)
            {
                DibujarSolucion();
            }
        }
        public void CrearPuntoInicio()
        {
            this.g = Graphics.FromImage(this.dibujo);
            this.myPictureBox.Image = dibujo;
            SolidBrush myBrush = new SolidBrush(Color.Green);
            g.FillEllipse(myBrush, new Rectangle(
                this.dimensionCelda / 4,
                this.dimensionCelda / 4,
                this.dimensionCelda / 2,
                this.dimensionCelda / 2));
            myBrush.Dispose();
            this.myPictureBox.Refresh();
            this.g.Dispose();
        }
        public void CrearPuntoFinal()
        {
            this.g = Graphics.FromImage(this.dibujo);
            this.myPictureBox.Image = dibujo;
            SolidBrush myBrush = new SolidBrush(Color.Red);
            g.FillEllipse(myBrush, new Rectangle(
                ((this.columnas - 1) * this.dimensionCelda) + this.dimensionCelda / 4, 
                ((this.filas - 1) * this.dimensionCelda) + this.dimensionCelda / 4,
                this.dimensionCelda / 2,
                this.dimensionCelda / 2));
            myBrush.Dispose();
            this.myPictureBox.Refresh();
            this.g.Dispose();
        }
        public bool Resolver(int fila, int columna)
        {
            bool resuelto = false;
            if (laberinto[fila,columna].Estado == 'S')
            {
                return true;
            }
            else
            {
                laberinto[fila, columna].MarcarComoVisitada();
                if (!resuelto &&
                    laberinto[fila,columna].PuedeTomarRuta('E') &&
                    !laberinto[fila, columna + 1].FueVisitada())
                {
                    this.solucion.Insertar(laberinto[fila, columna + 1]);
                    resuelto = this.Resolver(fila, columna + 1);
                    if (!resuelto)
                    {
                        this.solucion.Eliminar();
                    }
                }
                if (!resuelto &&
                    laberinto[fila, columna].PuedeTomarRuta('S') &&
                    !laberinto[fila + 1, columna].FueVisitada())
                {
                    this.solucion.Insertar(laberinto[fila + 1, columna]);
                    resuelto = this.Resolver(fila + 1, columna);
                    if (!resuelto)
                    {
                        this.solucion.Eliminar();
                    }
                }
                if (!resuelto &&
                    laberinto[fila, columna].PuedeTomarRuta('O') &&
                    !laberinto[fila, columna - 1].FueVisitada())
                {
                    this.solucion.Insertar(laberinto[fila, columna - 1]);
                    resuelto = this.Resolver(fila, columna - 1);
                    if (!resuelto)
                    {
                        this.solucion.Eliminar();
                    }
                }
                if (!resuelto &&
                    laberinto[fila, columna].PuedeTomarRuta('N') &&
                    !laberinto[fila - 1, columna].FueVisitada())
                {
                    this.solucion.Insertar(laberinto[fila - 1, columna]);
                    resuelto = this.Resolver(fila - 1, columna);
                    if (!resuelto)
                    {
                        this.solucion.Eliminar();
                    }
                }

                // Se retorna la resolución final del laberinto con TRUE si encontró la salida o FALSE en caso contrario
                return resuelto;
            }
        }
        private void InvertirPila()
        {
            Pila tmpPila = new Pila();
            Pila tmpPilaSolucion = new Pila();
            tmpPilaSolucion = this.solucion;
            while (!tmpPilaSolucion.EstaVacia())
            {
                tmpPila.Insertar(tmpPilaSolucion.Extraer());
            }
            this.solucion = tmpPila;
        }
        private void DibujarSolucion()
        {
            Pila.Nodo nodoOrigen = solucion.GetPrimerNodo();
            Pila.Nodo nodoDestino = solucion.GetPrimerNodo().puntero;
            this.g = Graphics.FromImage(this.dibujo);
            Pen plumaRuta = new Pen(Color.Yellow, this.dimensionCelda / 10);
            do
            {
                this.g.DrawLine(
                    plumaRuta,
                    (nodoOrigen.celda.CoordenadaX * this.dimensionCelda) + (this.dimensionCelda/2),
                    (nodoOrigen.celda.CoordenadaY * this.dimensionCelda) + (this.dimensionCelda / 2),
                    (nodoDestino.celda.CoordenadaX * this.dimensionCelda) + (this.dimensionCelda / 2),
                    (nodoDestino.celda.CoordenadaY * this.dimensionCelda) + (this.dimensionCelda / 2));
                nodoOrigen = nodoDestino;
                nodoDestino = nodoDestino.puntero;
                System.Threading.Thread.Sleep(this.tiempoEsperaSolucionando);
                this.myPictureBox.Refresh();
            } while (nodoDestino.celda.Estado != 'S');
            this.g.DrawLine(
                plumaRuta,
                (nodoOrigen.celda.CoordenadaX * this.dimensionCelda) + (this.dimensionCelda / 2),
                (nodoOrigen.celda.CoordenadaY * this.dimensionCelda) + (this.dimensionCelda / 2),
                (nodoDestino.celda.CoordenadaX * this.dimensionCelda) + (this.dimensionCelda / 2),
                (nodoDestino.celda.CoordenadaY * this.dimensionCelda) + (this.dimensionCelda / 2));
            this.myPictureBox.Refresh();
            this.g.Dispose();
        }
    }
}
