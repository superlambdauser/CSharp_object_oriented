using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces.Models
{
    internal class Fox : Animal
    {
        public delegate void DelegateScream(string scream); // prototype of the method that could be called by the delegate
        public event DelegateScream OnScream;
        
        
        public Fox (string  name) : base (name)
        {
            
        }

        private void Scream()
        {
            OnScream("AAAAAAAAAAAAAAAAAAA");
        }

        internal void SeeChicken()
        {
            Scream();
        }
    }
}
