using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Repositories;

public class CategoryRepository 
    : Repository<Category>, ICategoryInterface
{
    public CategoryRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllWithSubcategoriesAsync()
    {
        var list = await _dbContext.Categories
                                   .Include(c => c.SubCategories)
                                   .ToListAsync();
        return list;
    }

    public Task<IEnumerable<Category>> GetCategoriesByAdoNetAsync()
    {
        string connectionString =
           "Data Source = (LocalDB)\\MSSQLLocalDB; Database=OlxCloneDb;";
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        string query = "SELECT * FROM Categories";
        using var command = new SqlCommand(query, connection);
        command.CommandTimeout = 5000;
        using var reader = command.ExecuteReader();
        var list = new List<Category>();
        while (reader.Read())
        {
            var category = new Category
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                CreateAt = reader.GetDateTime(2),
                UpdateAt = reader.GetDateTime(3)
            };
            list.Add(category);
        }

        return Task.FromResult(list.AsEnumerable());
    }

    public Task<IEnumerable<Category>> GetCategoriesByTSQLPaginationAsync(int pageSize, int pageNumber)
    {
        string connectionString =
   "Data Source = (LocalDB)\\MSSQLLocalDB; Database=OlxCloneDb;";
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        string query = $"SELECT * FROM Categories ORDER BY Id OFFSET {(pageNumber - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";

        using var command = new SqlCommand(query, connection);
        command.CommandTimeout = 5000;

        var list = new List<Category>();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var category = new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    CreateAt = reader.GetDateTime(2),
                    UpdateAt = reader.GetDateTime(3)
                };

                list.Add(category);
            }
        }
        connection.Close();
        connection.Open();

        for (int i = 0; i < list.Count; i++)
        {
            query = "SELECT * FROM SubCategories WHERE CategoryId = @id";
            using var subCommand = new SqlCommand(query, connection);
            subCommand.Parameters.AddWithValue("@id", list[i].Id);
            subCommand.CommandTimeout = 5000;
            using var subReader = subCommand.ExecuteReader();
            while (subReader.Read())
            {
                var subCategory = new SubCategory()
                {
                    Id = subReader.GetInt32(0),
                    CategoryId = subReader.GetInt32(1),
                    Name = subReader.GetString(2),
                    CreateAt = subReader.GetDateTime(3),
                    UpdateAt = subReader.GetDateTime(4),
                };
                list[i].SubCategories.Add(subCategory);
            }
        }
        connection.Close();

        return Task.FromResult(list.AsEnumerable());
    }

    public Task TestAdoNet()
    {
        string connectionString = 
            "Data Source = (LocalDB)\\MSSQLLocalDB; Database=OlxCloneDb;";
        SqlConnection connection = new(connectionString);
        connection.Open();

        var today = DateTime.Now.ToString();
        for (int i = 0; i < 5000; i++)
        {
            string query = 
   "INSERT INTO Categories (Name, CreateAt, UpdateAt) VALUES (@Name, @created, @updated)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@created", today);
            command.Parameters.AddWithValue("@updated", today);
            command.Parameters.AddWithValue("@Name", $"TestAdoNet{i}");
            command.ExecuteNonQuery();
        }
        connection.Close();
        return Task.CompletedTask;
    }

    public Task TestTransaction()
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            for (int i = 0; i < 5000; i++)
            {
                _dbContext.Categories.Add(new Category
                {
                    Name = $"TestTransaction{i}"
                });
                _dbContext.SaveChanges();
            }

            transaction.Commit();
            return Task.CompletedTask;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public Task TestTSQL()
    {
        var random = new Random();

        string query = """
         DECLARE @today DATETIME;
         SET @today = GETDATE();


         DECLARE @i INT = 0;

         WHILE @i < 100000
         BEGIN

         	DECLARE @randomNumber INT;
         	SELECT @randomNumber = ABS(CHECKSUM(NEWID())) % 1000 + 1;
             INSERT INTO SubCategories (Name, CreateAt, UpdateAt, CategoryId)
             VALUES ('Test T-SQL Subcategory' + CAST(@i AS NVARCHAR), @today, @today, (SELECT @randomNumber AS RandomNumber));

             SET @i = @i + 1;
         END
         """;

        string connectionString =
            "Data Source = (LocalDB)\\MSSQLLocalDB; Database=OlxCloneDb; Trusted_Connection=True; MultipleActiveResultSets=true";
        SqlConnection connection = new(connectionString);
        connection.Open();

        SqlCommand command = new(query, connection);
        command.CommandTimeout = 5000;
        command.ExecuteNonQuery();
        connection.Close();
        return Task.CompletedTask;
    }


}
