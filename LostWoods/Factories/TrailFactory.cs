using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;

using LostWoods.Models;

namespace LostWoods.Factory
{
    public class TrailFactory
    {
        private MySqlOptions _options;
        public TrailFactory(IOptions<MySqlOptions> config)
        {
            _options = config.Value;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(_options.ConnectionString);
            }
        }
        public void Add(Trail trail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO trails(Name, Description, Length, Elevation, Longitude, Latitude, created_at, updated_at) VALUES (@Name, @Desc, @Length, @Elevation, @Longitude, @Latitude, @Created_at, @Updated_at";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails");
            }
        }
        public Trail FindOne(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @id", new {id = id}).FirstOrDefault();
            }
        }
    }

    
}