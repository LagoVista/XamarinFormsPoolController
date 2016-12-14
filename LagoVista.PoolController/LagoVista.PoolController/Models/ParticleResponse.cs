using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.PoolController.Models
{
    public class ParticleResponse
    {
        [JsonProperty("cmd")]
        public String Command { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("error")]
        public String Error { get; set; }

        [JsonProperty("result")]
        public String Result { get; set; }

        [JsonProperty("coreInfo")]
        public CoreInfo CoreInfo { get; set; }
    }

    public class CoreInfo
    {
        [JsonProperty("last_app")]
        public String LastApp { get; set; }

        [JsonProperty("last_heard")]
        public DateTime LastHeard { get; set; }

        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("last_handshake_at")]
        public DateTime LastHandshake { get; set; }

        [JsonProperty("deviceID")]
        public String DeviceID { get; set; }


        [JsonProperty("product_id")]
        public int ProductId { get; set; }

    }
}
