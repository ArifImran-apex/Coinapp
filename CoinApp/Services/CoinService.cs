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
        private readonly ILocalCoinCache localCoinCache;
        public CoinService(ILocalCoinCache localCoinCache)
        {
            this.localCoinCache = localCoinCache;
            coinAPIService = RestService.For<ICoinAPIService>("https://rest.coinapi.io/v1");
        }

        public async Task<List<CoinInfo>> GetAllCoinInfo()
        {
            try
            {
                var coins = await coinAPIService.GetAllCoinInfo("BTC,ETH,ADA,USDT,BNB");

                //Save Locally
                foreach (var coin in coins)
                {
                    await localCoinCache.SaveCoin(coin);
                }

                return await localCoinCache.GetAllCoinsData();
            }
            catch(Exception ex)
            {
                return await localCoinCache.GetAllCoinsData();
            }
        }

        public Task<CoinInfo> GetCoinInfo()
        {
            throw new NotImplementedException();
        }
    }
}
