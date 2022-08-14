namespace test
{
    public class Person
    {
        private static int id = 1;
        public int ID { get; private set;}
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(string name,string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            ID = id;
            id++;
        }
    }
}
