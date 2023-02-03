﻿using P2Hito3_Lucas_Sanz.Persistence.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Model
{
    public class Team
    {
        public int idTeam { get; set; }
        public string name { get; set; }
        public string imageSrc { get; set; }
        public ManageTeam manage_team { get; set; }

        public Team()
        {
            this.manage_team = new ManageTeam();
        }
        public Team(string name, string imageSrc)
        {
            this.name = name;
            this.imageSrc = imageSrc;
            this.manage_team = new ManageTeam();
        }
        public void insertTeams()
        {
            this.manage_team.insertTeams();
        }
        public void deleteTeams()
        {
            this.manage_team.deleteAll();
        }
    }
}
