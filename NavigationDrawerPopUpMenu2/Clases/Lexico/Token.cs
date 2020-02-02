using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class Token
    {
        private int numToken;
        private char sinonimo;
        private String nombreToken;
        private String lexema;

        public int NumToken { get => numToken; set => numToken = value; }
        public char Sinonimo { get => sinonimo; set => sinonimo = value; }
        public string NombreToken { get => nombreToken; set => nombreToken = value; }
        public string Lexema { get => lexema; set => lexema = value; }

        public Token(int numToken, char sinonimo, string nombreToken, string lexema)
        {
            this.numToken = numToken;
            this.sinonimo = sinonimo;
            this.nombreToken = nombreToken;
            this.lexema = lexema;
        }

        public Token()
        {
        }
    }
}
