using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSA_Forms
{
    class RSA
    {
        public RSA() { }

        public string encrypt(string ee,string mm,string nn)
        {
            string e;
            string m;
            string n;
           
            m = mm;
            e = ee;
            n = nn;

            double time = System.Environment.TickCount;

            Biginteger message = new Biginteger(m);
            Biginteger mod = new Biginteger(n);
            Biginteger power = new Biginteger(e);
            message = message.Modofpower(message, power, mod);

            while (message.digits[0] == 0)
            {
                if (message.digits.Count - 1 > 1)
                    message.digits.RemoveAt(0); //removes extra 0s at the beggining 
                else
                    break;
            }
    
            double time2 = System.Environment.TickCount;
            MessageBox.Show("Time at end: " + (time2 - time) + " Millisecond", "Important Message");

            
            string tmp="";
            for (int i = 0; i < message.digits.Count; i++)
                tmp += message.digits[i].ToString();
            return tmp;
        }

        public string decrypt(string mm, string dd, string nn)
        {
            Biginteger eMessage = new Biginteger(mm);
            string d = dd;
            string n = nn;
            double time_1 = System.Environment.TickCount;
            Biginteger power = new Biginteger(eMessage);
            eMessage = eMessage.Modofpower(eMessage, new Biginteger(d), new Biginteger(n));

            while (eMessage.digits[0] == 0)
            {
                if (eMessage.digits.Count - 1 > 1)
                    eMessage.digits.RemoveAt(0); //removes extra 0s at the beggining 
                else
                    break;
            }

            double time_2 = System.Environment.TickCount;
            MessageBox.Show("Time at end: " + (time_2 - time_1) + " Millisecond", "Important Message");
            
            string tmp = "";
            for (int i = 0; i < eMessage.digits.Count; i++)
                tmp += eMessage.digits[i].ToString();
            return tmp;
            
        }

    }
}
