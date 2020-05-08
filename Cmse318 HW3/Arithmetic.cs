using System;
using System.Collections.Generic;
using System.Text;


namespace Cmse318_HW3
{
    class Arithmetic
    {
        
        public static void G() // G Function
        {
            Lex.lex();
           
            Console.WriteLine("G -> E");
            E();

            if (Global.next_token == '$' && !Global.error)
            {
                Console.WriteLine("Success");
            }
            else if (Global.text[Global.i] == '$')
            {
                return;
            }
            else
            {
                Console.WriteLine("Failed");
                Console.WriteLine("Error : Unexpected token =" + Global.next_token);
                Console.Write("Failure: Unconsumed input : ");
                Unconsumed_input();
            }
        }

        public static void E()
        {
            if (Global.error) return;

            Console.WriteLine("E -> TR");

            

            T();


            R();

        }
        public static void R() //R Function
        {
            if (Global.error) return;

            if(Global.next_token == '+')
            {
                Console.WriteLine("R -> + TR");
                Lex.lex();
                T();
                R();
            }

            else if (Global.next_token == '-') 
            {
                Console.WriteLine("R -> - TR");
                Lex.lex();
                T();
                R();
            }
            else
            {
                Console.WriteLine("R -> e");
            }
        }

        public static void T() // T Function
        {
            if (Global.error) return;

            Console.WriteLine("T -> FS");
            F();
            S();  
        }

        public static void S()
        {
            
            if (Global.error) return;
            if (Global.next_token == '*')
            {
                Console.WriteLine("S -> * FS");
                Lex.lex();
                F();
                S();
            }
            else if(Global.next_token == '/')
            {
                Console.WriteLine("S -> /FS");
                Lex.lex();
                F();
                S();                  
            }
            else
            {
                Console.WriteLine("S -> e");
            }
        }

        public static void F()
        {

            if (Global.error)
            {
                return;
            }

            if (Global.next_token == '(')
            {  
                Console.WriteLine("F -> (E)");

                Lex.lex();

                E();

                if (Global.next_token == ')')
                {
                    
                    Lex.lex();
                }

                else
                {
                   
                    Global.error = true;
                    Console.WriteLine("Failed");
                    Console.WriteLine("Error : Unexpected token =" +  Global.next_token);
                    Console.Write("Unconsumed input =" );
                    Unconsumed_input();
                    return;
                }
            }

            else if (Global.next_token == 'a' || Global.next_token == 'b' || Global.next_token == 'c' || Global.next_token == 'd')
              {
                Console.WriteLine("F -> M");
                M();
              }

            else if (Global.next_token == '0' || Global.next_token == '1' || Global.next_token == '2' || Global.next_token == '3')
            {
                Console.WriteLine("F -> N");
                N();
            }

            else
            {
                
                Global.error = true;

               Console.WriteLine("Failed");
               Console.WriteLine("Error : Unexpected token = " + Global.next_token);
               Console.Write("Unconsumed input =" );
               Unconsumed_input();
                return;
              
            }

        }
        
        public static void M()
        {
            if (Global.error) return;
            
            if (Global.next_token == 'a' || Global.next_token == 'b' || Global.next_token == 'c' || Global.next_token == 'd')
            {
                Console.WriteLine("M -> " + Global.next_token);
                Lex.lex();
            }
            else
            {
                Global.error = true;
                Console.WriteLine("Failed");
                Console.WriteLine("Error : Unexpected token =" + Global.next_token);
                Console.Write("Unconsumed input =" );
                Unconsumed_input();
            }
        }

        public static void N()
        {
            if (Global.error) return;
            if (Global.next_token == '0' || Global.next_token == '1' || Global.next_token == '2' || Global.next_token == '3')
            {
                Console.WriteLine("N -> " + Global.next_token);
                Lex.lex();
            }
            else
            {
                Global.error = true;
                Console.WriteLine("Failed");
                Console.WriteLine("Error : Unexpected token" + Global.next_token);
                Console.Write("Unconsumed input = " );
                Unconsumed_input();
            }
        }

        public static void Unconsumed_input() // Prints Unconsumed inputs
        {
            while (!(Global.text[Global.i] == '$'))
            {
                Console.Write(Global.text[Global.i]);
                Global.i++;
            }

                
        }
    } 
    }

