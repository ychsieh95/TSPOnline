using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using TSPOnline.Interfaces;
using TSPOnline.Models;

namespace TSPOnline.Repositorys
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly string connectionString;

        public ResourceRepository(string connectionString) =>
            this.connectionString = connectionString;

        public async Task<IEnumerable<DodoMapID>> SelectDodoMapIDsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<DodoMapID>("SELECT * FROM DODO_MapIDs WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<DodoScript>> SelectDodoScriptsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<DodoScript>("SELECT * FROM DODO_Scripts WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
