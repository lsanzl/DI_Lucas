using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using HP_Lucas_Sanz.Persistence.Manage;

namespace HP_Lucas_Sanz.Model;

public class Map
{
    public int nrows { get; set; }
    public int ncolumns { get; set; }
    public int rtarget { get; set; }
    public int ctarget { get; set; }
    public int[,] map_grid { get; set; }
    public Random r;
    public int contador0;
    public int contador1;
    public ManagePlayer managePlayer;
    public List<Player> listaJugadores;
    public Grid gridGame;

    public Map(int nrows, int ncolumns, int rtarget, int ctarget, Grid gridGame)
    {
        this.nrows = nrows;
        this.ncolumns = ncolumns;
        this.rtarget = rtarget -1;
        this.ctarget = ctarget -1;
        this.gridGame = gridGame;
        int[,] map_grid = new int[nrows, ncolumns];
        contador0 = 0;
        contador1 = 0;
        managePlayer = new ManagePlayer();
        listaJugadores = managePlayer.getPlayers();
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

        for (int i = 0; i < nrows; i++)
        {
            for (int j = 0; j < ncolumns; j++)
            {
                if (contador0 <= num0 && contador1 <= num1)
                {
                    if (r.Next(0,2) == 0)
                    {
                        map_grid[i, j] = 0;
                        contador0+=1;
                    }
                    else
                    {
                        map_grid[i, j] = 1;
                        contador1+=1;
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
    public void bucleJuego()
    {
        Boolean hanLlegado = false;
        foreach (Player p in listaJugadores)
        {
            p.checkAbilities();
        }

        while (!hanLlegado)
        {
            foreach (Player p in listaJugadores)
            {
                if (Player.wand)
                {
                    movWand();
                }
                else if (Player.ray)
                {
                    movRay();
                }
                else if (Player.brain)
                {
                    movBrain();
                }
            }
        }

    }
    public void movWand()
    {

    }
    public void movRay()
    {

    }
    public void movBrain()
    {

    }

    public Boolean checkMeta()
    {
        return false;
    }

    public static void createSPPlayers()
    {
        foreach (Player p in listaJugadores)
        {
            ;

        }
    }
}