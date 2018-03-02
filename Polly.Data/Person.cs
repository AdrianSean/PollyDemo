using System;

namespace Data
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Join(" ", Id, FirstName, LastName, Age);
        }
    }
}
