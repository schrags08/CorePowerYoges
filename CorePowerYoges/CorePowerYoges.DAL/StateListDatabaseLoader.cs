using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.DAL
{
    public class StateListDatabaseLoader : IStateRepository
    {
        private string connectionString;

        public StateListDatabaseLoader(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IEnumerable<State> LoadStateListFromDatabase(string connectionString)
        {
            List<State> states = new List<State>();

            string connString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
             
                using (SqlCommand command = new SqlCommand("SELECT * FROM State", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string name = reader.GetString(1);
                        string corePowerYogaId = reader.GetString(2);
                        var state = new State(id, name, corePowerYogaId);
                        states.Add(state);                        
                    }
                }

                foreach (State state in states)
                {
                    using (SqlCommand command = new SqlCommand(string.Format("SELECT * FROM Location WHERE StateId = '{0}'", state.Id), con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string stateId = reader.GetString(1);
                            string corePowerYogaId = reader.GetString(2);
                            string name = reader.GetString(3);
                            var location = new Location(id, stateId, corePowerYogaId, name);
                            state.Locations.Add(location);
                        }
                    }
                }

                con.Close();
            }

            return states;
        }

        public IEnumerable<State> GetAllStates()
        {
            return LoadStateListFromDatabase(connectionString).OrderBy(s => s.Name);
        }
    }
}
