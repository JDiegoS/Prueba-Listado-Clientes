namespace WebApplication1
{
    public class Client_Header
    {

        public int ID { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }

    }

    public class Client_Detail
    {
        public DateTime Date_Created { get; set; }

        public int ClientID { get; set; }


        public string Name { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Phone_Number { get; set; }
        public string Comments { get; set; }
    }


}