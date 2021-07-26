using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinApp.Models;

namespace CoinApp.Services
{
    public interface ICoinService
    {
        /// <summary>
        /// Returns All Coin Related Info
        /// </summary>
        /// <returns></returns>
        Task<List<CoinInfo>> GetAllCoinInfo();

        /// <summary>
        /// Returns Info about a specific coin
        /// </summary>
        /// <returns></returns>
        Task<CoinInfo> GetCoinInfo();
    }
}
