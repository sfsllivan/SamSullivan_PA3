using MySql.Data.MySqlClient;
using api.bin.Models.interfaces;
using api.bin.Models;
namespace api.Models
{
    public class SaveDriver : IInsertDriver, IEditDriver, IDeleteDriver
    {
        public void InsertDriver(Drivers value)
        {
            string cs = "server=o2olb7w3xv09alub.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=xxenw5tkhdh758ya;database=tpdljrasde07tpof;port=3306;password=enpeeokwxyxiiwia";
            using var con = new MySqlConnection(cs);
            con.Open();
            
            using var cmd = new MySqlCommand();

            cmd.CommandText = @"INSERT INTO drivers(Id, Name, Rating, DateHired, Deleted) VALUES(@Id, @Name, @Rating, @DateHired, @Deleted)";
            cmd.Parameters.AddWithValue("@Id", value.Id);
            cmd.Parameters.AddWithValue("@Name", value.Name);
            cmd.Parameters.AddWithValue("@Rating", value.Rating);
            cmd.Parameters.AddWithValue("@DateHired", value.DateHired);
            cmd.Parameters.AddWithValue("@Deleted", value.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void EditDriver(Drivers value)
        {
            string cs = "server=o2olb7w3xv09alub.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=xxenw5tkhdh758ya;database=tpdljrasde07tpof;port=3306;password=enpeeokwxyxiiwia";
            using var con = new MySqlConnection(cs);
            con.Open();
            
            using var cmd = new MySqlCommand();

            cmd.CommandText = @"UPDATE drivers set Name = @Name, Rating = @Rating, DateHired = @DateHired, Deleted = @Deleted WHERE id = @ID";
            cmd.Parameters.AddWithValue("@Id", value.Id);
            cmd.Parameters.AddWithValue("@Name", value.Name);
            cmd.Parameters.AddWithValue("@Rating", value.Rating);
            cmd.Parameters.AddWithValue("@DateHired", value.DateHired);
            cmd.Parameters.AddWithValue("@Deleted", value.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void DeleteDriver(Drivers value)
        {
            string cs = "server=o2olb7w3xv09alub.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=xxenw5tkhdh758ya;database=tpdljrasde07tpof;port=3306;password=enpeeokwxyxiiwia";
            using var con = new MySqlConnection(cs);
            con.Open();
            
            using var cmd = new MySqlCommand();

            cmd.CommandText = @"DELETE drivers set Name = @Name, Rating = @Rating, DateHired = @DateHired, Deleted = @Deleted WHERE id = @ID";
            cmd.Parameters.Remove(value.Id);
            cmd.Parameters.Remove(value.Name);
            cmd.Parameters.Remove(value.Rating);
            cmd.Parameters.Remove(value.DateHired);
            cmd.Parameters.Remove(value.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }



    }
}