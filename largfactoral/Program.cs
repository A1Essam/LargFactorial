using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace largfactoral
{
    class Program
    {
       


        //to add number of zeroes on the end of th number 
        static string addzeros(int i)
         {
            string res = "";
            for (int z = 0; z < i; z++) res += '0';
            return res;
         }

        //this function take two string and multiplay them then pass the result inversed to add fuction
        /*
         * [To make function easy]
          (2)(2)     <- carry
           5  5  5   <- num1
                  * 
              5  5   <- num2
          ---------- 
           2  7  7  5              <-   subMullRes[0]
      { 2  7  7  5 (0)<-addzeros() }<-  subMullRes[1]

        */
        static string mull(string num1, string num2)
         {

            string res = "";

            string[] subMullRes = new string[num2.Length]; 

            for (int i = 1; i <= num2.Length; i++)
            {
                int num = num2[num2.Length - i] - 48;
                int carry = 0;
                subMullRes[i - 1] = addzeros(i - 1);
                for (int t = 1; t <= num1.Length; t++)
                {
                    int inum = num1[num1.Length - t] - 48;
                    int mullof2num = (num * inum + carry) % 10;
                    carry = (num * inum + carry) / 10;
                    subMullRes[i - 1] += mullof2num;
                    if (t == num1.Length && carry != 0)
                    {
                        subMullRes[i - 1] += carry;
                    }
                   

                }
            }
             
            
            res = add(subMullRes);


            return res;
        }


        //take any number of string and add them together 
        static string add(params string [] numarr)
        {
            string res = "";
            //add zeroes to make all numbers lenght equal
            /*
             * add this zero 
             * ^
             * 0  2  7  7  5
             * 2  7  7  5  0
             */
             
            for(int i = 0; i < numarr.Length - 1; i++)
            {
                numarr[i] += addzeros(numarr[numarr.Length-1].Length-numarr[i].Length);
            }
            int carry = 0;

            for (int i = 0; i < numarr[numarr.Length-1].Length; i++)
            {
                int sumOfColumn = 0;
                //summation of numbers in the same column
                for (int c = 0; c< numarr.Length; c++)
                {
                    sumOfColumn += numarr[c][i]-48;
                }
                
                int addof2num = (sumOfColumn + carry) % 10;
                carry = (sumOfColumn + carry) / 10;
                res += addof2num;

            }
            if (carry != 0) res += carry;


            return res;
        }


        //test mull function
        static bool StressTestingmull(long x, long y)
        {
            long correct = x * y;
            long output = Convert.ToInt64(new string ( mull(Convert.ToString(x), Convert.ToString(y)).Reverse().ToArray() ));
            bool res = correct == output;
            Console.WriteLine("{0} ,first number {1} , second number {2}" , res , x, y);
            return res;

        }



        //print function to make printing process easy
        static void print(params dynamic [] x)
        {
            for(int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
        }


        static string factorial(int fact)
        {
            string last = fact != 1 ? new string(mull(Convert.ToString(fact), Convert.ToString(--fact)).Reverse().ToArray()) : "1";
            while (fact != 1)
            {
                last = new string(mull(last, Convert.ToString(--fact)).Reverse().ToArray());
            }

            return last;
        }


        ///////////////////////////////////////////

        //code from geeksforgeeks limited by factorial 270
        //https://www.geeksforgeeks.org/factorial-large-number/

        static string gogfactorial(int n)
        {
            int[] res = new int[500];
            string re = "";
            res[0] = 1;
            int res_size = 1;
 
            for (int x = 2; x <= n; x++)
                res_size = multiply(x, res,
                                    res_size);

           
            for (int i = res_size - 1; i >= 0; i--)
            {
                re+=res[i];
            }
            return re;
        }
        static int multiply(int x, int[] res,
                            int res_size)
        {
            int carry = 0; 
            for (int i = 0; i < res_size; i++)
            {
                int prod = res[i] * x + carry;
                res[i] = prod % 10;  
                                    
                carry = prod / 10;  
            }
            while (carry != 0)
            {
                res[res_size] = carry % 10;
                carry = carry / 10;
                res_size++;
            }
            return res_size;
        }
        

        


        ///////////////////////////////////////////
      

        static bool StressTestingFactorial(int fact)
        {
            bool res =true;
            string mycode = factorial(fact);
            string gogcode = gogfactorial(fact);

            if (mycode != gogcode) res = false;


            Console.WriteLine("{0} \tfactorial of : {1}\t mycode result: {2}\t gogcode:{3}",res,fact,mycode,gogcode);
            
            return res;
        }




        static void Main(string[] args)
        {

            print("Enter the number :");
            int fact = Convert.ToInt32(Console.ReadLine());
            print(factorial(fact));




            //Stress Testing
            //while (true)
            //{
            //    Random r = new Random();
            //    int x = r.Next(1, 250);
            //    if (!StressTestingFactorial(x)) break;
            //}






            Console.ReadKey();
        }
    }
}
