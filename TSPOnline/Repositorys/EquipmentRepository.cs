using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using TSPOnline.Interfaces;
using TSPOnline.Models;

namespace TSPOnline.Repositorys
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly string connectionString;

        public EquipmentRepository(string connectionString) =>
            this.connectionString = connectionString;

        public async Task<IEnumerable<Equipment>> SelectEquipmentsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<Equipment>("SELECT * FROM Equipments WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
