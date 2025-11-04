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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        char[] chars = w.ToCharArray();
        int n = chars.Length;
        int p = -1;
        for(int i =n-2; i>=0; i--){
            if(chars[i]< chars[i+1]){
                p=i;
                break;
            }
        }
        if (p==-1){
            return "no answer";
        }
        int q= -1;
        for(int i = n-1; i>p; i--){
            if(chars[i]>chars[p]){
                q=i;
                break;
            }
        }
        char temp = chars[p];
        chars[p] = chars[q];
        chars[q] = temp;
        
        int left = p+1;
        int right = n-1;
        while(left < right){
            char tempReverse = chars[left];
            chars[left] = chars[right];
            chars[right] = tempReverse;
            left ++;
            right--;
        }
        return new string(chars);

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
