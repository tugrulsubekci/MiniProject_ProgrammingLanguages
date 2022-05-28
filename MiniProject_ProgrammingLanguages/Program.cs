using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniProject_ProgrammingLanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Language> languages = File.ReadAllLines("./languages.tsv")
                .Skip(1)
                .Select(line => Language.FromTsv(line))
                .ToList();

            /*
            foreach(var language in languages)
            {
                Console.WriteLine(language.Prettify());
            }
            */

            var basicInfos = languages.Select(l => l.Prettify());

            /*
            foreach (string s in basicInfos)
            {
                Console.WriteLine(s);
            }
            */

            // C# languages
            var csharp = languages.Where(l => l.Name == "C#");
            foreach (var lang in csharp)
            {
                Console.WriteLine(lang.Prettify());
            }
            Console.WriteLine("--------------------------------------------------------------------");
            
            // Microsoft languages
            var microsoft = languages.Where(l => l.ChiefDeveloper == "Microsoft");
            foreach (var language in microsoft)
            {
                Console.WriteLine(language.Prettify());
            }
            Console.WriteLine("--------------------------------------------------------------------");

            // Find all of the languages that descend from Lisp
            var lisp = languages.Where(l => l.Predecessors == "Lisp");
            foreach(var language in lisp)
            {
                Console.WriteLine(language.Prettify());
            }
            Console.WriteLine("--------------------------------------------------------------------");

            // Find all of the language names that contain the word "Script"
            var script = languages
                .Where(l => l.Name.Contains("Script"))
                .Select(l => l.Name);
            foreach (var language in script)
            {
                Console.WriteLine(language);
            }
            Console.WriteLine("--------------------------------------------------------------------");

            // How many languages are included in the languages list?
            Console.WriteLine($"Total number of languages: {languages.Count}");

            // How many languages were launched between 1995 and 2005?
            var oldLang = from lang in languages
                          where lang.Year >= 1995 && lang.Year <= 2005
                          select lang.Year;

            Console.WriteLine($"Number of languages which launched between 1995 and 2005: {oldLang.Count()}");
            Console.WriteLine("--------------------------------------------------------------------");
            var nearMilenium = from lang in languages
                               where lang.Year >= 1995 && lang.Year <= 2005
                               select $"{lang.Name} was invented {lang.Year}";



            /*
            foreach (var lang in nearMilenium)
            {
                Console.WriteLine(lang);
            }
            */

            /*
            PrettyPrintAll(languages);
            */

            /*
            PrintAll(nearMilenium);
            */
            // to keep console open
            Console.ReadLine();

        }

        public static void PrettyPrintAll(IEnumerable<Language> langs)
        {
            foreach(var language in langs)
            {
                Console.WriteLine(language.Prettify());
            }
        }
        public static void PrintAll(IEnumerable<Object> sequence)
        {
            foreach(var language in sequence)
            {
                Console.WriteLine(language);
            }
        }
    }
}
