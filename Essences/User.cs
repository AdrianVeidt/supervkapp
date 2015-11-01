
using Newtonsoft.Json;

namespace supervkapp.Vk {
	public class User {
		[JsonProperty("id")]
		public uint Id { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }
		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("deactivated")]
		public DeactivatedStatus Deactivated { get; set; }
		[JsonProperty("hidden")]
		public bool IsHidden { get; set; }

		[JsonProperty("photo_id")]
		public string PhotoId { get; set; }

		[JsonProperty("verified")]
		public bool IsVerified { get; set; }
		[JsonProperty("blacklisted")]
		public bool IsBlacklisted { get; set; }

		[JsonProperty("sex")]
		public Sex Sex { get; set; }

		[JsonProperty("bdate")]
		public string Birthday { get; set; }

		[JsonProperty("city")]
		public City City { get; set; }
		[JsonProperty("country")]
		public Country Country { get; set; }
		[JsonProperty("home_town")]
		public string HomeTown { get; set; }

		[JsonProperty("online")]
		public bool IsOnline { get; set; }
	}

	public enum DeactivatedStatus {
		None = 0,
		Deleted = 1,
		Banned = 2
	}

	public enum Sex {
		None = 0,
		Female = 1,
		Male = 2
	}
}
