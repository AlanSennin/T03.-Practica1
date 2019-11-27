using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Agregamos la Libreria

namespace P_Evaluativa_1
{
    public class Operacion
    {
        //Creamos la lista como string y le mandamo de parametro el path que agregamos con el System.IO
        public List<string> ObtenerLineas(string path)
        {
            //Instanciamos la Lista como "Personas"
            List<string> Personas = new List<string>();

            //Condicion si el archivo existe o no...
            if (File.Exists(path))
            {
                //Declaramos a Datos como un arreglo de string y le asignamos el leer las lineas
                string[] Datos = File.ReadAllLines(path);

                //ForEache para buscar entre la lista los Datos
                foreach (var item in Datos)
                {
                    //Agregamos a la lista el item
                    Personas.Add(item);
                }
            }
            else
            {
                //Si no se cumple la condicion manda mensaje de que el archivo no existe
                Console.WriteLine("El archivo ingresado no existe...");
                return null;
            }

            //Devolvemos
            return Personas;
        }

        //Metodo para Obtener a las Peronas...
        public List<Persona> ObtenerPersona()
        {
            //Instanciamos la clase "Persona" como P
            Persona P = new Persona();

            //Creamos una variable "Lineas" y le asignamos el metodo ObtenerLienas con el nombre del archivo como parametro
            var Lineas = ObtenerLineas("Datos.txt");

            //Instanciamos la lista como "Lista"
            List<Persona> Lista = new List<Persona>();

            //ForEach para buscar entre la lista
            foreach (var item in Lineas)
            {
                //Le asiganmos a una variable Info como string el item con el Split
                string[] Info = item.Split(',');

                //Agregamos a la lista los atributos en el orden que son con el arreglo
                Lista.Add(new Persona { ID = int.Parse(Info[0]), Nombre = Info[1], Profesion = Info[2], Edad = int.Parse(Info[3]) });
            }

            //Devolvemos la Lista...
            return Lista;
        }

        //Metodo para mostrarnos la Persona que buscamos...
        public void MostrarPersona()
        {
            //Creamos una variable "repeat" como bool y la asignamos como true
            bool Repetir = true;

            //Ciclo while 
            while (Repetir == true)
            {
                //Tr Ctahc por si ingresamos un dato que no se encuentra en el archivo...
                try
                {
                    Console.WriteLine("Ingrese el ID de la persona: ");

                    //Ingresamos el ID de la persona y se lo asiganamos a la variable Buscar
                    int Buscar = int.Parse(Console.ReadLine()); 

                    //Creamos una variable "Persona" y le asignamos el metodo ObtenerPersona
                    var Persona = ObtenerPersona();

                    //Instanciamos la clase "Perosna" como P
                    Persona P = new Persona();

                    //ForEach para buscar a la persona entre la lista
                    foreach (var item in Persona)
                    {
                        if (Buscar == item.ID) //Condicion por si el ID ingresado si se encuentra en la lista
                        {
                            P = item; //Le Asignamos a los atributos de la clase Persona la persona encontrada...
                        }
                    }

                    Console.Clear(); //Limpiamos la Consola...

                    Console.WriteLine("Nombre: "+P.Nombre); //Imprimimos el nombre...
                    Console.WriteLine(" ");

                    Console.WriteLine("Profesion: "+P.Profesion); //Imprimimos la profesion...
                    Console.WriteLine("");

                    Console.WriteLine("Edad: "+P.Edad); //Imprimimos la edad...
                    Console.WriteLine("");

                    Console.WriteLine("(1) Ingresar Otra Persona (2) Salir"); //Mensaje por si queremos ingresar otra persona

                    //Variable para la condicion siguiente
                    int Opcion = int.Parse(Console.ReadLine()); 

                    //Condicion por si queremos ingresar otra persona...
                    if (Opcion != 1)
                    {
                        //Asiganos a Repeter como falso
                        Repetir = false;

                        //Limpiamos la Consola...
                        Console.Clear();

                        //Mensaje
                        Console.WriteLine("Presione cualquier tecla para salir...");
                        
                        Console.ReadKey();
                    }

                    Console.Clear(); //Limpiamos la consola...
                }

                catch (Exception ex)
                {
                    //Mensaje de Aviso...
                    Console.WriteLine("Persona Ingresada no Disponible...", ex.Message);
                    Console.WriteLine("");
                    
                    //Mensaje de Aviso...
                    Console.WriteLine("Preione cualquier tecla para salir...");

                    Console.ReadKey();

                    Console.Clear(); //Limpiamos la consola...
                }
            }
        }
    }
}
