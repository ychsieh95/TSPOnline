using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using TSPOnline.Interfaces;
using TSPOnline.Models;

namespace TSPOnline.Repositorys
{
    public class OreRepository : IOreRepository
    {
        private readonly string connectionString;

        public OreRepository(string connectionString) =>
            this.connectionString = connectionString;

        public async Task<IEnumerable<Ore>> SelectOresAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<Ore>("SELECT * FROM Ores WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
