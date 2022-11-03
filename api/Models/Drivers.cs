namespace api.bin.Models
{
    public class Drivers
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public int Rating {get; set;}

        public DateTime DateHired {get; set;}

        public Boolean Deleted {get; set;}

        public override string ToString()
        {
            return Id + "\t" + Name + "\t" + Rating + "\t" + DateHired + "\t";
        }

    }
}