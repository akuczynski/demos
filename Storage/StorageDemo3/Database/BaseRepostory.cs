using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace StorageDemo3.Database
{
	public class BaseRepostory<T> : IGenericRepository<T> where T : IEntity, new()
	{
		protected SQLiteAsyncConnection Database { get; set; }

		async Task Init()
		{
			if (Database is not null)
				return;

			var flags = // open the database in read/write mode
						SQLite.SQLiteOpenFlags.ReadWrite |
						// create the database if it doesn't exist
						SQLite.SQLiteOpenFlags.Create |
						// enable multi-threaded database access
						SQLite.SQLiteOpenFlags.SharedCache;

			Database = new SQLiteAsyncConnection("Demo.db", flags);
			var result = await Database.CreateTableAsync<T>();
		}

		public async Task<long> DeleteAsync(T item)
		{
			await Init();
			return await Database.DeleteAsync(item);
		}

		public async Task<T> GetByIdAsync(long id)
		{
			await Init();
			return await Database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			await Init();
			return await Database.Table<T>().ToListAsync();
		}

		public async Task<long> SaveItemAsync(T item)
		{
			await Init();
			if (item.Id != 0)
			{
				return await Database.UpdateAsync(item);
			}
			else
			{
				return await Database.InsertAsync(item);
			}
		} 
	}
}
