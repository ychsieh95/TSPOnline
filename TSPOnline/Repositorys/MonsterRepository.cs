using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using TSPOnline.Interfaces;
using TSPOnline.Models;

namespace TSPOnline.Repositorys
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly string connectionString;

        public MonsterRepository(string connectionString) =>
            this.connectionString = connectionString;

        public async Task<IEnumerable<Monster>> SelectMonstersAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<Monster>("SELECT * FROM Monsters WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
