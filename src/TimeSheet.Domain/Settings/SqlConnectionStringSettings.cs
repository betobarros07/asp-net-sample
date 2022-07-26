namespace TimeSheet.Domain.Settings;

public class SqlConnectionStringSettings
{
    public SqlConnectionStringSettings(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; set; }
}