using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace CoinApp.Models
{
    public class CoinInfo
    {
        [PrimaryKey]
        [JsonPropertyName("asset_id")]
        public string Code { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("data_end")]
        public string Date { get; set; }
        [JsonPropertyName("price_usd")]
        public double USDRate { get; set; }
        [JsonPropertyName("id_icon")]        
        public String Icon { get; set; }
    }
}
