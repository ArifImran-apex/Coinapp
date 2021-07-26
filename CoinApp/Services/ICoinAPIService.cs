using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinApp.Models;
using Refit;

namespace CoinApp.Services
{
    [Headers("X-CoinAPI-Key: 9707C77A-A133-493F-9496-FC3F90812111")]
    public interface ICoinAPIService
    {
        [Get("/assets?filter_asset_id={filter_asset_id}")]
        Task<List<CoinInfo>> GetAllCoinInfo(string filter_asset_id);
    }
}
