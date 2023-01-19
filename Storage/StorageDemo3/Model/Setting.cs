using SQLite;
using StorageDemo3.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDemo3.Model
{
	// the settings Entity 
	internal class Setting : IEntity
	{
		[PrimaryKey]
		public long Id { get; set; }

		[Unique]
		public string Key { get; set; }

		public string Value { get; set; }

		public bool IsEncrypted { get; set; }
	}
}
