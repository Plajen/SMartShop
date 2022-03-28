using Microsoft.EntityFrameworkCore;
using SMartShop.Domain.Models;
using System;

namespace SMartShop.Infra.Seeding
{
	public static class ProductSeed
	{
		public static void SeedProduct(this ModelBuilder builder)
		{
			builder.Entity<Product>().HasData(
				new Product(1, "Caneta", "Utilizada para fazer anotações", 3.99m, DateTime.Now, 0),
				new Product(2, "Playstation 5", "Console de última geração da Sony", 4499.99m, DateTime.Now, 0),
				new Product(3, "Ar Condicionado Split Philco 9000 BTUs 220V", "Refrigera a casa toda em menos de meia hora", 1329.99m, DateTime.Now, 0),
				new Product(4, "Notebook Lenovo Ultrafino IdeaPad 3i", "Leve e potente para você carregar toda sua potência aonde for", 2294.15m, DateTime.Now, 0),
				new Product(5, "Smartphone Samsung Galaxy A03 Core", "Smartphone completo com 32gb de memória", 609.00m, DateTime.Now, 0),
				new Product(6, "Jogo de Panelas Tramontina Turim", "Jogo de panelas antiaderentes com 10 peças", 302.24m, DateTime.Now, 0),
				new Product(7, "Liquidificador Oster OLIQ610 220V", "Potente e versátil como todo produto Oster", 169.99m, DateTime.Now, 0),
				new Product(8, "Tablet Lenovo Tab P11 Plus Octa-Core", "O tablet com design do século XXII", 1999.79m, DateTime.Now, 0),
				new Product(9, "Creme Dental Sorriso Tripla Limpeza", "Limpa até 3 vezes mais que as outras pastas", 2.99m, DateTime.Now, 0),
				new Product(10, "Desodorante Antitranspirante Aerosol Dove Original", "Embalagem com 150ml", 13.99m, DateTime.Now, 0));
		}
	}
}
