using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2Lab4.Models
{
    public class AuthorISBN
    {
        public int AuthorId { get; set; }
        public string Isbn { get; set; }

        public Author Author { get; set; }
        public Titles Titles { get; set; }
    }
}
