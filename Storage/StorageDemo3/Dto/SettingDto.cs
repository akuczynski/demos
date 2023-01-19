namespace StorageDemo3.Dto
{
	internal class SettingDto
	{
		public string Key { get; set; }

		public string Value { get; set; }

		public bool IsEncrypted { get; set; }

		// add an extra property so DTO differs from entity 
		public string OwnerModule { get; set; }
	}
}
