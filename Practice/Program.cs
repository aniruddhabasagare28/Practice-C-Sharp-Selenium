using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
namespace Practice
{

    public class Animal
    {
        private protected string Name { get; set; }
    }
    public class Person : Animal
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    public class Practice
    {
        List<Person> people = new List<Person>
{
    new Person { Name = "Alice", Age = 25, City = "New York" },
    new Person { Name = "Bob", Age = 35, City = "New York" },
    new Person { Name = "Charlie", Age = 40, City = "Los Angeles" },
    new Person { Name = "Chapline", Age = 40, City = "Los Angeles" },
    new Person { Name = "David", Age = 28, City = "New York" },
};



        public void LinQuery()
        {

            //Find all the people who are above the age of 30 and live in a specific city (e.g., "New York").
            var result = people.Where(person => person.Age > 20 && person.City == "New York").ToList();

            //Group people by their city and find the average age of people in each city.
            var group = people.GroupBy(person => person.City).Select(g =>
                                                                    new
                                                                    {
                                                                        City = g.Key,
                                                                        AverageAge = g.Average(person => person.Age)
                                                                    }).ToList();

            //Get the second youngest person in the list of people.

            var seondYoungest = people.OrderBy(p => p.Age).Skip(1).FirstOrDefault();


            /*  Find the top 3 oldest people from the list of people, and return their names and ages.
              Hint: You can use the OrderByDescending method to sort the people by age in descending order and then use Take(3) to get the top 3 oldest people.*/
            var oldestPepople = people.OrderByDescending(p => p.Age).Take(3).ToList();


            //Find the average age of people in each city, but only include cities where there are more than 2 people.
            var morethantwopeople = people.GroupBy(p => p.City) 
                                    .Where(p => p.Count() > 2)
                                    .Select(p => new
                                    {
                                        City = p.Key,
                                        Average = p.Average(p => p.Age)
                                    });
            var countEachCity = people.GroupBy(p => p.City)
                                        .Select(group => new
                                        {
                                            City = group.Key,
                                            Count = group.Count()
                                        }); 
            foreach (var city in countEachCity)
            {
                Console.WriteLine($"{city.City}: {city.Count} people");
            }

            //Find the names of people who are older than the average age of all people in the list.

            // Calculate the average age of all people
            double averageAge = people.Average(p => p.Age);

            var olderThanAverageAge = people.Where(p => p.Age > averageAge).Select(p => p.Name).ToList();

            //Find the oldest person in the list, and return their name and age. If there are multiple people with the same oldest age, return all of them.

            var oldestAge = people.Max(p => p.Age);
            var morethantage = people.Where(p => p.Age == oldestAge).Select(p => new { p.Name, p.Age }).ToList();


            var employees = new List<int> { 40000, 60000, 80000, 100000, 120000 };

            var filteredEmployees = employees.Where(emp => emp >= 50000 && emp <= 100000).OrderByDescending(emp => emp).ToList();
            var lstEmp = employees.Where(emp=>emp > 50000).Select(emp=>emp).ToList();

            var morthansitythousand = employees.Where(emp=>emp>60000).Average(emp=>emp);
            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }
        }

        public static void FirstNonRepeatingChar(string input)
        {
            //for (int i = 0; i < input.Length; i++) 
            //{
            //    for (int j=i+1; j < input.Length; j++) 
            //    {
            //        if(input[i] == input[j])
            //        {
            //            break;
            //        }
            //    }
            //    Console.WriteLine("This is first not repeating char::"+input[i]);
            //    break;
            //}

            Dictionary<char,int> keyValuePairs = new Dictionary<char,int>();

            foreach (var c in input)
            {
                if (!keyValuePairs.ContainsKey(c))
                {
                    keyValuePairs.Add(c, 1);
                }
                else 
                {
                    keyValuePairs[c]++;
                }
            }

            foreach (var keyValue in keyValuePairs)
            {
                if(keyValue.Value == 1)
                {
                    Console.WriteLine(keyValue.Key);
                }
            }



        }

        public static bool IsPalindrome(string input)
        {
            int left = 0, right = input.Length-1;

            while (left < right) 
            {
                if(input[left] != input[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}
