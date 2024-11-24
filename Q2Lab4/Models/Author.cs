using System;
using System.Collections.Generic;

namespace Q2Lab4.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<AuthorISBN> AuthorISBNs { get; set; } = new List<AuthorISBN>();

    public override string ToString()
    {
        return $"{AuthorId} - {LastName} {FirstName}";
    }
}
