using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Unidad_2.Models;

namespace Unidad_2.DataBase
{
    public class DataBaseQuery
    {
		//el _ para variables con valores asincronos
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
        //recibe consulta personalizada
        public Task<List<UserModel>> QueryUserModel(string query)
        {
            return _database.QueryAsync<UserModel>(query);
        }




		// Generico


		public Task<List<T>> GetTableModel<T>() where T : new()
		{
			return _database.Table<T>().ToListAsync();
		}

		public Task<int> SaveModelAsync<T>(T model, bool isInsert) where T : new()
		{

			if (isInsert != true)
			{
				return _database.UpdateAsync(model);
			}
			else
			{
				return _database.InsertAsync(model);
			}

		}

		public Task<int> DeleteModelAsync<T>(T model) where T : new()
		{
			return _database.DeleteAsync(model);
		}

		public Task<List<T>> QueryModel<T>(string query) where T : new()
		{
			return _database.QueryAsync<T>(query);
		}

		#endregion


	}
}
