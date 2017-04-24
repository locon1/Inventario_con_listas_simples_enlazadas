using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_2._0
{
    class Inventario
    {
        private Producto primero;
        private int _cont;
        public int cont { get { return _cont; } }

        public Inventario()
        {
            primero = null;
            _cont = 0;
        }

        public void Agregar(Producto nuevo)
        {
            if (primero == null) 
            {
                primero = nuevo;
                _cont++;
            }
            else 
            {
                Producto temp = primero;
                while (temp.siguiente != null) 
                {
                    temp = temp.siguiente;
                }
                temp.siguiente = nuevo;
                _cont++;
            }
        }

        public void agregaralInicio(Producto nuevo)
        {
            if (primero == null) 
            {
                primero = nuevo;
                _cont++;
            }
            else
            {
                nuevo.siguiente = primero;
                _cont++;
            }
        }

        public bool Eliminar(string name)
        {
            if (primero.nombre == name) 
            {
                primero = primero.siguiente;
                return true;
            }
            else 
            {
                Producto temp = primero;
                while (temp.siguiente.nombre != name && temp.siguiente != null) 
                {
                    temp = temp.siguiente;
                }

                if (temp.siguiente.nombre == name) 
                {
                    temp.siguiente = temp.siguiente.siguiente;
                    _cont--;
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }

        public Producto Buscar(string name)
        {
            Producto temp = primero;
            while (temp.nombre != name && temp.siguiente != null) 
            {
                temp = temp.siguiente;
            }

            if (temp.nombre == name) 
            {
                return temp;
            }
            else 
            {
                return null;
            }
        }

        public bool Insertar(Producto nuevo, int posicion)
        {
            if (posicion <= _cont) 
            {
                if (posicion == 1) 
                {
                    nuevo.siguiente = primero;
                }
                else 
                {
                    Producto temp = primero;
                    int aux = 1;
                    while (aux < _cont) 
                    {
                        if (aux == posicion - 1) 
                        {
                            Producto x = temp.siguiente;
                            temp.siguiente = nuevo;
                            temp.siguiente.siguiente = x;
                        }
                        else
                        {
                            temp = temp.siguiente;
                        }
                        aux++;
                    }
                }
                _cont++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Reporte()
        {
            string salida = "Número de productos en el inventario: " + _cont + Environment.NewLine + Environment.NewLine + "Inventario: " + Environment.NewLine + Environment.NewLine;
            Producto temp = primero;
            while (temp != null) 
            {
                salida += temp.ToString() + Environment.NewLine;
                salida += "---------------------------------------------------------------------------" + Environment.NewLine;
                temp = temp.siguiente;
            }
            return salida;
        }
    }
}
