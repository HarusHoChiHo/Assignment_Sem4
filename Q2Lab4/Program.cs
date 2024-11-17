// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Q2Lab4.Models;

BooksDbContext booksDbContext = new BooksDbContext();

Console.WriteLine("Question 02 - Lab 04");

// Invokes methods
Question2_1();
Question2_2();
Question2_3();

//1.Get a list of all the titles and the authors who wrote them. Sort the results by title. [2 marks]
void Question2_1()
{
	Console.WriteLine("Question 2.1");
	var titles = booksDbContext.Titles
	.Include(t => t.Authors)
	.OrderBy(t => t.Title)
	.Select(t => new
	{
		Title = t.Title,
		Authors = t.Authors.Select(a => $"{a.FirstName} {a.LastName}")
	})
	.ToList();

	foreach (var t in titles)
	{
		Console.WriteLine($"Title: {t.Title}\nAuthor:{string.Join(", ",t.Authors)}\n");
	}
}

//2.Get a list of all the titles and the authors who wrote them. Sort the results by title.  Each title sort the authors alphabetically by last name, then first name[4 marks]
void Question2_2()
{
	Console.WriteLine("Question 2.2");
	var titles = booksDbContext.Titles
	.Include(t => t.Authors)
	.OrderBy(t => t.Title)
	.Select(t => new
	{
		Title = t.Title,
		Authors = t.Authors
			.OrderBy(a => a.LastName)
			.ThenBy(a => a.FirstName)
			.Select(a => $"{a.FirstName} {a.LastName}")
	})
	.ToList();

    foreach (var t in titles)
    {
		Console.WriteLine($"Title: {t.Title}\nAuthor:{string.Join(", ", t.Authors)}\n");
	}
}

//3.Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name then first name.[4 marks]
void Question2_3()
{
	Console.WriteLine("Question 2.3");
	var titles = booksDbContext.Titles
	.Include(t => t.Authors)
	.OrderBy(t => t.Title)
	.Select(t => new
	{
		Title = t.Title,
		Authors = t.Authors
			.OrderBy(a => a.LastName)
			.ThenBy(a => a.FirstName)
			.Select(a => $"{a.FirstName} {a.LastName}")
	})
	.ToList();

	foreach (var t in titles)
	{
		Console.WriteLine($"Title: {t.Title}\nAuthor:{string.Join(", ", t.Authors)}\n");
	}
}
