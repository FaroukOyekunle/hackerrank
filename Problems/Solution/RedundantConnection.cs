namespace Problems.Solution
{
    public class RedundantConnection
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            int[] parent = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
            }

            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                int parentU = Find(parent, u);
                int parentV = Find(parent, v);

                if (parentU == parentV)
                {
                    return edge;
                }
                parent[parentV] = parentU;
            }

            return new int[0];
        }

        private int Find(int[] parent, int node)
        {
            if (parent[node] != node)
            {
                parent[node] = Find(parent, parent[node]);
            }
            return parent[node];
        }
    }
}