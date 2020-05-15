using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.DAL.Helpers.Interfaces;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IDALHelper helper;
        public CategoryRepository(IDALHelper helper)
        {
            this.helper = helper;
        }

        public async Task<Category> CreateCategory(ApplicationContext context, Category category)
        {
            using (SqlCommand command = this.helper.GetCommand(@"Insert into [dbo].[Category]
                                                    (CategoryGuid,Name,Description,CreatedBy,UpdatedBy) 
                                                  values(@CategoryGuid,@Name,@Description,@CreatedBy,@UpdatedBy)"))
            {

                command.Parameters.AddWithValue("@CategoryGuid", (object)category.CategoryGuid ?? DBNull.Value);
                command.Parameters.AddWithValue("@Name", (object)category.Name ?? DBNull.Value);
                command.Parameters.AddWithValue("@Description", (object)category.Description ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", context.UserKey);
                command.Parameters.AddWithValue("@UpdatedBy", context.UserKey);
                try
                {
                    int IsQuerySucess = await this.helper.ExecuteNonQueryAsync(command).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    string st = s;
                }
            }
            return category;
        }

        public async  Task<IEnumerable<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (SqlCommand command = this.helper.GetCommand("SELECT CategoryKey, CategoryGuid, Name, Description, PostCount, Link, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM [dbo].[Category] order by UpdatedAt desc"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Category category = new Category();
                            category.CategoryKey = reader.GetInt32("CategoryKey");
                            category.Name = reader.GetString("Name");// "Blog Title " + i,
                            category.Description = reader.GetString("Description");// "Amazing blog and its content",
                            category.Link = reader["Link"]==DBNull.Value?null:(string)reader["Link"];
                            category.PostCount = reader.GetInt32("PostCount");// 8987
                            categories.Add(category);
                        }
                    }
                }
            }
            return categories;
        }
        public async Task<Category> GetCategory(int categoryKey)
        {

            Category category = new Category();
            using (SqlCommand command = this.helper.GetCommand("SELECT CategoryKey, CategoryGuid, Name, Description, PostCount, Link, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM [dbo].[Category]"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            category.CategoryKey = reader.GetInt32("CategoryKey");
                            category.Name = reader.GetString("Name");// "Blog Title " + i,
                            category.Description = reader.GetString("Description");// "Amazing blog and its content",
                            category.Link = reader["Link"] == DBNull.Value ? null : (string)reader["Link"];
                            category.PostCount = reader.GetInt32("PostCount");// 8987
                        }
                    }
                }
            }
            return category;
        }
    }
}
