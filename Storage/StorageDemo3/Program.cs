using SQLite;
using StorageDemo3.Database;
using StorageDemo3.Dto;
using StorageDemo3.Model;
using System.Text.Json;

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

// setting dto created only for demo purposes 
var settingDto = new SettingDto
{
	Key = "MyModule.Font.Size",
	Value = "12",
	IsEncrypted = false,
	OwnerModule = "ModuleA"
}; 

// Is DTO to entity mapping needed here ? -> No 
// DTO type and Storage type (entity) is much different, there is no need to use Automapper here. 
var entity = new Storage
{
	Key = "ModuleData",
	Value = JsonSerializer.Serialize(moduleData),
	Type = nameof(ModuleData)
};

// only for demo purposes: map settingDto -> settingEntity 
var setting = new Setting();

// for this mapping I could use Automapper library 
setting.Key = settingDto.Key;
setting.Value = settingDto.Value;
setting.IsEncrypted = settingDto.IsEncrypted; 

// use repo pattern here 
var storageRepo = new BaseRepostory<Storage>();
await storageRepo.SaveItemAsync(entity);

var settingsRepo = new BaseRepostory<Setting>();
await settingsRepo.SaveItemAsync(setting);

Console.ReadLine();
