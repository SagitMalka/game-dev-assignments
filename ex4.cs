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
     * Complete the 'organizingContainers' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts 2D_INTEGER_ARRAY container as parameter.
     */

    public static string organizingContainers(List<List<int>> container)
    {
        int numOfContainers = container.Count;
        
        //num of balls in each container
        List<long> ballsInEach = new List<long>();
        for(int i=0; i<numOfContainers; i++){
            ballsInEach.Add(container[i].Sum(x => (long)x));
        }
        //count the types in each
        List<long> typesInEach = new List<long>();
        for(int j=0; j<numOfContainers; j++){
            long currTypeCount = 0;
            for(int i=0; i<numOfContainers; i++){
                currTypeCount += container[i][j];
            }
            typesInEach.Add(currTypeCount);
        }
        ballsInEach.Sort();
        typesInEach.Sort();
        
        for(int i = 0; i<numOfContainers; i++){
            if(ballsInEach[i] != typesInEach[i]){
                return "Impossible";
            }
        }
        return "Possible";

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Result.organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
