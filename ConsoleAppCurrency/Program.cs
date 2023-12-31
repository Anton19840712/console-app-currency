﻿using ConsoleAppCurrency;
using Newtonsoft.Json;

namespace CurrencyConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			// Симулируем получение JSON-запроса
			string json = @"
            {
                ""summa"": [
                    { ""currency"": ""euro"", ""value"": 10 },
                    { ""currency"": ""usd"", ""value"": 12 }
                ],
                ""resultCurrency"": ""byn""
            }";

			// Симулируем загрузку курсов из хранилища на заданную дату
			Dictionary<string, double> exchangeRates = new Dictionary<string, double>
			{
				{ "euro", 2.5 },
				{ "usd", 2.1 },
				{ "byn", 1 }
			};

			// Десериализация JSON-запроса
			CurrencyData data = JsonConvert.DeserializeObject<CurrencyData>(json);

			// Расчет общей суммы в базовой валюте (бел.руб)
			double totalBYN = 0;
			foreach (var item in data.Summa)
			{
				string currency = item.Currency;
				double value = item.Value;
				totalBYN += value * exchangeRates[currency];
			}

			Console.WriteLine($"Результат: {totalBYN} {data.ResultCurrency}");
			Console.ReadLine();
		}
	}
}
