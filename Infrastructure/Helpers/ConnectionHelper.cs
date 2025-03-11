namespace Flag_Explorer_App.Infrastructure.Helpers
{
    public static class ConnectionHelper
    {
        public static string GetString(string server)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.dbm.json")
                            .Build();

            return config.GetValue<string>($"DBMigration:{server}")!;
        }
    }
}
