using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace supervkapp.Vk {
	public class ResolveResult
	{
		[JsonProperty("type")]
		public ResolveType Type { get; set; }
		[JsonProperty("object_id")]
		public uint Id { get; set; }
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum ResolveType
	{
		[JsonProperty("user")]
		User,
		[JsonProperty("group")]
		Group,
		[JsonProperty("application")]
		Application,
		[JsonProperty("page")]
		Page
	}
}
