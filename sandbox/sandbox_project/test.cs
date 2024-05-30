using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create two sets
        HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
        HashSet<int> set2 = new HashSet<int>() { 4, 5, 6, 7, 8 };

        // Create a hash set to store intersecting values
        HashSet<int> intersectingValues = new HashSet<int>();

        // Iterate through set1 and check for intersecting values in set2
        foreach (int value in set1)
        {
            if (set2.Contains(value))
            {
                intersectingValues.Add(value);
            }
        }

        // Print the intersecting values
        Console.WriteLine("Intersecting values:");
        foreach (int value in intersectingValues)
        {
            Console.WriteLine(value);
        }
    }
}