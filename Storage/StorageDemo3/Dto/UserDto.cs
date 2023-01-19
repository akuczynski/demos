using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDemo3.Dto
{
	internal class UserDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<Role> Roles { get; set; }
	}
}
