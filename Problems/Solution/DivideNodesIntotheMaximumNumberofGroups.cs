namespace Problems.Solution
{
    public class DivideNodesIntotheMaximumNumberofGroups
    {
        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var edge in edges) 
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        int[] colors = new int[n + 1]; 
        Array.Fill(colors, 0);

        List<HashSet<int>> components = new List<HashSet<int>>();
        bool isPossible = true;

        for (int i = 1; i <= n; i++) 
        {
            if (colors[i] == 0) 
            {
                Queue<int> queue = new Queue<int>();
                HashSet<int> component = new HashSet<int>();
                queue.Enqueue(i);
                colors[i] = 1;
                component.Add(i);

                while (queue.Count > 0) 
                {
                    int node = queue.Dequeue();
                    foreach (int neighbor in graph[node]) 
                    {
                        if (colors[neighbor] == 0) 
                        {
                            colors[neighbor] = -colors[node];
                            queue.Enqueue(neighbor);
                            component.Add(neighbor);
                        } 
                        
                        else if (colors[neighbor] == colors[node]) 
                        {
                            return -1; 
                        }
                    }
                }
                components.Add(component);
            }
        }

        int maxGroups = 0;
        foreach (var component in components)
        {
            maxGroups += GetMaxDepth(graph, component);
        }

        return maxGroups;
    }

    private int GetMaxDepth(List<int>[] graph, HashSet<int> component) 
    {
        int maxDepth = 0;
        foreach (int node in component)
        {
            maxDepth = Math.Max(maxDepth, BFSDepth(graph, node, component));
        }

        return maxDepth;
    }

    private int BFSDepth(List<int>[] graph, int start, HashSet<int> component) 
    {
        Queue<int> queue = new Queue<int>();
        Dictionary<int, int> depth = new Dictionary<int, int>();
        queue.Enqueue(start);
        depth[start] = 1;
        int maxDepth = 1;

        while (queue.Count > 0) 
        {
            int node = queue.Dequeue();
            foreach (int neighbor in graph[node]) 
            {
                if (component.Contains(neighbor) && !depth.ContainsKey(neighbor)) 
                {
                    depth[neighbor] = depth[node] + 1;
                    maxDepth = Math.Max(maxDepth, depth[neighbor]);
                    queue.Enqueue(neighbor);
                }
            }
        }
        return maxDepth;
    }
}
