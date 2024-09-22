using System.Collections;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1;

class Program
{
    static void Main(string[] args)
    {
        //Question 1 - 1.1
        int[] array = new int[10]
                      {
                          1,
                          2,
                          3,
                          4,
                          5,
                          6,
                          7,
                          8,
                          8,
                          10
                      };
        
        LinkedList<int> linkedList = new LinkedList<int>();
        for (int i = 0; i < 10; i++)
        {
            linkedList.AddLast(new LinkedListNode<int>(i));
        }
        Console.WriteLine("\nQuestion 1 - 1.1: Array and LinkedList");
        Console.WriteLine($"The length of the array is: {array.Length}");
        Console.WriteLine($"Array content: {string.Join(", ", array)}");
        Console.WriteLine($"\nThe length of the LinkedList is: {linkedList.Count}");
        Console.WriteLine($"LinkedList content: {string.Join(", ", linkedList)}");
        
        //Question 1 - 1.2
        Stack<int> stack = new Stack<int>();
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < 10; i++)
        {
            stack.Push(i);
            queue.Enqueue(i);
        }
        Console.WriteLine("\nQuestion 1 - 1.2: Stack and Queue");
        Console.WriteLine($"The top element of the stack is: {stack.Peek()}");
        Console.WriteLine($"Stack: Before remove - {string.Join(", ", stack)}");
        Console.WriteLine($"Stack: Remove top item  - {stack.Pop()}");
        Console.WriteLine($"Stack: After remove - {string.Join(", ", stack)}");
        
        Console.WriteLine($"\nThe first element of the queue is: {queue.Peek()}");
        Console.WriteLine($"Stack: Before remove - {string.Join(", ", queue)}");
        Console.WriteLine($"Stack: Remove first item  - {queue.Dequeue()}");
        Console.WriteLine($"Stack: After remove - {string.Join(", ", queue)}");
        
        //Question 1 - 1.3
        Console.WriteLine("\nQuestion 1 - 1.3: Generic Constraints");
        GenericConstraintExample<NormalClass> genericConstraintExample = new GenericConstraintExample<NormalClass>();
        genericConstraintExample.DisplayClassDetails();
        
        //Question 2
        String sb = "This is to test whether the extension method count can return a right answer or not";
        Console.WriteLine("\nQuestion 2: Word Count");
        Console.WriteLine($"Sample sentence: {sb}");
        Console.WriteLine($"Total words: {sb.HarusHo()}");
        
        //Question 3
        List<Medal> medals = new List<Medal>();
        using (TextFieldParser reader = new TextFieldParser("Medals - Greatest Gold Medalist.csv"))
        {
            reader.TextFieldType = FieldType.Delimited;
            reader.SetDelimiters(",");
            reader.ReadLine();
            while (!reader.EndOfData)
            {
                string[] fields = reader.ReadFields();
                Medal medal = new Medal()
                              {
                                  Athlete     = fields[0],
                                  Year        = Convert.ToInt32(fields[1]),
                                  GoldMedal   = Convert.ToInt32(fields[2]),
                                  SilverMedal = Convert.ToInt32(fields[3]),
                                  BronzeMedal = Convert.ToInt32(fields[4])
                              };
                medals.Add(medal);
            }
        }
        
        Console.WriteLine($"\nQuestion 3: Total records read from csv - {medals.Count}");
        
        //Question 3 - 1
        Medal newMedal = new Medal()
                         {
                             Athlete = "Harus",
                             Year = 2024,
                             GoldMedal = 0,
                             SilverMedal = 0,
                             BronzeMedal = 0
                         };
        
        medals.Add(newMedal);
        Console.WriteLine("\nQuestion 3 - 1: Add new medalist");
        Console.WriteLine($"New medal: {medals.Find(x => x.Athlete.Equals("Harus"))}");
        
        //Question 3 - 2
        Console.WriteLine("\nQuestion 3 - 2: Delete specific medalist");
        Console.WriteLine($"Deleted {medals.RemoveAll(x => x.Athlete.Equals("Zou Kai"))} item with name \"Zou Kai\" ");
        Console.WriteLine($"\nIs \"Zou Kai\" exist? {medals.Exists(x => x.Athlete.Equals("Zou Kai"))}");
        
        //Question 3 - 3
        Console.WriteLine("\nQuestion 3 - 3: Implementation of Generic Search method");
        List<Medal> filteredList = medals.Search(x => x.Year == 2024).ToList();
        Console.WriteLine("Search the medal records for the year of 2024.\nResult: ");
        foreach (var medal in filteredList)
        {
            Console.WriteLine(medal);
        }
    }

    // T Search<T>(T list, Func<T, bool> search) where T : IEnumerable<T>, new()
    // {
    //     T results = new T();
    //     foreach (var item in list)
    //     {
    //         if (search(item))
    //         {
    //             results.Append(item);
    //         }
    //     }
    //
    //     return results;
    // }
}

public class GenericConstraintExample<T> where T : class, new()
{
    public void DisplayClassDetails()
    {
        T t = new T();
        Console.WriteLine($"Type: {t.GetType()}");
        Console.WriteLine($"Message of T: {t}");
    }
}

public class NormalClass
{

    public override string ToString()
    {
        return "This is NormalClass";
    }
}

public static class StringBuilder
{
    public static int HarusHo(this string str)
    {
        return str
               .Split(" ")
               .Length;
    }
}

public class Medal
{
    public String Athlete {get; set;}
    public int Year {get; set;}
    public int GoldMedal {get; set;}
    public int SilverMedal {get; set;}
    public int BronzeMedal {get; set;}

    public override string ToString()
    {
        return $"Athlete: {Athlete}, Year: {Year}, Gold Medal: {GoldMedal}, Silver Medal: {SilverMedal}, Bronze Medal: {BronzeMedal}";
    }
}

//For question 3 - 3
public static class MedalSearch
{
    public static IEnumerable<T> Search<T>(this IEnumerable<T> list,
                                          Func<T, bool>       predicate)
    {
        IEnumerable<T> results = new List<T>();

        foreach (T item in list)
        {
            if (predicate(item))
            {
                results = results.Append(item);
            }
        }

        return results;
    }
}
