using NavigationDrawerPopUpMenu2.Clases.Sintactico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class AnalizadorSLR
    {
        Gramatica gr= new Gramatica();
        public Stack<object> pila;
       
        public List<Token> tokens = new List<Token>();
        int nerror = 0;
        int idtk = 0;
        int estado;
        char e;
        int n;
        int newEstado;
        int regla;
        Token tk = new Token();

        public void PonerTKreconocidos() {

        }
      

        public void semantico(int regla) { }

        public void Analizador(List<Transicion> GoTo,List<Transicion> accion, List<Produccion> Producciones,List<Token> tkr) {
            pila.Push(estado);
           
            do {
              //  PonerTKreconocidos(); //el lexico al terminar podria guardar este simbolo de finalizacion al final de los tokens reconocidos
                estado = (int) pila.Last();

                tk = tkr[idtk];
                char sinonimo = tk.Sinonimo;
                //newEstado = buscarColumna(accion,sinonimo);
                //e =' '; //e es el sinónimo
                        // n = APSLR[estado, e];

                if (newEstado >= 0 && newEstado < 200) {//aqui es el desplazarse del algoritmo
                    pila.Push(e);
                    pila.Push(n);
                    pila.Push(newEstado);
                    idtk++;
                }
                else if (newEstado < 0)
                {//aqui es reconocimiento de regla
                    int regla = -newEstado; //cambiamos de signo para que busque la regla 
                    int longitud_regla = Producciones[regla].der.Length;
                    char noterminal = Producciones[regla].izq; // pendiente
                    for (int i = 1; i <= 2 * longitud_regla; i++)
                    {
                        pila.Pop();
                    }
                     estado = GoTo[(int) pila.Last()].eInicial;
                    pila.Push(noterminal);
                    pila.Push(estado);
                    semantico(regla);

                    
                }
                else if(newEstado == 999)
    {//aqui aceptar
                    break;
                }
	else{//aqui error
                  //  presentarMensajeError(n);
                    nerror++;
                }
            } while (nerror <= 5);
            if (n == 999 && nerror == 0) {
              //  presentarMensaje("programa fuente reconocido sin errores sintácticos");
            } else {
              //  presentarMensaje("programa fuente con errores sintácticos");
            }



        }
       

           










    }
    }
