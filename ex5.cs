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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        string noSpaceS = s.Replace(" ", "");
        int L = noSpaceS.Length;
        
        if(L==0){
            return "";
        }
        double sqrtL = Math.Sqrt(L);
        int rows = (int)Math.Floor(sqrtL);
        int cols = (int)Math.Ceiling(sqrtL);
        
        if(rows*cols < L){
            rows = cols;
        }
        StringBuilder encryptedString = new StringBuilder();
        for(int j = 0; j<cols; j++){
            for(int i =0; i< rows; i++){
                int idx = i*cols+j;
                if(idx < L){
                    encryptedString.Append(noSpaceS[idx]);
                }
            }
            if( j< cols -1){
                encryptedString.Append(" ");
            }
        }
        return encryptedString.ToString();

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
