using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP4
{
    public class ListaEnlazada
    {
        public Nodo Primero { get; set; }
        public Nodo Ultimo { get; set; }

        public ListaEnlazada()
        {
            Primero = null;
            Ultimo = null;
        }

        public void Crear(Nodo nuevo)
        {
            if(Primero == null && Ultimo == null) // si los aputadores son nulos
            {
                Primero = nuevo; // se asigna el nodo nuevo a ambos apuntadores
                Ultimo = nuevo;
            }
            else
            {
                Insertar(nuevo);
            }
        }


        //INSERTAR DONDE VA 
        public void Insertar(Nodo nuevo)
        {
            if (Primero != null && Ultimo != null) // si los aputadores NO son nulos
            {

             //El nuevo es menor al primero (se coloca primero)
                if(nuevo.Cuenta < Primero.Cuenta)
                {
                   nuevo.Siguiente= Primero; 
                    Primero = nuevo;
                }
                //El nuevo es mayor al ULTIMO (se coloca al ultimo )
                if (nuevo.Cuenta > Ultimo.Cuenta)
                {
                    Ultimo.Siguiente = nuevo;
                    Ultimo = nuevo;
                }
                //Para ponerlo en el medio 
                if(nuevo.Cuenta > Primero.Cuenta && nuevo.Cuenta < Ultimo.Cuenta)
                {
                    //Recorremos los nodos con aux

                    Nodo anterior = null;
                    Nodo aux = Primero; //(es igual al nodo primero)

                    //mientras que el nodo nuevo sea mayor al primero entra  
                    while(nuevo.Cuenta > aux.Cuenta)
                    {
                        anterior = aux; //guardamos el valor del nodo que pasamos 

                        aux = aux.Siguiente; //señalamos al de adelante 

                    }

                    anterior.Siguiente = nuevo;
                    nuevo.Siguiente = aux;

                }
            }
            else
            {
                Crear(nuevo);// si esta vacio creamos 
            }
        }



        
        //LISTAR - IGUAL
        //Este método Listar recorre todos los nodos de una lista enlazada y
        //los almacena en una lista de tipo List<Nodo>
        public List<Nodo> Listar()
        {
            List<Nodo> movimientos = new List<Nodo>(); //Creamos la lista 1ro para almacenar todo
          
            Nodo auxiliar = Primero; //Creamos auxiliar para recorrer

                while (auxiliar != null)  //mientras que no sea nulo 
                {
                    movimientos.Add(auxiliar); // guardar el nodo en la lista
                    auxiliar = auxiliar.Siguiente; // avanza al siguiente
                }

            return movimientos;
        }




        //BUSCAR
        public Nodo Buscar(int cuentaBuscada)
        {
            Nodo auxiliar = Primero; // Creamos un nodo auxiliar para recorrer la lista

            // Recorremos toda la lista  Este ciclo while continúa ejecutándose mientras el nodo actual (representado por auxiliar) no sea null.
            while (auxiliar != null)
            {
                if (auxiliar.Cuenta == cuentaBuscada) // Si encontramos la cuenta buscada
                {
                    
                    return auxiliar; // Devolvemos el nodo encontrado  
                }

                auxiliar = auxiliar.Siguiente; // Avanzamos al siguiente nodo, pregunta si no es null y sigue igual
            }

            // Si no encontramos el nodo, retornamos null
            return null;
        }




        //ELIMINAR
        public Nodo Eliminar(int cuentaBuscada)
        {
            Nodo anterior = null; //Crea un puntero anterior que inicialmente es null, ya que no hay un nodo antes del primer nodo.
            Nodo auxiliar = Primero; //

            // Recorremos la lista hasta encontrar el nodo que queremos eliminar
            while (auxiliar != null)
            {
                if (auxiliar.Cuenta == cuentaBuscada) // Si encontramos la cuenta buscada
                {
                    if (anterior == null) // Si el anterior al encontrado es null (osea que seria el primero )
                    {
                        Primero = auxiliar.Siguiente; //Primero seria auxiliar que tmb es primero, pero apuntando al siguiente que seria 2, por ende no hay mas 1 
                    }
                    else
                    {
                        anterior.Siguiente = auxiliar.Siguiente; // Saltamos el nodo que queremos eliminar
                    }

                    // Si el nodo eliminado es el último nodo, actualizamos el puntero Ultimo
                    if (auxiliar == Ultimo)
                    {
                        Ultimo = anterior; //Hace que el ultimo pase a ser el anterior nodo 
                    }

                    return auxiliar; // Devolvemos el nodo encontrado y eliminado
                }

                anterior = auxiliar; // se actualiza anterior para que apunte al nodo actual.
                auxiliar = auxiliar.Siguiente; // Se mueve el puntero auxiliar al siguiente nodo en la lista
            }

            // Si no encontramos el nodo, retornamos null
            return null;
        }

        //Editar Nodo 
        
        public Nodo Editar(int cuentaBuscada, int nuevoCodigoSucursal, int nuevoTipoMovimiento, int nuevoImporte, DateTime nuevaFecha)//Traemos todo lo que queremos editar 
        {
            Nodo auxiliar = Primero; // Comenzamos desde el primer nodo

            // Buscamos el nodo que queremos editar
            while (auxiliar != null)
            {
                if (auxiliar.Cuenta == cuentaBuscada) // Si encontramos la cuenta
                {
                    // Actualizamos los valores
                    auxiliar.CodigoSucursal = nuevoCodigoSucursal;
                    auxiliar.TipoMovimiento = nuevoTipoMovimiento;
                    auxiliar.Importe = nuevoImporte;
                    auxiliar.Fecha = nuevaFecha;

                    return auxiliar; // Devolvemos el nodo editado
                }

                auxiliar = auxiliar.Siguiente; // Avanzamos al siguiente nodo
            }

            // Si no encontramos el nodo, retornamos null
            return null;
        }



        //Sumar Saldos 
        public int SumarSaldos(int tipoMovimiento)
        {
            int suma = 0;
            Nodo auxiliar = Primero;

            while (auxiliar != null)
            {
                if (auxiliar.TipoMovimiento == tipoMovimiento) // Filtrar por tipo
                {
                    suma += auxiliar.Importe; // Sumar el importe
                }
                auxiliar = auxiliar.Siguiente; // Avanzar al siguiente nodo
            }

            return suma;
        }
    }
}

