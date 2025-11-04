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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
{
    string[] wordMap = {
        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
        "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
        "twenty", "twenty one", "twenty two", "twenty three", "twenty four", "twenty five", "twenty six", "twenty seven", "twenty eight", "twenty nine"
    };

    string result = "";
    if (m == 0){
        return $"{wordMap[h]} o' clock";
    }
    else if (m >= 1 && m <= 30){
        string minutePart = "";
            if (m == 15){
            minutePart = "quarter";
            }
            else if (m == 30){
            minutePart = "half";
            }
            else{
            string minuteSingularOrPlural = (m == 1) ? "minute" : "minutes";
            minutePart = $"{wordMap[m]} {minuteSingularOrPlural}";
            }
        result = $"{minutePart} past {wordMap[h]}";
    }

    else {
        int remainingMinutes = 60 - m;
        int nextH = (h % 12) + 1;
        string minutePart = "";
        if (remainingMinutes == 15){
            minutePart = "quarter";
        }
        else{
            string minuteSingularOrPlural = (remainingMinutes == 1) ? "minute" : "minutes";
            minutePart = $"{wordMap[remainingMinutes]} {minuteSingularOrPlural}";
        }
        result = $"{minutePart} to {wordMap[nextH]}";
    }

    return result;
}

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
