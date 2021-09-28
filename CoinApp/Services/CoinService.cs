using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinApp.Models;
using CoinApp.Services;
using Refit;
using Xamarin.Forms;

namespace CoinApp.Services
{
    public class CoinService : ICoinService
    {
        private readonly ICoinAPIService coinAPIService;

        public CoinService()
        {
            coinAPIService = RestService.For<ICoinAPIService>("https://rest.coinapi.io/v1");
        }

        public async Task<List<CoinInfo>> GetAllCoinInfo()
        {
            return await coinAPIService.GetAllCoinInfo("BTC,ETH,ADA,USDT,BNB");
        }

        public Task<CoinInfo> GetCoinInfo()
        {
            throw new NotImplementedException();
        }
    }
}
