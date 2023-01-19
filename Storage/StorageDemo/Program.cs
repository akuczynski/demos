using SQLite;
using StorageDemo.Dto;
using StorageDemo.Model;
using System.Text.Json;

var flags = // open the database in read/write mode
			SQLite.SQLiteOpenFlags.ReadWrite |
			// create the database if it doesn't exist
			SQLite.SQLiteOpenFlags.Create |
			// enable multi-threaded database access
			SQLite.SQLiteOpenFlags.SharedCache;

var database = new SQLiteAsyncConnection("Demo.db", flags);
var storage = await database.CreateTableAsync<Storage>();

// create sample dtos
var moduleData = new ModuleData();
moduleData.Users.Add(new UserDto
{
	Id = 1,
	Name = "Tom",
	Roles = new Role[]
	{
		new Role {  Id = 1, Name = "Admin" }
	}
});

moduleData.Users.Add(new UserDto
{
	Id = 2,
	Name = "Jerry",
	Roles = new Role[]
	{
		new Role {  Id = 1, Name = "User" }
	}
});
 

// entity 
var entity = new Storage
{
	Key = "ModuleAData",
	Value = JsonSerializer.Serialize(moduleData),
	IsEncrypted = false,
	Type = nameof(ModuleData)
};

await database.InsertAsync(entity); 

