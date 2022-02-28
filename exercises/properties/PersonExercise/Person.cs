using System;

namespace PersonExercise
{
    public class Person
    {
        private int age;
        private string name;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age
        {
            get { return this.age; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Kan niet kleiner dan 0 zijn.");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                this.name = value;
            }
        }
    }
}
