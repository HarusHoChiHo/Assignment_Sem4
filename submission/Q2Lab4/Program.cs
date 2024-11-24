// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Q2Lab4.Models;

BooksDbContext booksDbContext = new BooksDbContext();
booksDbContext.Titles.Load();
booksDbContext.Authors.Load();
booksDbContext.AuthorISBN.Load();

Console.WriteLine("Question 02 - Lab 04");

// Invokes methods
Question2_1();
Question2_2();
Question2_3();

//1.Get a list of all the titles and the authors who wrote them. Sort the results by title. [2 marks]
void Question2_1()
{
	Console.WriteLine("Question 2.1");

	var titles = from title in booksDbContext.Titles
				 join author_i in booksDbContext.AuthorISBN on title.Isbn equals author_i.Isbn
				 join author in booksDbContext.Authors on author_i.AuthorId equals author.AuthorId
				 orderby title.Title
				 select new
				 {
					 Title = title.ToString(),
					 Author = author.ToString()

                 };

	foreach (var t in titles)
	{
		Console.WriteLine($"Titles: {t.Title}\nAuthors:{t.Author}\n");
	}
}

//2.Get a list of all the titles and the authors who wrote them. Sort the results by title.  Each title sort the authors alphabetically by last name, then first name[4 marks]
void Question2_2()
{
	Console.WriteLine("Question 2.2");

	var titles = from title in booksDbContext.Titles
                 join author_i in booksDbContext.AuthorISBN on title.Isbn equals author_i.Isbn
                 join author in booksDbContext.Authors on author_i.AuthorId equals author.AuthorId
                 orderby title.Title, author.LastName, author.FirstName
				 select new
				 {
					 Title = title.ToString(),
					 Author = author.ToString()
				 };

    foreach (var t in titles)
    {
		Console.WriteLine($"Titles: {t.Title}\nAuthors:{t.Author}\n");
	}
}

//3.Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name then first name.[4 marks]
void Question2_3()
{
	Console.WriteLine("Question 2.3");

	var titles =  from title in booksDbContext.Titles
                 join author_i in booksDbContext.AuthorISBN on title.Isbn equals author_i.Isbn
                 join author in booksDbContext.Authors on author_i.AuthorId equals author.AuthorId
				 orderby title.Title, author.LastName, author.FirstName
				 group author by title.Title into author_group
				 select new
				 {
					 Title = author_group.Key,
					 Authors = (from a in author_group.ToList()
							   orderby a.LastName, a.FirstName
							   select a).ToList()
				 };

	foreach (var t in titles)
	{
		Console.WriteLine($"Titles: {t.Title}\nAuthors:{string.Join(", ", t.Authors)}\n");
	}
}
