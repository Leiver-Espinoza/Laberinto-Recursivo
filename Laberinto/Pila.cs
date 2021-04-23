using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    class Pila
    {
        public class Nodo
        {
            public Celda celda;
            public Nodo puntero;
        }

        private Nodo inicio;

        public Pila()
        {
            inicio = null;
        }

        public void Insertar(Celda tmpCelda)
        {
            Nodo tmpNodo = new Nodo();
            tmpNodo.celda = tmpCelda;
            if (this.inicio == null)
            {
                tmpNodo.puntero = null;
                inicio = tmpNodo;
            }
            else
            {
                tmpNodo.puntero = inicio;
                inicio = tmpNodo;
            }
        }

        public Celda Extraer()
        {
            Celda tmpCelda = null;
            if (inicio != null)
            {
                tmpCelda = inicio.celda;
                this.Eliminar();
            }
            return tmpCelda;
        }
        public void Eliminar()
        {
            if (inicio != null)
            {
                inicio = inicio.puntero;
            }
        }

        public bool EstaVacia()
        {
            return this.inicio == null;
        }

        public Nodo GetPrimerNodo()
        {
            return this.inicio;
        }
    }
}
