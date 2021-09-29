using CoinApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinApp.Services
{
    public interface ILocalCoinCache
    {
        Task SaveCoin(CoinInfo coinInfo);

        Task<List<CoinInfo>> GetAllCoinsData();
    }
}
