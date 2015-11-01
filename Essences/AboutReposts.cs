
using Newtonsoft.Json;

namespace supervkapp.Vk {
	public class AboutReposts
	{
		[JsonProperty("count")]
		public uint Count { get; set; }
		[JsonProperty("user_reposted")]
		public bool IsUserReposted { get; set; }
	}
}
