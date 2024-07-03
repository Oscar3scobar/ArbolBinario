using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSTWebApp.Models
{
    public class Nodo<T> where T : IComparable
    {
        public T Valor { get; set; }
        public Nodo<T> Izquierdo { get; set; }
        public Nodo<T> Derecho { get; set; }

        public Nodo(T valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    public class ArbolBinario<T> where T : IComparable
    {
        public Nodo<T> Raiz { get; private set; }

        public ArbolBinario()
        {
            Raiz = null;
        }

        public void Insertar(T valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private Nodo<T> InsertarRecursivo(Nodo<T> nodo, T valor)
        {
            if (nodo == null)
            {
                return new Nodo<T>(valor);
            }

            if (valor.CompareTo(nodo.Valor) < 0)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
            }
            else
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
            }

            return nodo;
        }

    }
}
