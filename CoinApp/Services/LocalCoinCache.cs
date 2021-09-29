using CoinApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CoinApp.Services
{
    public class LocalCoinCache : ILocalCoinCache
    {
        SQLiteAsyncConnection db;
        string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
        public LocalCoinCache()
        {
            Task.Run(async () => await Init());
        }
        async Task Init()
        {           
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<CoinInfo>();

            Console.WriteLine("Table created!");
        }
        public async Task<List<CoinInfo>> GetAllCoinsData()
        {
            return await db.Table<CoinInfo>().ToListAsync();
        }

        public async Task SaveCoin(CoinInfo coinInfo)
        {
            await db.InsertAsync(coinInfo);
        }
    }
}
