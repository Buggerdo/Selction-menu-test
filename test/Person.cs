namespace test
{
    public class Person
    {
        private static int id = 1;
        public int ID { get; private set;}
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            ID = id;
            id++;
        }
    }
}
