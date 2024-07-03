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

        public Nodo<T> Buscar(T valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }

        private Nodo<T> BuscarRecursivo(Nodo<T> nodo, T valor)
        {
            if (nodo == null || nodo.Valor.CompareTo(valor) == 0)
            {
                return nodo;
            }

            if (valor.CompareTo(nodo.Valor) < 0)
            {
                return BuscarRecursivo(nodo.Izquierdo, valor);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecho, valor);
            }
        }


        public List<T> InOrden()
        {
            List<T> result = new List<T>();
            InOrden(Raiz, result);
            return result;
        }

        private void InOrden(Nodo<T> nodo, List<T> result)
        {
            if (nodo == null) return;
            InOrden(nodo.Izquierdo, result);
            result.Add(nodo.Valor);
            InOrden(nodo.Derecho, result);
        }

        public List<T> PreOrden()
        {
            List<T> result = new List<T>();
            PreOrden(Raiz, result);
            return result;
        }

        private void PreOrden(Nodo<T> nodo, List<T> result)
        {
            if (nodo == null) return;
            result.Add(nodo.Valor);
            PreOrden(nodo.Izquierdo, result);
            PreOrden(nodo.Derecho, result);
        }

        public List<T> PostOrden()
        {
            List<T> result = new List<T>();
            PostOrden(Raiz, result);
            return result;
        }

        private void PostOrden(Nodo<T> nodo, List<T> result)
        {
            if (nodo == null) return;
            PostOrden(nodo.Izquierdo, result);
            PostOrden(nodo.Derecho, result);
            result.Add(nodo.Valor);
        }
        public T Maximo()
        {
            if (Raiz == null) throw new InvalidOperationException("El árbol está vacío.");
            Nodo<T> current = Raiz;
            while (current.Derecho != null)
            {
                current = current.Derecho;
            }
            return current.Valor;
        }

        public T Minimo()
        {
            if (Raiz == null) throw new InvalidOperationException("El árbol está vacío.");
            Nodo<T> current = Raiz;
            while (current.Izquierdo != null)
            {
                current = current.Izquierdo;
            }
            return current.Valor;
        }

    }
}
