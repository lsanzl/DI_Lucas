using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using HP_Lucas_Sanz.Persistence.Manage;

namespace HP_Lucas_Sanz.Model;

/// <summary>
/// Clase objeto Map
/// </summary>
public class Map
{
    public int nrows { get; set; }
    public int ncolumns { get; set; }
    public int rtarget { get; set; }
    public int ctarget { get; set; }
    public int[,] map_grid { get; set; }
    public Random r;
    public ManagePlayer managePlayer;
    public List<Player> listaJugadores;

    /// <summary>
    /// Constructor objeto Map
    /// </summary>
    /// <param name="nrows">Número de filas</param>
    /// <param name="ncolumns">Número de columnas</param>
    /// <param name="rtarget">Fila objetivo</param>
    /// <param name="ctarget">Columna objetivo</param>
    public Map(int nrows, int ncolumns, int rtarget, int ctarget)
    {
        r = new Random();
        this.nrows = nrows;
        this.ncolumns = ncolumns;
        this.rtarget = rtarget -1;
        this.ctarget = ctarget -1;
        int[,] map_grid = new int[nrows, ncolumns];
        managePlayer = new ManagePlayer();
        listaJugadores = managePlayer.getPlayers();
    }
}