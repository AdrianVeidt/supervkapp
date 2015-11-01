using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace supervkapp.Vk {
	public class City
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
	}
}
