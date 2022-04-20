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


        [TestMethod]
        public void UpdateMatrixTest()
        {
            //List<int[]> input = new List<int[]>() {
            //new int[]{0,0,0,0,1,1,1,0,0,1,1,0,1,0,1,1,1,0,0,1,0,0,1,0,1,0,0,0,1,1,0,0,0,1,0,1,1,1,1},
            //new int[]{0,0,0,0,0,1,1,0,1,0,0,1,0,0,0,1,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,1,0,0,1,0,1,1,0},
            //new int[]{0,0,1,1,1,0,1,1,0,0,0,0,1,1,1,0,1,0,1,0,1,1,1,0,0,1,1,1,0,0,0,0,0,1,1,1,1,0,1},
            //new int[]{0,1,0,0,1,1,0,1,0,1,1,0,1,0,1,0,0,1,0,0,0,0,1,1,0,1,0,0,1,1,0,1,1,0,0,1,0,1,1},
            //new int[]{1,0,0,1,1,0,1,0,0,0,0,1,1,0,1,1,0,0,1,1,1,0,0,0,1,1,0,0,0,1,0,0,1,0,1,1,0,0,1},

            //};
            List<int[]> input = new List<int[]>() {
            new int[]{0,0,0,0},
            new int[]{0,1,0,0},
            new int[]{1,1,1,0},
            
            };
            var max = UpdateMatrix(input.ToArray());
        }
        class pair
        {
            public int i;
            public int j;
            public pair(int a, int b)
            {
                i = a; j = b;
            }
        }

        Dictionary<string, pair> needTovisiting = new Dictionary<string, pair>();
        Dictionary<string, pair> visiting = new Dictionary<string, pair>();
        public int[][] UpdateMatrix(int[][] mat)
        {

            int row = mat.Length;
            int col = mat[0].Length;
            int[][] result = new int[row][];
            for (int i = 0; i < row; i++)
            {
                result[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        result[i][j] = Int32.MaxValue;
                        needTovisiting.Add(i + "_" + j, new pair(i, j));
                    }
                }
            }
            foreach (var item in needTovisiting)
            {
                var pair = item.Value;
                int x = pair.i;
                int y = pair.j;
                if (result[x][y] != Int32.MaxValue) continue;

                int left = Int32.MaxValue;
                int right = Int32.MaxValue;
                int top = Int32.MaxValue;
                int bottom = Int32.MaxValue;
                visiting.Add(x + "_" + y, new pair(x, y));
                if (y - 1 >= 0)
                {
                    left = FindandUpate(ref result, x, y - 1);
                    if (left == 0) { 
                        result[x][y] = 1;
                        continue;
                    }
                }
                if (y + 1 < col)
                {
                    right = FindandUpate(ref result, x, y + 1);
                    if (right == 0)
                    {
                        result[x][y] = 1;
                        continue;
                    }
                }
                if (x - 1 >= 0)
                {
                    top = FindandUpate(ref result, x - 1, y);
                    if (top == 0)
                    {
                        result[x][y] = 1;
                        continue;
                    }
                }
                if (x + 1 < row)
                {
                    bottom = FindandUpate(ref result, x + 1, y);
                    if (bottom == 0)
                    {
                        result[x][y] = 1;
                        continue;
                    }
                }
               
                result[x][y] = Math.Min(bottom, Math.Min(top, Math.Min(left, right))) + 1;

            }

            return result;
        }
        public int FindandUpate(ref int[][] mat, int x, int y)
        {
            int row = mat.Length;
            int col = mat[0].Length;
            if (mat[x][y] == 0) return 0;
            if (mat[x][y] != Int32.MaxValue) return mat[x][y];
            if (visiting.ContainsKey(x + "_" + y)) return Int32.MaxValue;
            visiting.Add(x + "_" + y, new pair(x, y));
            int left = Int32.MaxValue;
            int right = Int32.MaxValue;
            int top = Int32.MaxValue;
            int bottom = Int32.MaxValue;
            if (y - 1 >= 0)
            {
                left = FindandUpate(ref mat, x, y - 1);
                if (left == 0)
                {
                    mat[x][y] = 1;
                    return 0;
                }
            }
            if (y + 1 < col)
            {
                right = FindandUpate(ref mat, x, y + 1);
                if (right == 0)
                {
                    mat[x][y] = 1;
                    return 0;
                }
            }
            if (x - 1 >= 0)
            {
                top = FindandUpate(ref mat, x - 1, y);
                if (top == 0)
                {
                    mat[x][y] = 1;
                    return 0;
                }
            }
            if (x + 1 < row)
            {
                bottom = FindandUpate(ref mat, x + 1, y);
                if (bottom == 0)
                {
                    mat[x][y] = 1;
                    return 0;
                }
            }

            mat[x][y] = Math.Min(bottom, Math.Min(top, Math.Min(left, right))) + 1;
            return Math.Min(bottom, Math.Min(top, Math.Min(left, right)))+1;
        }

        public int[][] UpdateMatrix1(int[][] mat)
        {
            int row = mat.Length;
            int col = mat[0].Length;

            int[][] dp = new int[row][];

            for (int i = 0; i < row; i++)
            {
                dp[i] = new int[col];
                for (int j = 0; j < col; j++)
                {

                    if (mat[i][j] == 1)
                    {
                        dp[i][j] = Int32.MaxValue;
                    }
                }
            }

            Queue<Pair> Q = new Queue<Pair>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        Q.Enqueue(new Pair(i, j));
                    }
                }
            }

            while (Q.Count > 0)
            {
                Pair p = Q.Dequeue();
                int x = p.x;
                int y = p.y;

                for (int i = 0; i < 4; i++)
                {
                    int newx = xdir[i] + x;
                    int newy = ydir[i] + y;
                    if (newx >= 0 && newy >= 0 && newx < row && newy < col && dp[newx][newy] > dp[x][y] + 1)
                    {
                        dp[newx][newy] = dp[x][y] + 1;
                        Q.Enqueue(new Pair(newx, newy));
                    }
                }
            }

            return dp;


        }

        int[] xdir = { 1, 0, -1, 0 };
        int[] ydir = { 0, 1, 0, -1 };

        public class Pair
        {
            public int x;
            public int y;
            public Pair(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }


    }
}
