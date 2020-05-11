using System;

namespace day11
{
    public class Solution
    {
        public int[][] img { get; set; }
        public int color { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            rows = image.Length;
            cols = image[0].Length;
            img = image;
            color = newColor;

            Fill(sr, sc, image[sr][sc]);

            return img;
        }

        public void Fill(int cx, int cy, int oldColor)
        {
            if (img[cx][cy] != oldColor) return;
            if (img[cx][cy] == color) return;

            img[cx][cy] = color;

            int[][] dirs = new int[][] {
                new int[] {-1, 0},
                new int[] {1, 0},
                new int[] {0, 1},
                new int[] {0, -1}
            };
        
            foreach (int[] newDir in dirs)
            {
                int nx = cx + newDir[0];
                int ny = cy + newDir[1];

                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols)
                {
                    Fill(nx, ny, oldColor);
                }
            }
        }
    }
}
