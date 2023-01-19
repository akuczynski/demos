using SQLite;
using StorageDemo3.Database;

namespace StorageDemo3.Model
{
	// This entity is used to store object graph like in document databases 
	internal class Storage : IEntity
	{
		public long Id { get; set; }

		[Unique]
		public string Key { get; set; }

		public string Value { get; set; }

		public string Type { get; set; }
	}
}
