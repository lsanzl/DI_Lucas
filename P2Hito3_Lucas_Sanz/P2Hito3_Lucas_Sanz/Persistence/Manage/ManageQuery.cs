using P2Hito3_Lucas_Sanz.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
{
    public class ManageQuery
    {
        DataTable table1to4;
        DataTable table5;
        DataRow dr;
        List<Object> list_datos;

        public DataTable Consulta1()
        {
            table1to4 = new DataTable("Consultas1al4");

            table1to4.Columns.Add("Nombre Equipo");
            table1to4.Columns.Add("Nickname Jugador");
            table1to4.Columns.Add("Titularidad");

            
            list_datos = DBBroker.getAgent().readSQL(@"select t.name, p.nickName, p.type 
                                        from leagueoflegends.team t, leagueoflegends.player p, leagueoflegends.heat h
                                        where t.idTeam=p.idTeam and t.idTeam = h.idTeam
                                        and h.idTournament=(select max(idTournament) from  leagueoflegends.edition);");

            foreach(List<Object> datos in list_datos)
            {
                dr = table1to4.NewRow();
                dr["Nombre Equipo"] = datos[0].ToString();
                dr["Nickname jugador"] = datos[1].ToString();
                dr["Titularidad"] = datos[2].ToString();
                table1to4.Rows.Add(dr);
            }
            
            return table1to4;
        }
        public DataTable Consulta2(string year_selected)
        {
            table1to4 = new DataTable("Consultas1al4");

            table1to4.Columns.Add("Nombre Equipo");
            table1to4.Columns.Add("Nickname Jugador");
            table1to4.Columns.Add("Titularidad");


            list_datos = DBBroker.getAgent().readSQL($@"select t.name, p.nickName, p.type 
                                            from leagueoflegends.team t, leagueoflegends.player p, leagueoflegends.edition e
                                            where t.idTeam=p.idTeam 
                                            and t.idTeam=e.winnerOfEdition 
                                            and e.year={year_selected};");

            foreach (List<Object> datos in list_datos)
            {
                dr = table1to4.NewRow();
                dr["Nombre Equipo"] = datos[0].ToString();
                dr["Nickname jugador"] = datos[1].ToString();
                dr["Titularidad"] = datos[2].ToString();
                table1to4.Rows.Add(dr);
            }

            return table1to4;
        }
        public DataTable Consulta3(string year_selected)
        {
            table1to4 = new DataTable("Consultas1al4");

            table1to4.Columns.Add("Nombre Equipo");
            table1to4.Columns.Add("Nickname Jugador");
            table1to4.Columns.Add("Titularidad");


            list_datos = DBBroker.getAgent().readSQL($@"select t.name, p.nickName, p.type
                                            from leagueoflegends.team t, leagueoflegends.player p, leagueoflegends.edition e, leagueoflegends.match m, leagueoflegends.play pl
                                            where p.idTeam = t.idTeam
                                            and t.idTeam = pl.idTeam
                                            and pl.idMatch = m.idMatch
                                            and m.idTournament = e.idTournament
                                            and e.year = {year_selected}
                                            and m.round = 1; ");

            foreach (List<Object> datos in list_datos)
            {
                dr = table1to4.NewRow();
                dr["Nombre Equipo"] = datos[0].ToString();
                dr["Nickname jugador"] = datos[1].ToString();
                dr["Titularidad"] = datos[2].ToString();
                table1to4.Rows.Add(dr);
            }

            return table1to4;
        }
        public DataTable Consulta4(int edition_selected)
        {
            table1to4 = new DataTable("Consultas1al4");

            table1to4.Columns.Add("Nombre Equipo");
            table1to4.Columns.Add("Nickname Jugador");
            table1to4.Columns.Add("Titularidad");


            list_datos = DBBroker.getAgent().readSQL($@"SELECT t.name, p.nickName, p.type 
                                            from leagueoflegends.team t, leagueoflegends.player p, leagueoflegends.edition e, leagueoflegends.match m
                                            where p.idTeam=t.idTeam 
                                            and m.idTournament=e.idTournament 
                                            and m.winnerOfMatch=t.idTeam 
                                            and e.idTournament={edition_selected} 
                                            and m.round=1;");

            foreach (List<Object> datos in list_datos)
            {
                dr = table1to4.NewRow();
                dr["Nombre Equipo"] = datos[0].ToString();
                dr["Nickname jugador"] = datos[1].ToString();
                dr["Titularidad"] = datos[2].ToString();
                table1to4.Rows.Add(dr);
            }

            return table1to4;
        }
        public DataTable Consulta5(int edition_selected, string year_selected)
        {
            table5 = new DataTable("Consulta5");

            table5.Columns.Add("Posicion");
            table5.Columns.Add("Equipo");


            list_datos = DBBroker.getAgent().readSQL($@"select distinct t.name, m.round
                                            from leagueoflegends.team t, leagueoflegends.play p, leagueoflegends.edition e, leagueoflegends.match m
                                            where t.idTeam=p.idTeam 
                                            and m.idMatch=p.idMatch 
                                            and e.year={year_selected} 
                                            and m.idTournament={edition_selected} 
                                            order by m.round;");
            int contador = 1;

            foreach (List<Object> datos in list_datos)
            {
                dr = table5.NewRow();
                dr["Posicion"] = contador;
                contador++;
                dr["Equipo"] = datos[0].ToString();
                table5.Rows.Add(dr);
            }

            return table5;
        }
    }
}
