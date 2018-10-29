using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class Controller
    {
        protected ArrayList Alist;
        public Controller()
        {
            Alist = new ArrayList() ; // make new array
        }
        public void AddModel(Model m)
        {
            Alist.Add(m) ;  // add model form list
        }

        // virtual keyword allow the method to be overriden
        // make variable to allow keyboard button
        public virtual void Calculate(string str)
        {
            throw new NotImplementedException();
        }

        public virtual void isNumber(string str)
        {
            throw new NotImplementedException();
        }

        public virtual void isOperator(string str)
        {
            throw new NotImplementedException();
        }
    }
}
    

