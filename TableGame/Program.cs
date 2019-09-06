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
            string insertString2 = "insert into Game (name, game, type_of_game, review) values('a', 'b', 'c', 'g')";
            SqlConnection conn = new SqlConnection(connectionString);
            //// using (conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            // {
            //     conn.Open(); //Always use this to open the object!
            //     Console.WriteLine(conn.State);
            // }
            

            try
            {
                conn.Open();
                //SqlCommand selectCommand = new SqlCommand("select * from Game", conn);
                SqlCommand insertCommand = new SqlCommand(insertAtring, conn);
                //SqlCommand insertCommand2 = new SqlCommand(insertString2, conn);
                insertCommand.ExecuteReader();
            }
            catch(SqlException ex )
            {
                Console.WriteLine("Something happen to the server"+ex.Message);
            }
            finally
            {
                conn.Close();
            }
      
            //
            
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
