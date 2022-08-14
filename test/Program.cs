namespace test
{
    internal class Program
    {
        static void Main()
        {
            List<Person> test = new()
            {
                new("tom",31),
                new("dave",45),
                new("dick",51)
            };

            int slection = 1;

            do
            {
                int index = 1;
                Console.Clear();
                foreach(Person item in test)
                {
                    if(index == slection)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine($"{item.ID}: {item.Name}");
                    Console.ResetColor();
                    index++;
                }

                Console.WriteLine("Key");
                ConsoleKey key = Console.ReadKey().Key;
                switch(key)
                {
                    case ConsoleKey.DownArrow:
                        if(slection < test.Count)
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
                        slection = test.Count;
                        break;
                    case ConsoleKey.Enter:
                        Person person = test.ElementAt(slection - 1);
                        Console.Clear();
                        Console.WriteLine($"{person.Name} is {person.Age} years old.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while(true);
        }
    }
}