using System.Text;

namespace test
{
    internal class Program
    {
        static void Main()
        {
            List<Person> test = new()
            {
                new("tom","cluck",25),
                new("Dave","bob",43),
                new("bob","Dave",45),
                new("Steve","salfjn",57),
                new("henry","ddieasln",67),
                new("nick","Henry",12),
                new("troy","Wilson",23),
                new("tom","shuck",31),
                new("Dave","bob",45),
                new("bob","Dave",45),
                new("Steve","salfjn",57),
                new("henry","ddieasln",67),
                new("nick","hen-ryes",12),
                new("troy","Wilson",23),
            };

            List<Person> filteredPeople = new();

            int slection = 1;
            int sort = 1;
            StringBuilder search = new();

            do
            {
                int index = 1;
                filteredPeople.Clear();
                Console.Clear();
                
                //Adds items from list to filtered list
                foreach(Person person in test)
                {
                    filteredPeople.Add(person);
                }

                // Chooses the sort type 
                if(sort == 1)
                {
                    filteredPeople = filteredPeople.OrderBy(x => x.Name).ToList();
                    Console.WriteLine("Name");
                }
                if(sort == 2)
                {
                    filteredPeople = filteredPeople.OrderBy(x => x.LastName).ToList();
                    Console.WriteLine("Last Name");
                }
                else if(sort == 3)
                {
                    filteredPeople = filteredPeople.OrderBy(x => x.Age).ToList();
                    Console.WriteLine("Age");
                }

                // Applies the search criteria
                if(search.Length > 0)
                {
                    filteredPeople = filteredPeople.Where(x => x.Name.Contains(search.ToString(), StringComparison.OrdinalIgnoreCase)
                    || x.LastName.Contains(search.ToString(), StringComparison.OrdinalIgnoreCase)
                    || x.Age.ToString().Contains(search.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
                }
                Console.WriteLine();
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
                if(slection == filteredPeople.Count + 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                Console.WriteLine();
                Console.WriteLine("Exit");
                Console.ResetColor();
                Console.WriteLine(search);

                ConsoleKey key = Console.ReadKey().Key;

                //if char add to search
                if(char.IsLetter((char)key) || char.IsDigit((char)key) || char.IsWhiteSpace((char)key))
                {
                    search.Append((char)key);
                }



                switch(key)
                {
                    case ConsoleKey.DownArrow:
                        if(slection < filteredPeople.Count + 1)
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
                        slection = filteredPeople.Count + 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if(sort < 3)
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
                        sort = 3;
                        break;     
                    case ConsoleKey.Backspace:
                        if(search.Length > 0)
                        {
                            search.Remove(search.Length - 1, 1);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if(slection == filteredPeople.Count + 1)
                        {
                            Console.Clear();
                            Console.WriteLine("thank you for playing.");
                            Console.WriteLine("press any key to continue.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        Person person = filteredPeople.ElementAt(slection - 1);
                        Console.Clear();
                        Console.WriteLine($"{person.Name} is {person.Age} years old.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        search.Clear();
                        break;
                    default:
                        break;
                }
            } while(true);
        }
    }
}