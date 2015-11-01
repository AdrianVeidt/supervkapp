using Newtonsoft.Json;

namespace supervkapp 
{
	public class AboutLikes
	{
		[JsonProperty("count")]
		public uint Count { get; set; }
		[JsonProperty("user_likes")]
		public bool WasUserLikes { get; set; }
		[JsonProperty("can_likes")]
		public bool CanUserLikes { get; set; }
		[JsonProperty("can_publish")]
		public bool CanUserPublish { get; set; }
	}
}
