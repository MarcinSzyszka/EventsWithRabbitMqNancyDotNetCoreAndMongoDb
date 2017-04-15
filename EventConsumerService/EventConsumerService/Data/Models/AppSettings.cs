namespace EventConsumerService.Data.Models
{
	public class AppSettings
	{
		private readonly string connectionString;
		private readonly string databaseName;
		private static AppSettings instance;

		public AppSettings() { 
		}

		public AppSettings(string connectionString, string databaseName)
		{
			this.connectionString = connectionString;
			this.databaseName = databaseName;
			if (AppSettings.instance == null)
			{
				AppSettings.instance = this;
			}
		}

		public string GetConnectionString()
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				return AppSettings.instance.connectionString;
			}

			return this.connectionString;
		}

		public string GetDatabaseName()
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				return AppSettings.instance.databaseName;
			}

			return this.databaseName;
		}
	}
}
