using System.Data;
using System.Threading;
using database;
using database.Models;
using MySql.Data.MySqlClient;

internal class Program
{
	private static void Main(string[] args)
	{

		var con = database.DbConnection.database1();
		var cmd = new MySqlCommand();
		cmd.Connection = con;

		// var yafi = new User { Name = "Abyan", Age = 21 };
		// Insert(cmd, yafi);
		// yafi.Age = 30;
		// Update(cmd, yafi);
		// Delete(cmd, "abyan");

		// GetAll(cmd);
		GetByName(cmd, "n");


	}

	private static void GetAll(MySqlCommand cmd)
	{
		cmd.CommandText = "SELECT * FROM coba";
		MySqlDataReader reader = cmd.ExecuteReader();

		Console.WriteLine($"{reader.GetName(0),-4} {reader.GetName(1),-4}");
		while (reader.Read())
		{
			Console.WriteLine($"{reader.GetString(0),-4} {reader.GetInt16(1),-4}");
		}
	}

	private static void GetByName(MySqlCommand cmd, string name)
	{
		cmd.CommandText = $"SELECT * FROM coba WHERE name like '%{name}%'";
		MySqlDataReader reader = cmd.ExecuteReader();

		Console.WriteLine($"{reader.GetName(0),-4} {reader.GetName(1),-4}");
		while (reader.Read())
		{
			Console.WriteLine($"{reader.GetString(0),-4} {reader.GetInt16(1),-4}");
		}
	}

	private static void Insert(MySqlCommand cmd, User user)
	{
		cmd.CommandText = @$"
			INSERT INTO `coba` (`name`, `age`) VALUES ('{user.Name}', {user.Age});
		";

		try
		{
			cmd.ExecuteNonQuery();
			Console.WriteLine("user created");
		}
		catch (Exception e)
		{
			Console.WriteLine($"user not created : {e}");
		}
	}

	private static void Update(MySqlCommand cmd, User user)
	{
		cmd.CommandText = $"UPDATE coba set age={user.Age} WHERE name='{user.Name}'";
		try
		{
			cmd.ExecuteNonQuery();
			Console.WriteLine("user updated");
		}
		catch (Exception e)
		{
			Console.WriteLine($"user not updated : {e}");
		}
	}

	private static void Delete(MySqlCommand cmd, string name)
	{
		cmd.CommandText = $"DELETE FROM coba WHERE name='{name}'";
		try
		{
			cmd.ExecuteNonQuery();
			Console.WriteLine($"user \"{name}\" deleted");
		}
		catch (Exception e)
		{
			Console.WriteLine($"user not deleted : {e}");
		}
	}
}
