namespace apiSalesNet.Models
{
    public class PersonInfo
    {
        public int BusinessEntityID { get;set;}
        public string name { get; set; }
        public string lastName { get; set; }

        public override string ToString()
        {
            return $"{nameof(BusinessEntityID)}: {BusinessEntityID}, {nameof(name)}: {name}";
        }
    }
}