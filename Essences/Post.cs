using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace supervkapp 
{
	public class Post
	{
		[JsonProperty("id")]
		public uint Id { get; set; }
		[JsonProperty("owner_id")]
		public int OwnerId { get; set; }
		[JsonProperty("from_id")]
		public int SourceId { get; set; }

		[JsonProperty("date")]
		public uint Date { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("reply_owner_id")]
		public int ReplyOwnerId { get; set; }
		[JsonProperty("reply_post_id")]
		public uint ReplyPostId { get; set; }

		[JsonProperty("friends_only")]
		public int IsFriendsOnly { get; set; }

		[JsonProperty("comments")]
		public AboutComments CommentsInfo { get; set; }

		[JsonProperty("likes")]
		public	AboutLikes LikesInfo { get; set; }
		[JsonProperty("reposts")]
		public AboutReposts RepostsInfo { get; set; }

		[JsonProperty("post_type")]
		public PostType Type { get; set; }

		[JsonProperty("signer_id")]
		public uint SignerId { get; set; }
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum PostType
	{
		[JsonProperty("post")]
		Post,
		[JsonProperty("copy")]
		Copy,
		[JsonProperty("reply")]
		Reply,
		[JsonProperty("postpone")]
		Postpone,
		[JsonProperty("suggest")]
		Suggest
	}
}
