using api.bin.Models;
using api.bin.Models.interfaces;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace api.bin.Models
{
    public class ReadDriverData : IGetAllDrivers, IGetDriver
    {
        public List<Drivers> GetAllDrivers(){
            string cs= "server=o2olb7w3xv09alub.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=xxenw5tkhdh758ya;database=tpdljrasde07tpof;port=3306;password=enpeeokwxyxiiwia";
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM drivers";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Drivers> allDrivers = new List<Drivers>();
            while(rdr.Read()){
                allDrivers.Add(new Drivers(){Id=rdr.GetInt32(0),Name=rdr.GetString(1), Rating=rdr.GetInt32(2), DateHired= rdr.GetDateTime(3),Deleted=rdr.GetBoolean(4)});
            }
            return allDrivers;
        }

        public Drivers GetDriver(int Id){
            string cs= "server=o2olb7w3xv09alub.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=xxenw5tkhdh758ya;database=tpdljrasde07tpof;port=3306;password=enpeeokwxyxiiwia";
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM drivers WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

             rdr.Read();
             return new Drivers(){Id=rdr.GetInt32(0),Name=rdr.GetString(1), Rating=rdr.GetInt32(2), DateHired=rdr.GetDateTime(3),Deleted=rdr.GetBoolean(4) };
        }
        
    }
}