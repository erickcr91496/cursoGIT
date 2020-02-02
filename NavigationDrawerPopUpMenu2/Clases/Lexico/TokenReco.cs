using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    class TokenReco
    {
        public int numToken { get; set; }
        public string nomToken { get; set; }
        public string sinonimo { get; set; }
        public string lexema { get; set; }

        public TokenReco(int numToken, string nomToken, string sinonimo, string lexema)
        {
            this.numToken = numToken;
            this.nomToken = nomToken;
            this.sinonimo = sinonimo;
            this.lexema = lexema;
        }
    }
}
