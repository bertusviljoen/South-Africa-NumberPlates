using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace numberplate
{
    class Program
    {
        static void Main(string[] args)
        {

            int decLetterlow = 65;
            int decLetterhight = 90;
            
            System.Console.WriteLine("Enter number plate format: x to exit");
            string input = Console.ReadLine();
            do 
            {
                //Get the collection of each characters required
                List<Array> collections = new List<Array>();
                int count = 0;
                foreach(var item in input.ToCharArray()){
                    collections.Add(new string[0]);
                    switch (item.ToString())
                    {
                        case "a":
                            collections[count] = GetAlphaCharacters(decLetterlow, decLetterhight).ToArray();
                            break;
                        case "+":
                            collections[count] = GetNumericCharacters(0, 9).ToArray();
                            break;
                        case "b":
                            var bCollection = GetAlphaCharacters(decLetterlow, decLetterhight);
                            bCollection.Add(" ");
                            collections[count] = bCollection.ToArray();
                            break;
                        case "x":
                            var xCollection = GetAlphaCharacters(decLetterlow, decLetterhight);
                            xCollection.AddRange(GetNumericCharacters(0, 9));
                            collections[count] = xCollection.ToArray();
                            break;
                        case "z":
                            var zCollection =  GetAlphaCharacters(decLetterlow, decLetterhight);
                            zCollection.AddRange(GetNumericCharacters(0, 9));
                            zCollection.Add(" ");
                            collections[count] = zCollection.ToArray();
                            break;
                        default:
                            collections[count] = (new List<string>() { item.ToString()}).ToArray();
                            break;
                    }
                    count += 1;
                }

                count = 0;
                foreach (string x in foo(0, collections))
                {
                    count += 1;
                    Console.WriteLine($"{count}. {x}");
                }

                System.Console.WriteLine("Enter number plate format: x to exit");
                input = Console.ReadLine();
            } 
            while (input != "x");

        }

        static List<string> foo(int a, List<Array> x)
        {
            List<string> retval= new List<string>();
            if (a == x.Count)
            {
                retval.Add("");
                return retval;
            }
            foreach (Object y in x[a])
            {
                foreach (string x2 in foo(a + 1, x))
                {
                    retval.Add(y.ToString() + "" + x2.ToString());
                }

            }
            return retval;
        }

        static List<string> GetAlphaCharacters(int low, int high){
            var returnValue = new List<string>();
            for (int x = low; x <= high;x++){
                returnValue.Add($"{(char)x}");
            }
            return returnValue;
        }

        static List<string> GetNumericCharacters(int low, int high){
                        var returnValue = new List<string>();
            for (int x = low; x <= high;x++){
                returnValue.Add($"{x.ToString()}");
            }
            return returnValue;
        }
    }

}