using System;
using System.Collections.Generic;

namespace DelegationExample
{
    /// <summary>
    /// Delegation is used for using method as a method parameters. 
    /// In this way we can call any method that match our delegate initialization.         
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Delegate initialize
        /// </summary>
        /// <param name="person">Person object</param>
        /// <returns>Person age</returns>
        public delegate bool AgeDelegate(Person person);
        public static void Main(string[] args)
        {
            var personList = new List<Person>
            {
                new Person { Id = 1, Name = "Ömer", Age = 24},
                new Person { Id = 2, Name = "Ahmet", Age = 7},
                new Person { Id = 3, Name = "Ayşe", Age = 45},
                new Person { Id = 4, Name = "Hilal", Age = 33},
                new Person { Id = 5, Name = "Hasan", Age = 37},
                new Person { Id = 6, Name = "Melike", Age = 97},
            };

            PeopleDisplay("Young", personList, IsYoung);
            PeopleDisplay("Adult", personList, IsAdult);
            PeopleDisplay("Master", personList, IsMaster);

        }

        /// <summary>
        /// A method to filter out the people you need
        /// </summary>
        /// <param name="people">A list of people</param>
        /// <param name="ageFilter">A filter</param>
        /// <returns>A filtered list</returns>
        public static void PeopleDisplay(string title, IList<Person> people, AgeDelegate ageFilter)
        {
            Console.WriteLine(title);
            foreach (var person in people)
            {
                if (ageFilter(person))
                {
                    Console.WriteLine("{0}. {1} is {2} years old.", person.Id, person.Name, person.Age);
                }
            }
            Console.Write("\n\n");
        }

        //Filters
        public static bool IsYoung(Person person)
        {
            return person.Age < 18;
        }
        public static bool IsAdult(Person person)
        {
            return person.Age >= 18 && person.Age < 65;
        }
        public static bool IsMaster(Person person)
        {
            return person.Age >= 65;
        }
    }
}
