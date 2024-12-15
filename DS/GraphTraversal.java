//Implementation of Graph traversal. (DFS and BFS)
import java.util.*;

public class GraphTraversal {
    private int V; // Number of vertices
    private int[][] adjMatrix; // Adjacency matrix

    // Constructor
    public GraphTraversal(int V) {
        this.V = V;
        adjMatrix = new int[V][V]; // Initialize the adjacency matrix
    }

    // Method to add an edge in an undirected graph
    public void addEdge(int u, int v) {
        adjMatrix[u][v] = 1;
        adjMatrix[v][u] = 1; // Since it's undirected, mirror the edge
    }

    // BFS Traversal
    public void bfs(int start) {
        boolean[] visited = new boolean[V];
        Queue<Integer> queue = new LinkedList<>();
        // Start from the 'start' vertex
        visited[start] = true;
        queue.offer(start);
        System.out.print("BFS Traversal: ");
        while (!queue.isEmpty()) {
            int node = queue.poll();
            System.out.print((char)(node + 65) + " "); // Convert index to char (A, B, C, ...)
            // Visit all neighbors of the current node
            for (int i = 0; i < V; i++) {
                if (adjMatrix[node][i] == 1 && !visited[i]) {
                    visited[i] = true;
                    queue.offer(i);
                }
            }
        }
        System.out.println();
    }

    // DFS Traversal
    public void dfs(int start) {
        boolean[] visited = new boolean[V];
        System.out.print("DFS Traversal: ");
        dfsUtil(start, visited);
        System.out.println();
    }

    // Utility function for DFS (recursive)
    private void dfsUtil(int node, boolean[] visited) {
        visited[node] = true;
        System.out.print((char)(node + 65) + " "); // Convert index to char (A, B, C, ...)
        // Visit all neighbors of the current node
        for (int i = 0; i < V; i++) {
            if (adjMatrix[node][i] == 1 && !visited[i]) {
                dfsUtil(i, visited);
            }
        }
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        // Get number of vertices and edges from the user
        System.out.print("Enter the number of vertices: ");
        int V = sc.nextInt();
        GraphTraversal graph = new GraphTraversal(V); // Create a graph with V ertices
        System.out.print("Enter the number of edges: ");
        int E = sc.nextInt();
        // Get edges from the user
        System.out.println("Enter the edges (u v) where u and v are vertices (0 to " + (V-1) + "):");
        for (int i = 0; i < E; i++) {
            int u = sc.nextInt();
            int v = sc.nextInt();
            if (u >= 0 && u < V && v >= 0 && v < V) {
                graph.addEdge(u, v);
            } else {
                System.out.println("Invalid edge input: vertices out of range (0 to " + (V-1) + ").");
                i--; // Decrement to retry the input
            }
        }
        // Get the start vertex for BFS and DFS
        System.out.print("Enter the start vertex for BFS and DFS (0 to " + (V-1) + "): ");
        int start = sc.nextInt();
        graph.bfs(start);
        graph.dfs(start);
        sc.close();
    }
}
