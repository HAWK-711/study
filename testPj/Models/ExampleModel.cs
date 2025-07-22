using System;

namespace testPj.Models
{
    public class ExampleModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Gender { get; set; }
    }
}