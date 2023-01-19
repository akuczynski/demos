using SQLite;
using StorageDemo2.Dto;
using StorageDemo2.Model;
using System.Text.Json;

var flags = // open the database in read/write mode
			SQLite.SQLiteOpenFlags.ReadWrite |
			// create the database if it doesn't exist
			SQLite.SQLiteOpenFlags.Create |
			// enable multi-threaded database access
			SQLite.SQLiteOpenFlags.SharedCache;

// create db & tables 
var database = new SQLiteAsyncConnection("Demo.db", flags);
var storage  = await database.CreateTableAsync<Storage>();
var settings = await database.CreateTableAsync<Setting>();


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

// entities 
var entity = new Storage
{
	Key = "ModuleData",
	Value = JsonSerializer.Serialize(moduleData),
	Type = nameof(ModuleData)
};

var setting = new Setting
{
	Key = "MyModule.Font.Size",
	Value = "12",
	IsEncrypted = false
};

await database.InsertAsync(entity); 
await database.InsertAsync(setting);
