
using Newtonsoft.Json;

namespace supervkapp 
{
	public class AboutReposts
	{
		[JsonProperty("count")]
		public uint Count { get; set; }
		[JsonProperty("user_reposted")]
		public bool IsUserReposted { get; set; }
	}
}
