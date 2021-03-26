using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using TSPOnline.Interfaces;
using TSPOnline.Models;

namespace TSPOnline.Repositorys
{
    public class PetRepository : IPetRepository
    {
        private readonly string connectionString;

        public PetRepository(string connectionString) =>
            this.connectionString = connectionString;

        public async Task<IEnumerable<Pet>> SelectPetsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<Pet>("SELECT * FROM Pets WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<Pet>> SelectPetsAsync(string name, bool byKeywork = false)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    if (byKeywork)
                        return await conn.QueryAsync<Pet>("SELECT * FROM Pets WHERE Name LIKE @Name;", new Pet() { Name = $"%{name}%" });
                    else
                        return await conn.QueryAsync<Pet>("SELECT * FROM Pets WHERE Name=@Name;", new Pet() { Name = name });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<PetSkills>> SelectPetSkillsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<PetSkills>("SELECT * FROM Pets_Skills WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<PetSkills>> SelectPetSkillsAsync(string name)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<PetSkills>("SELECT * FROM Pets_Skills WHERE Name=@Name;", new PetSkills() { Name = name });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<PetStatistic>> SelectPetStatisticsAsync()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<PetStatistic>("SELECT * FROM Pets_Statistics WHERE 1=1;");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<PetStatistic>> SelectPetStatisticsAsync(string name)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return await conn.QueryAsync<PetStatistic>("SELECT * FROM Pets_Statistics WHERE Name=@Name;", new PetStatistic() { Name = name });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
