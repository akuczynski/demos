using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDemo.Model
{
	internal class Storage
	{
		public string Key { get; set; }

		public string Value { get; set; }

		public string Type { get; set; } 

		public bool IsEncrypted { get; set; }
	}
}
