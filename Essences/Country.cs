
using Newtonsoft.Json;

namespace supervkapp.Vk {
	public class Country
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
	}
}
