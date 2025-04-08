using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modifiedapp
{
    class ClassValidator
    {
    
        public bool QuantityCheck(int quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("you should have to add a valid quantity.");
                return false;
            }
            return true;
        }


        public bool StringName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("string ciuld not be empty");
                return false;
            }
            return true;
        }
    }
}
