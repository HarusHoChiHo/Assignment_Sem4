using System;
using System.Collections.Generic;

namespace Q2Lab4.Models;

public partial class Titles
{
    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int EditionNumber { get; set; }

    public string Copyright { get; set; } = null!;

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
