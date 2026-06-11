using MySql.Data.MySqlClient;
using ReportGeneration_Kilunina.Classes.Common;
using ReportGeneration_Kilunina.Models;
using System;
using System.Collections.Generic;

namespace ReportGeneration_Kilunina.Classes
{
    public class WorkContext : Work
    {
        public WorkContext(int Id, int IdDiscipline, int IdType, DateTime Date, string Name, int Semester) :
            base(Id, IdDiscipline, IdType, Date, Name, Semester) { }

        public static List<WorkContext> AllWorks()
        {
            List<WorkContext> allWorks = new List<WorkContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader BDWorks = Connection.Query("SELECT * FROM `work` ORDER BY `Date`", connection);
            while (BDWorks.Read())
            {
                allWorks.Add(new WorkContext(
                    BDWorks.GetInt32(0),
                    BDWorks.GetInt32(1),
                    BDWorks.GetInt32(2),
                    BDWorks.GetDateTime(3),
                    BDWorks.GetString(4),
                    BDWorks.GetInt32(5)));
            }
            Connection.CloseConnection(connection);
            return allWorks;
        }
    }
}
