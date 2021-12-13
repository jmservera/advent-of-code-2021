using System;
using System.Collections.Generic;
using System.Linq;

public class Vents
{
    List<int[]> lines = new List<int[]>();
    int[][] grid;

    int maxX, maxY;

    public Vents(string[] vents)
    {

        for (int i = 0; i < vents.Length; i++)
        {
            var coords = vents[i].Split(" -> ");
            var start = coords[0].Split(",").Select(int.Parse).ToArray();
            var end = coords[1].Split(",").Select(int.Parse).ToArray();

            maxX = Math.Max(maxX, Math.Max(start[0], end[0]));
            maxY = Math.Max(maxY, Math.Max(start[1], end[1]));
            lines.Add(new int[] { start[0], start[1], end[0], end[1] });
        }

    }

    void initGrid()
    {
        grid = new int[maxY + 1]
            .Select(x => new int[maxX + 1])
            .ToArray();
    }

    int countVents()
    {
        int count = 0;
        for (int x = 0; x < grid[0].Length; x++)
        {
            for (int y = 0; y < grid.Length; y++)
            {
                if (grid[y][x] >= 2)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public int Solve()
    {
        initGrid();

        foreach (var line in lines)
        {
            if (line[0] == line[2] || line[1] == line[3])
            {
                generateLine(line);
            }
        }

        printGrid();

        return countVents();
    }

    private void printGrid()
    {
        Console.WriteLine();
        for (int y = 0; y < grid.Length; y++)
        {
            Console.WriteLine(string.Join("", grid[y]).Replace('0','.'));
        }
    }

    public object SolveDiag()
    {
        initGrid();

        foreach (var line in lines)
        {
            generateLine(line);
        }

        printGrid();

        return countVents();
    }

    private void generateLine(int[] line)
    {
        IEnumerable<int> xrange, yrange;
        if (line[0] < line[2])
        {
            xrange = Enumerable.Range(line[0], line[2] - line[0] + 1);
        }
        else
        {
            xrange = Enumerable.Range(line[2], line[0] - line[2] + 1).Reverse();
        }
        if (line[1] < line[3])
        {
            yrange = Enumerable.Range(line[1], line[3] - line[1] + 1);
        }
        else
        {
            yrange = Enumerable.Range(line[3], line[1] - line[3] + 1).Reverse();
        }

        if(xrange.Count()<yrange.Count())
        {
            xrange=Enumerable.Repeat(line[0], yrange.Count());
        }
        else if(xrange.Count()>yrange.Count())
        {
            yrange = Enumerable.Repeat(line[1], xrange.Count());
        }
        
        var y=yrange.GetEnumerator();
        foreach (var x in xrange)
        {
            y.MoveNext();
            grid[y.Current][x]++;
        }

    }
}