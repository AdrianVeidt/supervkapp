using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace supervkapp.Vk {
	public class AboutComments
	{
		[JsonProperty("count")]
		public uint Count { get; set; }
		[JsonProperty("can_post")]
		public bool CanUserPost { get; set; }
	}
}
