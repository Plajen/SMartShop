namespace SMartShop.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }

        public City(int id, string name, int stateId)
        {
            Id = id;
            Name = name;
            StateId = stateId;
        }

        public City() { }
    }
}
