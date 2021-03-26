using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using TSPOnline.Interfaces;
using TSPOnline.Models;

namespace TSPOnline.Repositorys
{
    public class MissionRepository : IMissionRepository
    {
        private readonly string connectionString;

        public MissionRepository(string connectionString) =>
            this.connectionString = connectionString;

        public async Task<IEnumerable<Mission>> SelectMissionsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<Mission>("SELECT * FROM Missions WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
