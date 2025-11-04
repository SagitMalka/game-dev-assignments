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
     * Complete the 'surfaceArea' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY A as parameter.
     */

    public static int surfaceArea(List<List<int>> A)
    {
        int H = A.Count;
        int W = A[0].Count;
        int totalArea = 0;
        
        int[] dR = {0,1};
        int[] dC = {1, 0};
        for(int r = 0; r<H; r++){
            for(int c = 0; c<W; c++){
                int height = A[r][c];
                totalArea += (2+4*height);
                
                for(int k=0; k <2; k++){
                    int nr = r+ dR[k];
                    int nc = c + dC[k];
                    if(nr>=0 && nr <H && nc >= 0 &&nc < W){
                        int neighborHeight = A[nr][nc];
                        totalArea -= 2*Math.Min(height, neighborHeight);
                    }
                }
            }
        }
        return totalArea;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
