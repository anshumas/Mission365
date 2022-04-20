using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.Matrix.Medium
{

    [TestClass]
    public class P200NumberOfIslands
    {
        [TestMethod]
        public void NumberOfIslandsTest()
        {
            List<char[]> grid = new List<char[]>()
            {
                new char[]{'1', '1', '1', '1', '0'},
                new char[]{'1', '1', '0', '1', '0'},
                new char[]{'1', '1', '0', '0', '0'},
                new char[]{'0', '0', '0', '0', '0'},
            };
            int ans = NumIslands(grid.ToArray());
        }
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        DFS(grid, i, j);
                        count++;
                    }
                }
            }
            return count;
        }
        public void DFS(char[][] grid, int i, int j)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (i < 0 || j < 0 || i >= m || j >= n || grid[i][j] == '0')
            {
                return;
            }
            grid[i][j] = '0';
            DFS(grid, i - 1, j);
            DFS(grid, i + 1, j);
            DFS(grid, i, j - 1);
            DFS(grid, i, j + 1);

        }

    }
}
