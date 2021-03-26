using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using TSPOnline.Interfaces;
using TSPOnline.Models;

namespace TSPOnline.Repositorys
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly string connectionString;

        public MaterialRepository(string connectionString) =>
            this.connectionString = connectionString;

        public async Task<IEnumerable<Material>> SelectMaterialsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<Material>("SELECT * FROM Materials WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
