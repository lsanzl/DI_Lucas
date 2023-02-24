using P2Hito3_Lucas_Sanz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Hito3_Lucas_Sanz.Persistence.Manage
{
    public class ManageEdition
    {
        /// <summary>
        /// Method to get objects from DB and convert to country object
        /// </summary>
        /// <returns> List of countries  </returns>
        public List<string> getEditions()
        {
            List<string> year_list = new List<string>();
            List<Object> edition_object = new List<Object>();
            edition_object = DBBroker.getAgent().readSQL("select * from leagueoflegends.edition;");
            foreach (List<Object> objE in edition_object)
            {
                year_list.Add(objE[1].ToString());
            }
            return year_list;
        }
    }
}