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

class Solution {

    private static int removableEdges;
    private static Dictionary<int, List<int>> adj;
    private static int DFS(int u, int parent){
        int currentSubtreeSize = 1;
        foreach (int v in adj[u])
        {
            if (v != parent)
            {
                int childSubtreeSize = DFS(v, u);
                if (childSubtreeSize % 2 == 0)
                {
                    removableEdges++;
                }
                else{
                    currentSubtreeSize += childSubtreeSize;
                }
            }
        }
        return currentSubtreeSize;
    }

    public static int evenForest(int t_nodes, int t_edges, List<int> t_from, List<int> t_to)
    {
        removableEdges = 0;
        adj = new Dictionary<int, List<int>>();
        for (int i = 1; i <= t_nodes; i++)
        {
            adj.Add(i, new List<int>());
        }
        for (int i = 0; i < t_edges; i++)
        {
            int u = t_from[i];
            int v = t_to[i];
            adj[u].Add(v);
            adj[v].Add(u);
        }

        DFS(1, 0);
        return removableEdges;
    }


    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] tNodesEdges = Console.ReadLine().TrimEnd().Split(' ');

        int tNodes = Convert.ToInt32(tNodesEdges[0]);
        int tEdges = Convert.ToInt32(tNodesEdges[1]);

        List<int> tFrom = new List<int>();
        List<int> tTo = new List<int>();

        for (int i = 0; i < tEdges; i++) {
            string[] tFromTo = Console.ReadLine().TrimEnd().Split(' ');

            tFrom.Add(Convert.ToInt32(tFromTo[0]));
            tTo.Add(Convert.ToInt32(tFromTo[1]));
        }

        int res = evenForest(tNodes, tEdges, tFrom, tTo);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
