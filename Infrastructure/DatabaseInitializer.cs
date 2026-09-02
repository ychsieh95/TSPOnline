using Microsoft.Data.Sqlite;

namespace TSPOnline.Infrastructure;

internal static class DatabaseInitializer
{
    private const string Schema = """
        CREATE TABLE IF NOT EXISTS DODO_MapIDs (
            Location TEXT NOT NULL,
            Place TEXT NOT NULL,
            ID TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS DODO_Scripts (
            Name TEXT NOT NULL,
            Location TEXT NOT NULL,
            IsInterrupted BOOLEAN NOT NULL,
            LV_Boss INTEGER NOT NULL,
            LV_Average REAL NOT NULL,
            AGI INTEGER NOT NULL,
            SUG_LV_New TEXT NOT NULL,
            SUG_LV_Old TEXT NOT NULL,
            Mission TEXT NOT NULL,
            Remark TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Equipments (
            Name TEXT NOT NULL,
            Site TEXT NOT NULL,
            Type TEXT NOT NULL,
            LV INTEGER NOT NULL,
            INT INTEGER NOT NULL,
            ATK INTEGER NOT NULL,
            DEF INTEGER NOT NULL,
            HPX INTEGER NOT NULL,
            SPX INTEGER NOT NULL,
            AGI INTEGER NOT NULL,
            FIRE INTEGER NOT NULL,
            WATER INTEGER NOT NULL,
            WIND INTEGER NOT NULL,
            EARTH INTEGER NOT NULL,
            HEART INTEGER NOT NULL,
            Location TEXT NOT NULL,
            Price INTEGER NOT NULL,
            Point INTEGER NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Feedbacks (
            Nickname TEXT NOT NULL,
            Email TEXT NOT NULL,
            Type INTEGER NOT NULL,
            Content TEXT NOT NULL,
            Datetime TEXT NOT NULL,
            Guid TEXT NOT NULL PRIMARY KEY
        );
        CREATE TABLE IF NOT EXISTS Materials (
            Name TEXT NOT NULL,
            Type TEXT NOT NULL,
            LV INTEGER NOT NULL,
            Location TEXT NOT NULL,
            NpcName TEXT NOT NULL,
            NpcLV INTEGER NOT NULL,
            NpcAttribute TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Missions (
            Name TEXT NOT NULL,
            Location TEXT NOT NULL,
            Conditions TEXT NOT NULL,
            Steps TEXT NOT NULL,
            Items TEXT NOT NULL,
            Remark TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Monsters (
            Name TEXT NOT NULL,
            LV INTEGER NOT NULL,
            IsSoul BOOLEAN NOT NULL,
            Attribute TEXT NOT NULL,
            HP INTEGER NOT NULL,
            AGI INTEGER NOT NULL,
            Skill1 TEXT NOT NULL,
            Skill2 TEXT NOT NULL,
            Skill3 TEXT NOT NULL,
            Location TEXT NOT NULL,
            Items TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Ores (
            Name TEXT NOT NULL,
            LV INTEGER NOT NULL,
            Attribute TEXT NOT NULL,
            Location TEXT NOT NULL,
            Items TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Pets (
            Name TEXT NOT NULL,
            Attribute TEXT NOT NULL,
            Occupation TEXT NOT NULL,
            Catch BOOLEAN NOT NULL,
            SpecialSkill TEXT NOT NULL,
            PassiveSkill TEXT NOT NULL,
            Location TEXT NOT NULL,
            Items TEXT NOT NULL,
            Remark TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Pets_Skills (
            Name TEXT NOT NULL,
            RE INTEGER NOT NULL,
            Skill1 TEXT NOT NULL,
            Skill2 TEXT NOT NULL,
            Skill3 TEXT NOT NULL
        );
        CREATE TABLE IF NOT EXISTS Pets_Statistics (
            Name TEXT NOT NULL,
            RE INTEGER NOT NULL,
            LV INTEGER NOT NULL,
            HP INTEGER NOT NULL,
            SP INTEGER NOT NULL,
            INT INTEGER NOT NULL,
            ATK INTEGER NOT NULL,
            DEF INTEGER NOT NULL,
            HPX INTEGER NOT NULL,
            SPX INTEGER NOT NULL,
            AGI INTEGER NOT NULL
        );
        """;

    public static async Task InitializeAsync(string connectionString, string contentRootPath)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder(connectionString);
        var databasePath = connectionStringBuilder.DataSource;

        if (!Path.IsPathRooted(databasePath))
        {
            databasePath = Path.GetFullPath(databasePath, contentRootPath);
            connectionStringBuilder.DataSource = databasePath;
        }

        var databaseDirectory = Path.GetDirectoryName(databasePath);
        if (!string.IsNullOrEmpty(databaseDirectory))
        {
            Directory.CreateDirectory(databaseDirectory);
        }

        if (!File.Exists(databasePath))
        {
            var seedPath = Path.Combine(
                databaseDirectory ?? contentRootPath,
                $"{Path.GetFileNameWithoutExtension(databasePath)}.seed{Path.GetExtension(databasePath)}");

            if (File.Exists(seedPath))
            {
                File.Copy(seedPath, databasePath);
            }
        }

        await using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        await connection.OpenAsync();

        await using var command = connection.CreateCommand();
        command.CommandText = Schema;
        await command.ExecuteNonQueryAsync();
    }
}
