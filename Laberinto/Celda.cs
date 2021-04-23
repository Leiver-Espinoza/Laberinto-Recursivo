using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    class Celda
    {
        /*
         * Las celdas contienen dos secciones importantes:
         *      1. Los puntos cardinales que corresponden a una dirección a tomar durante la navegación
         *      2. El valor de la celda
         *  
         *  Los puntos cardinales pueden tener cualquiera de estos valores, para cualquiera de las direcciones del laberinto:
         *      'B' = Indica que existe un borde o límite del laberinto
         *      'P' = Indica que existe una pared
         *      'C' = Indica que existe un camino
         *      
         *  El valor de la celda puede tener cualquiera de los siguientes valores
         *      'P' = Pendiente de ser visitada
         *      'V' = Indica que esa celda ya fue visitada
         *      'E' = Punto de entrada
         *      'S' = Punto de Salida
         */

        public const char BORDE = 'B';
        public const char PARED = 'P';
        public const char CAMINO = 'C';
        public const char PENDIENTE = 'P';
        public const char VISITADA = 'V';

        public char Norte { set; get; }
        public char Sur { set; get; }
        public char Este { set; get; }
        public char Oeste { set; get; }
        public char Estado { set; get; }
        public int CoordenadaY { set; get; }
        public int CoordenadaX { set; get; }

        public Celda()
        {
            this.Estado = ' ';
        }
        public Celda(int y, int x)
        {
            this.CoordenadaY = y;
            this.CoordenadaX = x;
            this.Norte = CAMINO;
            this.Sur = CAMINO;
            this.Este = CAMINO;
            this.Oeste = CAMINO;
            this.Estado = PENDIENTE;
        }
        public bool PuedeTomarRuta(char direccion)
        {
            switch (direccion)
            {
                case 'N': return this.Norte == CAMINO;
                case 'S': return this.Sur   == CAMINO;
                case 'E': return this.Este  == CAMINO;
                case 'O': return this.Oeste == CAMINO;
                default: return false;
            }
        }

        public void MarcarComoVisitada()
        {
            this.Estado = VISITADA;
        }

        public bool FueVisitada()
        {
            return this.Estado == VISITADA;
        }

        public void TirarPared(char direccion)
        {
            switch (direccion)
            {
                case 'N': this.Norte = CAMINO;  break;
                case 'S': this.Sur   = CAMINO;  break;
                case 'E': this.Este  = CAMINO;  break;
                case 'O': this.Oeste = CAMINO;  break;
            }
        }

        public void PonerPared(char direccion)
        {
            switch (direccion)
            {
                case 'N': this.Norte = PARED; break;
                case 'S': this.Sur = PARED; break;
                case 'E': this.Este = PARED; break;
                case 'O': this.Oeste = PARED; break;
            }
        }

        public void PonerBorde(char direccion)
        {
            switch (direccion)
            {
                case 'N': this.Norte = BORDE; break;
                case 'S': this.Sur = BORDE; break;
                case 'E': this.Este = BORDE; break;
                case 'O': this.Oeste = BORDE; break;
            }
        }
        public int PosiblesCaminos(int y, int x, int filas, int columnas)
        {
            return 
                (this.Norte == CAMINO && y != 0 ? 1 : 0) +
                (this.Sur == CAMINO && y != filas - 1 ? 1 : 0) +
                (this.Este == CAMINO && x != columnas - 1 ? 1 : 0) +
                (this.Oeste == CAMINO && x != 0 ? 1 : 0);
        }

    }
}
