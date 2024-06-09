namespace ConsolePacman;

/// <summary>
/// BFS Algorithm for Ghosts catching Pacman
/// </summary>
/// <param name="edges"></param>
public class Bfs(IEnumerable<Edge> edges)
{
    private IEnumerable<Edge> _edges = edges;

    public List<Position> Search(Position start, Position end)
    {
        Queue<Position> queue = new();
        queue.Enqueue(start);
        HashSet<Position> visited = [start];
        Dictionary<Position, Position> paths = new();

        while (queue.Count > 0)
        {
            var currentFrom = queue.Dequeue();
            if (currentFrom == end) return GetPath(paths, start, end);

            foreach (var (from, to) in _edges.Where(edge => edge.From == currentFrom))
            {
                if (visited.Contains(to)) continue;
                
                queue.Enqueue(to);
                visited.Add(to);

                paths[to] = from;
            }
        }

        return new List<Position>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns>the nex node to move, or start node if no path</returns>
    public Position GetNextStep(Position start, Position end)
    {
        var path = Search(start, end);
        return path.Count > 1 ? path.ElementAt(1) : start;
    }

    private List<Position> GetPath(Dictionary<Position,Position> paths, Position start, Position end)
    {
        var path = new LinkedList<Position>();
        path.AddFirst(end);
        while (path.First!.Value != start)
            path.AddFirst(paths[path.First.Value]);
        return path.ToList();
    }
}



