using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TableGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game1 = new Game();
            game1.Name = "T";
            game1.GHame = "B";
            game1.Type = "S";
            game1.Review = "A";

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string insertAtring = string.Format("INSERT INTO Game (name, game, type_of_game, review) VALUES('{0}', '{1}', '{2}', '{3}')", game1.Name, game1.GHame, game1.Type, game1.Review);
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open(); //Opens the connection
                SqlCommand insertCommand = new SqlCommand(insertAtring, conn);
                insertCommand.ExecuteReader();
            }
            catch(SqlException ex )
            {
                Console.WriteLine("Error: Please check the server connection" +ex.Message);
            }
            finally
            {
                conn.Close(); //Closes connection
            }
        }
    }

    class Insert
    {
        public static void addedDB(Game go, SqlConnection connection)
        {
            Game game1 = new Game();
            string insertString = string.Format("insert into Game (name, game, type_of_game, review) VALUES('{0}', '{1}', '{2}', '{3}')", game1.Name, game1.GHame, game1.Type, game1.Review);
            try
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(insertString, connection);
                insertCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: Please check the server connection" +ex.Message);
            }
            finally
            {
                connection.Close(); //Closes the connection
            }
        }
    }

    class Delete
    {
        public static void deleteValueDB(string game, SqlConnection connection)
        {
            string deleteString = string.Format("delete from Game where name='{0}'", game); //This is a command not a string!
            try
            {
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand(deleteString, connection);
                deleteCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: Please check the server connection" + ex.Message);
            }
            finally
            {
                connection.Close(); //Closes the connection
            }
        }
    }

    class Update
    {
        public static void updateValueDB(string newData, string where, SqlConnection connection)
        {
            string updateString = string.Format("update Game set game = '{0}' WHERE name = '{1}'", newData, where);
            try
            {
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand(updateString, connection);
                deleteCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: Please check the server connection" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    class Game
    {
        string name = "";
        string game = "";
        string type = "";
        string review = "";

        public string Name { get => name; set => name = value; }
        public string GHame { get => game; set => game = value; }
        public string Type { get => type; set => type = value; }
        public string Review { get => review; set => review = value; }
    }

}
