using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Clases
{
    
        [Serializable]
        public class Transition
        {
            public int startstate;
            public char input;
            public int arrivalstate;

            public Transition()
            {

            }

            public Transition(int startstate, char input, int arrivalstate)
            {
                this.startstate = startstate;
                this.input = input;
                this.arrivalstate = arrivalstate;
            }

            public override bool Equals(object obj)
            {
                var transition = obj as Transition;
                return transition != null &&
                       startstate == transition.startstate &&
                       input == transition.input &&
                       arrivalstate == transition.arrivalstate;
            }
        }
    
}
