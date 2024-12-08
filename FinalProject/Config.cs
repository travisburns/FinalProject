using Microsoft.Extensions.Configuration;
using System.IO;

public class ConfigDB
{
    public static IConfiguration AppSetting { get; }
    static ConfigDB()
    {
        AppSetting = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("mysettings.json")
            .Build();
    }
}

public class MySqlSettings
{
    public string ConnectionString { get; set; }
}