using MySql.Data.MySqlClient;

namespace database;

public static class DbConnection
{
	public static MySqlConnection database1()
	{
		var db1 = new MySqlConnection(@"
			server=localhost; 
			userid=abyan; 
			password=scootermania;
			database=asdf"
		);
		db1.Open();
		return db1;
	}
}