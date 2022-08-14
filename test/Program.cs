using System.Text;

namespace test
{
    internal class Program
    {
        static void Main()
        {
            List<Person> test = new()
            {
                new("tom","suck",31),
                new("dave","bob",45),
                new("bob","dave",45),
                new("steve","salfjn",57),
                new("henry","ddieasln",67),
                new("nick","henryes",12),
                new("troy","wilson",23),
            };

            List<Person> filteredPeople = new();

            int slection = 1;
            int sort = 1;
            //string search = "test";
            StringBuilder search = new();

            do
            {
                int index = 1;
                filteredPeople.Clear();
                Console.Clear();
                foreach(Person person in test)
                {
                    filteredPeople.Add(person);
                }

                if(sort == 1)
                {
                    filteredPeople = filteredPeople.OrderBy(x => x.Name).ToList();
                    Console.WriteLine("Name");
                }
                else if(sort == 2)
                {
                    filteredPeople = filteredPeople.OrderBy(x => x.Age).ToList();
                    Console.WriteLine("Age");
                }

                if(search.Length > 0)
                {
                    filteredPeople = filteredPeople.Where(x => x.Name.Contains(search.ToString(), StringComparison.OrdinalIgnoreCase) 
                    || x.LastName.Contains(search.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
                }
            
                foreach(Person item in filteredPeople)
                {
                    if(index == slection)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine($"{item.Name} {item.LastName} {item.Age}");
                    Console.ResetColor();
                    index++;
                }

                Console.WriteLine(search);

                if(search.ToString().ToLower() == "exit")
                {
                    Console.WriteLine("thank you for playing.");
                    Console.WriteLine("press any key to continue.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                ConsoleKey key = Console.ReadKey().Key;

                //if char add to search
                if(char.IsLetter((char)key) || char.IsDigit((char)key))
                {
                    search.Append((char)key);
                }

    

                switch(key)
                {
                    case ConsoleKey.DownArrow:
                        if(slection < filteredPeople.Count)
                        {
                            slection++;
                            break;
                        }
                        slection = 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if(slection > 1)
                        {
                            slection--;
                            break;
                        }
                        slection = filteredPeople.Count;
                        break;
                    case ConsoleKey.RightArrow:
                        if(sort < 2)
                        {
                            sort++;
                            break;
                        }
                        sort = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if(sort > 1)
                        {
                            sort--;
                            break;
                        }
                        sort = 2;
                        break;
                    case ConsoleKey.Enter:
                        Person person = filteredPeople.ElementAt(slection - 1);
                        Console.Clear();
                        Console.WriteLine($"{person.Name} is {person.Age} years old.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Backspace:
                        if(search.Length > 0)
                        {
                            search.Remove(search.Length -1 ,1);
                        }
                        break;
                    default:
                        break;
                }
            } while(true);
        }
    }
}