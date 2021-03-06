using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCurrency
{
    public class Converter
    {
        public List<CryptoCoin> CryptoCoins = new List<CryptoCoin>();
        /// <summary>
        /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
        /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
        /// bliver den gamle værdi overskrevet af den nye værdi
        /// </summary>
        /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
        /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
        public void SetPricePerUnit(String currencyName, double price)
        {
            if (price < 0)
            {
                return;
            }
            var cc = new CryptoCoin
            {
                Name = currencyName,
                Price = price
            };

            if (CryptoCoins.Any(x => x.Name == currencyName))
            {
                CryptoCoins.Remove(CryptoCoins.Single(x => x.Name == currencyName));
            }
            CryptoCoins.Add(cc);
        }

        /// <summary>
        /// Konverterer fra en kryptovaluta til en anden. 
        /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
        /// 
        /// </summary>
        /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
        /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
        /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
        /// <returns>Værdien af beløbet i toCurrencyName</returns>ArgumentException
        public double Convert(String fromCurrencyName, String toCurrencyName, double amount)
        {
            try
            {
                var fromCurrencyCryptoCoinPrice = CryptoCoins.Single(x => x.Name == fromCurrencyName).Price;
                var toCurrencyNameCryptoCoinPrice = CryptoCoins.Single(x => x.Name == toCurrencyName).Price;
                if (fromCurrencyCryptoCoinPrice == 0 || toCurrencyNameCryptoCoinPrice == 0)
                    return 0;
                return amount * fromCurrencyCryptoCoinPrice / toCurrencyNameCryptoCoinPrice;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
    }

    public class CryptoCoin
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}