using System;

namespace ConsoleApp
{
    static class NameGenerator
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Generate() {
            
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++) {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
