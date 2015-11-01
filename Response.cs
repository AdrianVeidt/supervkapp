using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace supervkapp {
	class PostsResponse {
		[JsonProperty("count")]
		public uint Count {
			get;
			set;
		}
		[JsonProperty("items")]
		public List<Post> Posts {
			get;
			set;
		}
	}
	abstract class FriendsResponse {
		[JsonProperty("count")]
		public uint Count {
			get;
			set;
		}
	}

	class FriendsIdsResponse : FriendsResponse {
		[JsonProperty("items")]
		public List<uint> FriendsIds {
			get;
			set;
		}
	}

	class FriendsUsersResponse : FriendsResponse {
		[JsonProperty("items")]
		public List<User> Friends {
			get;
			set;
		}
	}

	class Reply<T> {
		[JsonProperty("response")]
		public T Response {
			get;
			set;
		}

		[JsonProperty("error")]
		public ErrorResponse Error {
			get;
			set;
		}
	}

	class ErrorResponse {
		[JsonProperty("error_code")]
		public int Code {
			get;
			set;
		}
		[JsonProperty("error_msg")]
		public string Message {
			get;
			set;
		}
	}
}
