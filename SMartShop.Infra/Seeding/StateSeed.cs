using Microsoft.EntityFrameworkCore;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Seeding
{
    public static class StateSeed
    {
        public static void SeedState(this ModelBuilder builder)
        {
            builder.Entity<State>().HasData(
                new State(1, "Acre", "AC"),
                new State(2, "Alagoas", "AL"),
                new State(3, "Amazonas", "AM"),
                new State(4, "Amapá", "AP"),
                new State(5, "Bahia", "BA"),
                new State(6, "Ceará", "CE"),
                new State(7, "Distrito Federal", "DF"),
				new State(8, "Espírito Santo", "ES"),
				new State(9, "Goiás", "GO"),
				new State(10, "Maranhão", "MA"),
				new State(11, "Minas Gerais", "MG"),
				new State(12, "Mato Grosso do Sul", "MS"),
				new State(13, "Mato Grosso", "MT"),
				new State(14, "Pará", "PA"),
				new State(15, "Paraíba", "PB"),
				new State(16, "Pernambuco", "PE"),
				new State(17, "Piauí", "PI"),
				new State(18, "Paraná", "PR"),
				new State(19, "Rio de Janeiro", "RJ"),
				new State(20, "Rio Grande do Norte", "RN"),
				new State(21, "Rondônia", "RO"),
				new State(22, "Roraima", "RR"),
				new State(23, "Rio Grande do Sul", "RS"),
				new State(24, "Santa Catarina", "SC"),
				new State(25, "Sergipe", "SE"),
				new State(26, "São Paulo", "SP"),
				new State(27, "Tocantins", "TO"));
		}
	}
}
