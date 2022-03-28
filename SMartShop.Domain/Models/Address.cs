namespace SMartShop.Domain.Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string CEP { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }

        public Address(int id, string street, string number, string complement, string district,
            string cep, int cityId, int createdBy)
        {
            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            CEP = cep;
            CityId = cityId;
            CreatedBy = createdBy;
        }

        public Address() { }
    }
}
