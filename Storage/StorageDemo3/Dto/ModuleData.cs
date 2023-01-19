using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StorageDemo3.Dto
{
	internal class ModuleData
	{
		public List<UserDto> Users { get; init; } = new List<UserDto>();

		public string Version = "V1"; 
	}
}
