using System;
using System.Collections.Generic;
using Npgsql;
using testPj.Models;
using TestPj.Data;

namespace testPj.Data
{
    public class DatabaseService : IDatabaseService
    {
        private readonly Dictionary<Type, List<object>> _database = new();
        private readonly string _connectionString;

        public DatabaseService(string configuration)
        {
            _connectionString = configuration;
        }

        public IEnumerable<ExampleModel> GetAll()
        {
            var examples = new List<ExampleModel>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT id, name FROM test_users", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        examples.Add(new ExampleModel
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"]?.ToString() ?? string.Empty,
                            Age = (int)reader["Age"],
                            Gender = reader["gender"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }

            return examples;
        }
    }
}