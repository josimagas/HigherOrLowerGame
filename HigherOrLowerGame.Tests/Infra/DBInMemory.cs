using System;
using HigherOrLowerGame.Api.Infra;
using HigherOrLowerGame.Api.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HigherOrLowerGame.Tests.Infra
{
    public class DbInMemory
    {
        private AppDbContext _context;

        public DbInMemory()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;

            _context = new AppDbContext(options);
            InsertFakeData();
        }

        public AppDbContext GetContext() => _context;

        private void InsertFakeData()
        {
            if (_context.Database.EnsureCreated())
            {
                _context.Game.Add(
                    new Game()
                    {
                        Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                        Deleted = false,
                        Finished = false,
                        CreatedAt = DateTime.Now.ToString(),
                        CurrentPlayer = "player1",
                        CurrentCardValue = 10,
                        FirstPlayerScore = 0,
                        SecondPlayerScore = 0,
                        NumberOfCardOnDeck = 52
                    }
                );
                _context.SaveChanges();
            }
        }
    }
}