using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Forms
{
    class Biginteger
    {
        public List<int> digits = new List<int>();
         public Biginteger()
        {
           
        }
        public Biginteger(Biginteger a)
        {
            digits = a.digits;
        }
        public Biginteger(string a)
        {
            for (int i = 0; i < a.Length; i++)
                digits.Add(int.Parse(a[i].ToString()));
        }
        
        public void lengthequalizer(Biginteger a)
        {
            int id=0, shorter = 0,larger=0;
            if (digits.Count < a.digits.Count)
            {
                id = 1;                     //if the object sent is larger make id =1 to 
                larger = a.digits.Count;  //identify for later use in for loop
                shorter = digits.Count;
            }
            else if (digits.Count > a.digits.Count)
            {
                id = 0;
                larger = digits.Count;
                shorter = a.digits.Count;
            }
            for (int i = shorter; i < larger; i++)
            {
                if (id == 1)
                {
                    digits.Insert(0, 0);
                    //digits.Add(0);
                }
                else
                    a.digits.Insert(0,0);
            }
                
        }

        public void lengthequalizer(Biginteger a,Biginteger b)  //ex a=223 b=3333 then a=0223 b=3333
        {
            int id = 0, shorter = 0, larger = 0;
            if (a.digits.Count < b.digits.Count)
            {
                id = 1;                     //if the object sent is larger make id =1 to 
                larger = b.digits.Count;  //identify for later use in for loop
                shorter = a.digits.Count;
            }
            else if (a.digits.Count > b.digits.Count)
            {
                id = 0;
                larger = a.digits.Count;
                shorter = b.digits.Count;
            }
            for (int i = shorter; i < larger; i++)
            {
                if (id == 1)
                {
                    a.digits.Insert(0, 0);
                    //digits.Add(0);
                }
                else
                    b.digits.Insert(0, 0);
            }

        }
        public void add(Biginteger a)
        {
            lengthequalizer(a);
            bool carry = false;
            int [] tmp = new int[digits.Count];
            for (int i = digits.Count-1; i >= 0; i--)
            {
                if (carry == true)
                {
                    tmp[i]=(1);
                    carry = false;
                }
                if (digits[i] + a.digits[i] > 9)
                {
                    carry = true;
                    tmp[i] += (digits[i] + a.digits[i]) % 10;
                }
                else
                    tmp[i] += digits[i] + a.digits[i];
            }
             digits=new List<int>(tmp);
            if (carry == true)
            {
                digits.Insert(0, 1);
            }
        }

        public Biginteger add(Biginteger a,Biginteger b)
        {
            Biginteger tmpclass = new Biginteger();
            lengthequalizer(a,b);
            bool carry = false;
            int[] tmp = new int[a.digits.Count];
            for (int i = a.digits.Count - 1; i >= 0; i--)
            {
                if (carry == true)
                {
                    tmp[i] = (1);
                    carry = false;
                }
                if (a.digits[i] + b.digits[i] > 9)
                {
                    carry = true;
                    tmp[i] += (a.digits[i] + b.digits[i]) % 10;
                }
                else
                    tmp[i] += a.digits[i] + b.digits[i];
            }
            tmpclass.digits = tmp.OfType<int>().ToList();
            if (carry == true)
            {
                tmpclass.digits.Insert(0, 1);
            }
            return tmpclass;
        }

        bool checkBigger(Biginteger a, Biginteger b) //if a >b then true
        {
            lengthequalizer(a, b);
            
            for (int i = 0; i < a.digits.Count; i++)
            {
                if (a.digits[i] > b.digits[i])
                {
                    return true;
                    break;
                }
                else if (a.digits[i] < b.digits[i])
                {
                    return false;
                    break;
                }
                
                    
            }

                return false;

        }

        public void swapBigInteger(Biginteger a, Biginteger b)
        {
            Biginteger tmpObj = new Biginteger();
            lengthequalizer(a, b);

            tmpObj.digits = a.digits;
            a.digits = b.digits;
            b.digits = tmpObj.digits;
            
        }

        

        public Biginteger sub(Biginteger a, Biginteger b) //a-b
        {
            bool borrow = false;
            lengthequalizer(a, b);
            Biginteger Result = new Biginteger();
            int[] result = new int[a.digits.Count];
            bool check = checkBigger(a, b); //if a is bigger than b
            if (check == false)
            {
                swapBigInteger(a, b); //swap a and b
            }

            for (int i = a.digits.Count - 1; i >= 0; i--)
            {
                if (borrow == true)
                {
                    a.digits[i]--;
                }
                if (a.digits[i] >= b.digits[i])
                {
                    //Result.digits[i]+=(a.digits[i] - b.digits[i]);
                    result[i] = a.digits[i] - b.digits[i];
                    borrow = false;
                }
                else
                {
                    //Result.digits[i]+=(a.digits[i]+10 - b.digits[i]);
                    result[i] = (a.digits[i] + 10) - b.digits[i];
                    borrow = true;
                }
            }
            if (borrow == true)
            {
                if (result[0] > 0)
                    result[0]--;
            }

            Biginteger tmp = new Biginteger();
            tmp.digits = result.OfType<int>().ToList();
            return tmp;
        }
         public Biginteger mult(Biginteger a, Biginteger b) //using karatsuba
        {
            if (a.digits.Count != b.digits.Count) { 
            lengthequalizer(a, b);
            }
            
            if (a.digits.Count % 2 != 0 && a.digits.Count > 1)
            {
                a.digits.Insert(0, 0);
                b.digits.Insert(0, 0);
            }
            Biginteger tmp = new Biginteger();
            int size = a.digits.Count; //both same size
            
            if (size == 1)
            {
                if ((a.digits[0] * b.digits[0] )> 10)
                {
                    tmp.digits.Add((a.digits[0] * b.digits[0]) / 10);
                    tmp.digits.Add((a.digits[0] * b.digits[0]) % 10);
                }
                else
                    tmp.digits.Add(a.digits[0] * b.digits[0]);
                return tmp;
            }
            
            else { 

            int m = (size)/2+(size%2); //calculate number size
            Biginteger lo = new Biginteger();
            Biginteger hi = new Biginteger();
            Biginteger lo2 = new Biginteger();
            Biginteger hi2= new Biginteger(); 
            lo.digits = a.digits.GetRange(0, m);    //gets first half of the biginteger
            hi.digits = a.digits.GetRange(m, size-m); //second half of biginteger
            lo2.digits = b.digits.GetRange(0, m);
            hi2.digits = b.digits.GetRange(m, size-m);

            Biginteger z0 = new Biginteger();
            Biginteger z1 = new Biginteger();
            Biginteger z2 = new Biginteger();

             z0 = mult(lo, lo2);
             z2=mult(hi,hi2);
             z1 = mult((lo.add(lo, hi)), (lo2.add(lo2, hi2)));
            //(z2*10^(2*m))+((z1-z2-z0)*10^(m))+(z0) translates to
             Biginteger tmpsub1 = new Biginteger();
             Biginteger tmpsub2 = new Biginteger();
            
            
             tmpsub2 = tmpsub2.sub(z1, z2);
             tmpsub1 = tmpsub1.sub(tmpsub2, z0);
           

            
            Biginteger result = new Biginteger();
        
            if (m == 1) //special case if its 10^1
                tmpsub1.digits.Add(0);
            else
            {
                for (int i = 0; i < m; i++)
                {

                    tmpsub1.digits.Add(0);
                }
            }
            

            for (int i = 0; i < size; i++)
                z0.digits.Add(0); //z2*10^m*2
        

            result.add(tmpsub1); //instead of z1 (mesh m3mloha power)
            result.add(z2);
            result.add(z0);
                
                while (result.digits[0] == 0 )
                {
                    if (result.digits.Count - 1 > 1)
                        result.digits.RemoveAt(0); //removes extra 0s at the beggining 
                    else
                        break;
                }
 return result;
        }
      }
        

        public bool even_odd_check(Biginteger a)
        {
            if (a.digits.Last() % 2 == 0)
            {
                
                return true;
            }
            else
                return false;
        }

        
        public KeyValuePair<Biginteger, Biginteger> div(Biginteger a, Biginteger b)
        {
            if (a.checkBigger(b, a))
                return (new KeyValuePair<Biginteger, Biginteger>(new Biginteger("0"), a));
            KeyValuePair<Biginteger, Biginteger> result = div(a, b.add(b, b));
            var q = result.Key;
            var r = result.Value;
            q = q.add(result.Key, result.Key);

            if (q.checkBigger(b, r))
                return (new KeyValuePair<Biginteger, Biginteger>(q, r));
            else
                return (new KeyValuePair<Biginteger, Biginteger>(q.add(q, new Biginteger("1")), q.sub(r, b)));

        }


        public Biginteger Modofpower(Biginteger b, Biginteger p, Biginteger m)
        {
            if (p.digits.Count == 1 && p.digits[0] == 0)
                return new Biginteger("1");
            Biginteger power = p.div(Modofpower(b, p.div(p, new Biginteger("2")).Key, m), m).Value;
            if (p.even_odd_check(p))
                return new Biginteger(div(power.mult(power, power), m).Value);
            else

                return (new Biginteger(div(new Biginteger(mult(new Biginteger(div(b, m).Value), new Biginteger(mult(power, power)))), m).Value));
        }

    }
}
