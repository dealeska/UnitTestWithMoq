using System;

namespace TestingMPPLab3
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = "No name";
            Age = 0;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Person name: {Name}, age: {Age}";
        }

        public override bool Equals(object obj)
        {
            Person p = obj as Person;
            if (p != null)
                return Name.Equals(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < Name.Length; i++)
            {
                hashCode += Name[i];
            }
            hashCode += Age * 100;

            return hashCode;
        }
    }
}
