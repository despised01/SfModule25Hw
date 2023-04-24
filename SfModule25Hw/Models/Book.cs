using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfModule25Hw.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public User? user { get; set; }
    }
}
