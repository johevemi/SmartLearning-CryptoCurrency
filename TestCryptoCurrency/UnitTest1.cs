using System;
using Xunit;
using CryptoCurrency;

namespace TestCryptoCurrency
{
    public class UnitTest1
    {
        [Fact]
        public void TestConvert()
        {
            // arrange
            var converter = new Converter();
            string fromCurrencyName = "doge";
            string toCurrencyName = "bitcoin";
            converter.SetPricePerUnit(fromCurrencyName, 2000);
            converter.SetPricePerUnit(toCurrencyName, 3000);
            converter.SetPricePerUnit(toCurrencyName, 4000);
            double amount = 2;

            // act
            double expected = 1;
            double actual = converter.Convert(fromCurrencyName, toCurrencyName, amount);
            Console.WriteLine(actual);
            // assert
            Assert.Equal(actual, expected);
        }
    }
}
