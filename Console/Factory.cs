using Data;

namespace ConsoleApp
{
    static class Factory
    {
        public static Person Create(string firstName, string lastName, int age) {
            return new Person {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
        }
    }
}
