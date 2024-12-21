using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AhtymovEkz.Models
{
    public class ListCard
    {
        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }   
    }
}
