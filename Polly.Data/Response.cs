using Data;
using System;
using System.Collections.Generic;

namespace Data
{
    public class Response
    {        
        public bool Sucess { get; set; }
        public Exception Error { get; set; }

        public Person Person { get; set; }
        public IReadOnlyList<Person> People { get; set; }
    }
}