using P2Hito3_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
{
    /// <summary>
    /// Class to insert values into Heat table
    /// </summary>
    public class ManageHeat
    {
        /// <summary>
        /// Inserts the heat into MySQL
        /// </summary>
        /// <param name="t">Actual tournament</param>
        /// <param name="te">Actual team playing that tournament</param>
        public void insertHeat(Tournament t, Team te)
        {
            DBBroker.getAgent().executeSQL($"insert into leagueoflegends.heat (idTournament, idTeam) values ('{t.idTournament}','{te.idTeam}');");
        }
    }
}
