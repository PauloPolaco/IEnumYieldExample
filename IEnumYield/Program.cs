using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEnumYield
{
    public class NameObj
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
    }

    class Program
    {
        private static IList<string> _namesA = new List<string>()
            {
                "James",
                "Andy",
                "John",
                "Mary",
                "Paul",
                "Kim",
                "Alan"
            };

        private static IList<string> _namesB = new List<string>()
        {
            "Ben",
            "Greg",
            "Jim",
            "Bonnie",
            "Alex",
            "Betty",
            "Gretchen"
        };

        static void Main(string[] args)
        {
            foreach (NameObj obj in ProcessListA())
            {
                Console.WriteLine(obj.NewName);
            }

            Console.ReadKey();
        }

        private static IEnumerable<NameObj> ProcessListA()
        {
            int count = 0;

            foreach (string nameA in _namesA)
            {
                string nameB = String.Empty;

                foreach (NameObj personFromListB in ProcessListB())
                {
                    nameB = personFromListB.NewName;

                    yield return personFromListB;
                }

                NameObj personFromListA = new NameObj()
                {
                    OldName = nameA,
                    NewName = nameA + " = " + count++.ToString()
                };

                yield return personFromListA;
            }
        }

        private static IEnumerable<NameObj> ProcessListB()
        {
            int count = 0;

            foreach (string nameB in _namesB)
            {
                NameObj personFromListB = new NameObj()
                {
                    OldName = nameB,
                    NewName = "- " + nameB + " = " + count++.ToString()
                };

                yield return personFromListB;
            }
        }
    }
}