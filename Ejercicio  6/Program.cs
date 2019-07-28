using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio__6
{
    class Program
    {
        // A text is given.Write a program that modifies the casing of letters to
        //uppercase at all places in the text surrounded by<upcase> and
        //</upcase> tags. Tags cannot be nested.
        // Example:
        //We are living in a<upcase> yellow submarine</upcase>.We
        //don't have <upcase>anything</upcase> else.
        //Result:
        //We are living in a YELLOW SUBMARINE.We don't have ANYTHING else.

        static void Main(string[] args)
        {
            string pattern = @"(<[\w]+>)([\w\s]+)(</[\w]+>)";
            

            string oracion = "We are living in a <upcase>yellow submarine</upcase>. " +
                "We don't have <upcase>anything</upcase> else.";

            //oracion.Substring(15,5) necesita saber desde donde va a comenzar a crear la subcadena y necesita saber
            // cuantos caracters va a contener la subcadena

            StringBuilder cadenaModificada = new StringBuilder();


            string[] subCadenas = oracion.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < subCadenas.Length; i++)
            {
                Console.WriteLine($"subCadenas[{i}]={subCadenas[i]}");
                if (subCadenas[i].Contains("<upcase>") || subCadenas[i].Contains("</upcase>"))
                {
                    cadenaModificada.Append(subCadenas[i].ToUpper() + " ");
                    cadenaModificada.Replace("<UPCASE>", "");
                    cadenaModificada.Replace("</UPCASE>", "");
                }
                else
                {
                    cadenaModificada.Append(subCadenas[i] + " ");
                }

            }
            Console.WriteLine(cadenaModificada.ToString());

            StringBuilder cadenaModificada2 = new StringBuilder();

            Regex regex = new Regex(pattern);
            Match match = regex.Match(oracion);
            while (match.Success)
            {
                cadenaModificada2.Append(match.Groups[2].Value.ToUpper()+" ") ;
                match = match.NextMatch();
            }



            







            Console.WriteLine(cadenaModificada2.ToString());











            Console.ReadKey();





        }
    }
}
