using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StorageDemo3.Database
{

	public interface IGenericRepository<T> where T : IEntity
	{
		Task<T> GetByIdAsync(long id);
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<long> SaveItemAsync(T item);
		Task<long> DeleteAsync(T item);
	}
}
