// See https://aka.ms/new-console-template for more information

using Q1Lab4;

Console.WriteLine("Question 01 - Lab 04");

// Invokes methods
Question1_1();
Question1_2();
Question1_3();
Question1_4();
Question1_5();
Question1_6();


// 1.1 List the names of the countries in alphabetical order [0.5 mark]
void Question1_1()
{
    Console.WriteLine("\nQuestioin 1.1");
    List<String> countries = Country
                             .GetCountries()
                             .OrderBy(country => country.Name)
                             .Select(country => country.Name)
                             .ToList();

    foreach (String name in countries)
    {
        Console.WriteLine(name);
    }
}

// 1.2 List the names of the countries in descending order of number of resources [0.5 mark]
void Question1_2()
{
    Console.WriteLine("\nQuestioin 1.2");
    List<String> countries = Country
                             .GetCountries()
                             .OrderByDescending(country => country.Resources.Count)
                             .Select(country => country.Name)
                             .ToList();

    foreach (String name in countries)
    {
        Console.WriteLine(name);
    }
}

// 1.3 List the names of the countries that shares a border with Argentina [0.5 mark]
void Question1_3()
{
    Console.WriteLine("\nQuestioin 1.3 Countries that share a border with Argentina:");
    List<String> argentinaBorders = Country
                                    .GetCountries()
                                    .First(c => c.Name == "Argentina")
                                    .Borders;

    foreach (String country in argentinaBorders)
    {
        Console.WriteLine(country);
    }
}

// 1.4 List the names of the countries that has more than 10,000,000 population [0.5 mark]
void Question1_4()
{
    Console.WriteLine("\n1.4 Countries with population over 10,000,000:");
    List<String> countries = Country
                             .GetCountries()
                             .Where(c => c.Population > 10000000)
                             .Select(c => c.Name)
                             .ToList();
    foreach (String country in countries)
    {
        Console.WriteLine(country);
    }
}

// 1.5 List the country with highest population [1 mark]
void Question1_5()
{
    Console.WriteLine("\n1.5 Country with the highest population:");
    int highestPopulation = Country
                            .GetCountries()
                            .Max(country => country.Population);
    List<String> countriesWithHighestPopulation = Country
                                                  .GetCountries()
                                                  .Where(country => country.Population == highestPopulation)
                                                  .Select(country => country.Name)
                                                  .ToList();

    foreach (String name in countriesWithHighestPopulation)
    {
        Console.WriteLine(name);
    }
}

// 1.6 List all the religion in south America in dictionary order [1 mark]
void Question1_6()
{
    Console.WriteLine("\n1.6 All religions in South America in dictionary order:");
    List<String> allReligions = Country
                       .GetCountries()
                       .SelectMany(c => c.Religions)
                       .Distinct()
                       .OrderBy(r => r)
                       .ToList();
    
    foreach (String religion in allReligions)
    {
        Console.WriteLine(religion);
    }
}