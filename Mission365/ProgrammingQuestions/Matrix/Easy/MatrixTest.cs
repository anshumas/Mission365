using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.Matrix.Easy
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void FloodFillTest()
        {
            List<int[]> input = new List<int[]>() {
            new int[]{1,1,1},
            new int[]{1,1,0},
            new int[]{1,0,1},
            };
            int[][] result = FloodFill(input.ToArray(), 1, 1, 2);
        }
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            //visited.Push(new int[] { sr, sc });
            int oldcolor = image[sr][sc];
            if (oldcolor == newColor) return image;
            FloodFillRec(ref image, sr, sc, oldcolor, newColor);
            return image;
        }
        public void FloodFillRec(ref int[][] image, int sr, int sc, int oldColor, int newColor)
        {
            if (image[sr][sc] == oldColor)
            {
                image[sr][sc] = newColor;
                //left
                if (sr - 1 >= 0 && image[sr - 1][sc] == oldColor)
                    FloodFillRec(ref image, sr - 1, sc, oldColor, newColor);

                //right
                if (sr + 1 < image.Length && image[sr + 1][sc] == oldColor)
                    FloodFillRec(ref image, sr + 1, sc, oldColor, newColor);
                //top
                if (sc - 1 >= 0 && image[sr][sc - 1] == oldColor)
                    FloodFillRec(ref image, sr, sc - 1, oldColor, newColor);
                //bottom

                if (sc + 1 < image[sr].Length && image[sr][sc + 1] == oldColor)
                    FloodFillRec(ref image, sr, sc + 1, oldColor, newColor);

            }

        }
        Stack<int[]> visited = new Stack<int[]>();
        public int[][] FloodFill1(int[][] image, int sr, int sc, int newColor)
        {
            visited.Push(new int[] { sr, sc });
            return FloodFillVisit(image, newColor);
        }
        public int[][] FloodFillVisit(int[][] image, int newColor)
        {
            int m = image.Length - 1;
            int n = image[0].Length - 1;

            while (visited.Count > 0)
            {
                int[] point = visited.Pop();
                int sr = point[0];
                int sc = point[1];
                image[sr][sc] = newColor;

                //left
                if (sr - 1 >= 0 && image[sr - 1][sc] == 1)
                {
                    visited.Push(new int[] { sr - 1, sc });
                }
                //right
                if (sr + 1 <= m && image[sr + 1][sc] == 1)
                {
                    visited.Push(new int[] { sr + 1, sc });
                }
                //top
                if (sc - 1 >= 0 && image[sr][sc - 1] == 1)
                {
                    visited.Push(new int[] { sr, sc - 1 });
                }
                //bottom

                if (sc + 1 <= n && image[sr][sc + 1] == 1)
                {
                    visited.Push(new int[] { sr, sc + 1 });
                }

            }
            return image;
        }

        [TestMethod]
        public void MaxAreaOfIslandTest()
        {

            //List<int[]> input = new List<int[]>() {
            //new int[]{1,0,0},
            //new int[]{0,1,1},

            //};

            List<int[]> input = new List<int[]>() {
            new int[]{0,0,0,0,1,1,1,0,0,1,1,0,1,0,1,1,1,0,0,1,0,0,1,0,1,0,0,0,1,1,0,0,0,1,0,1,1,1,1},
            new int[]{0,0,0,0,0,1,1,0,1,0,0,1,0,0,0,1,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,1,0,0,1,0,1,1,0},
            new int[]{0,0,1,1,1,0,1,1,0,0,0,0,1,1,1,0,1,0,1,0,1,1,1,0,0,1,1,1,0,0,0,0,0,1,1,1,1,0,1},
            new int[]{0,1,0,0,1,1,0,1,0,1,1,0,1,0,1,0,0,1,0,0,0,0,1,1,0,1,0,0,1,1,0,1,1,0,0,1,0,1,1},
            new int[]{1,0,0,1,1,0,1,0,0,0,0,1,1,0,1,1,0,0,1,1,1,0,0,0,1,1,0,0,0,1,0,0,1,0,1,1,0,0,1},

            };
            int max = MaxAreaOfIsland(input.ToArray());
        }
        public int MaxAreaOfIsland(int[][] grid)
        {
            int max = 0;
            TraversGrid(ref grid, 0, 0, ref max);
            return max;
        }
        private void TraversGrid(ref int[][] grid, int x, int y, ref int max)
        {

            if (grid[x][y] == 1)
            {
                int i = x;
                int j = y;
                int count = 0;
                FindArea(ref grid, i, j, ref count);
                max = Math.Max(max, count);
            }

            grid[x][y] = -1;
            //left
            if (y - 1 >= 0 && grid[x][y - 1] != -1) TraversGrid(ref grid, x, y - 1, ref max);
            //right
            if (y + 1 < grid[0].Length && grid[x][y + 1] != -1) TraversGrid(ref grid, x, y + 1, ref max);
            //top
            if (x - 1 >= 0 && grid[x - 1][y] != -1) TraversGrid(ref grid, x - 1, y, ref max);
            //bottom
            if (x + 1 < grid.Length && grid[x + 1][y] != -1) TraversGrid(ref grid, x + 1, y, ref max);



        }
        private void FindArea(ref int[][] grid, int x, int y, ref int count)
        {
            if (grid[x][y] == 1)
            {
                grid[x][y] = 0;
                count++;
                //left
                if (x - 1 >= 0 && grid[x - 1][y] == 1) FindArea(ref grid, x - 1, y, ref count);
                //right
                if (x + 1 < grid.Length && grid[x + 1][y] == 1) FindArea(ref grid, x + 1, y, ref count);
                //top
                if (y - 1 >= 0 && grid[x][y - 1] == 1) FindArea(ref grid, x, y - 1, ref count);
                //bottom
                if (y + 1 < grid[0].Length && grid[x][y + 1] == 1) FindArea(ref grid, x, y + 1, ref count);
            }
        }

    }
}
