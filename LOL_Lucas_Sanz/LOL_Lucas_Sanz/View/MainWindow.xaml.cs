﻿using LOL_Lucas_Sanz.Model;
using LOL_Lucas_Sanz.Persistence;
using LOL_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LOL_Lucas_Sanz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Country country;
        public Team team;
        public Player player;
        public MainWindow()
        {
            InitializeComponent();
            country = new Country();
            team = new Team();
            player = new Player();
        }
        private void click_btn_start(object sender, RoutedEventArgs e)
        {
            deleteAllTables();
            country.insertCountries();
            team.insertTeams();
            player.insertPlayers();
        }
        private void deleteAllTables()
        {
            player.deletePlayers();
            team.deleteTeams();
            country.deleteCountries();
        }
    }
}
