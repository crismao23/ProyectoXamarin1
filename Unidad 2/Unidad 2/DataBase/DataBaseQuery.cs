using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Unidad_2.Models;

namespace Unidad_2.DataBase
{
    public class DataBaseQuery
    {
        readonly SQLiteAsyncConnection _database;

        public DataBaseQuery(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
        }

        #region CRUD

        public Task<int> SaveUserModelAsync(UserModel  user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<UserModel>> GetUserModel()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        public Task<List<UserModel>> QueryUserModel(string query)
        {
            return _database.QueryAsync<UserModel>(query);
        }





        #endregion


    }
}
