using System;
using System.Windows;

namespace HP_Lucas_Sanz.Model;

public class Map
{
    public int nrows { get; set; }
    public int ncolumns { get; set; }
    public int rtarget { get; set; }
    public int ctarget { get; set; }
    public int[,] map_grid { get; set; }
    public Random r;

    public Map(int nrows, int ncolumns, int rtarget, int ctarget)
    {
        this.nrows = nrows;
        this.ncolumns = ncolumns;
        this.rtarget = rtarget -1;
        this.ctarget = ctarget -1;
        int[,] map_grid = new int[nrows, ncolumns];
        createMap();
    }

    public void createMap()
    {
        double totalcells = nrows * ncolumns;
        int num0;
        int num1;
        r = new Random();

        if (totalcells < 15)
        {
            num0 = 1;
            num1 = (int)totalcells - num0;
        }
        else
        {
            num0 = (int)Math.Round(totalcells/15);
            num1 = (int)totalcells - num0;
        }

        int contador0 = 0;
        int contador1 = 0;

        for (int i = 0; i < nrows; i++)
        {
            for (int j = 0; j < ncolumns; j++)
            {
                if (contador0 <= num0 && contador1 <= num1)
                {
                    if (r.Next(0,2) == 0)
                    {
                        map_grid[i, j] = 0;
                        contador0++;
                    }
                    else
                    {
                        map_grid[i, j] = 1;
                        contador1++;
                    }
                }
                else if (contador0 <= num0)
                {
                    this.map_grid[i, j] = 0;
                }
                else
                {
                    this.map_grid[i, j] = 1;
                }
            }
        }
    }
}