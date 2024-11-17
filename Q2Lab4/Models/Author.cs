using System;
using System.Collections.Generic;

namespace Q2Lab4.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Titles> Isbns { get; set; } = new List<Titles>();
}
