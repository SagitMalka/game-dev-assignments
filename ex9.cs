using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'countSort' function below.
     *
     * The function accepts 2D_STRING_ARRAY arr as parameter.
     */

public static void countSort(List<List<string>> arr)
{
    int n = arr.Count;
    List<string>[] bucket = new List<string>[100];
    
    for (int i = 0; i < 100; i++)
    {
        bucket[i] = new List<string>();
    }

    for (int i = 0; i < n; i++)
    {
        int key = Convert.ToInt32(arr[i][0]);
        string s = arr[i][1];
        string valueToStore;
        
        if (i < n / 2)
        {
            valueToStore = "-";
        }
        else
        {
            valueToStore = s;
        }

        bucket[key].Add(valueToStore);
    }

    StringBuilder result = new StringBuilder();
    for (int i = 0; i < 100; i++)
    {
        foreach (string s in bucket[i])
        {
            result.Append(s);
            result.Append(" ");
        }
    }
    Console.WriteLine(result.ToString().TrimEnd());
}

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> arr = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        Result.countSort(arr);
    }
}
