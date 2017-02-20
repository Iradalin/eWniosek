using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWniosek
{
    public class ComboboxItem
    {
        public string text = "";
        public string hidden = "";
        public string pesel = "";
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
        public string Hidden_Id
        {
            get
            {
                return hidden;
            }
            set
            {
                hidden = value;
            }
        }
        public string Pesel
        {
            get
            {
                return pesel;
            }
            set
            {
                pesel = value;
            }
        }

        public override string ToString()
        {
            return text;
        }
    }
}
