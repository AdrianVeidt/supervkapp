using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace supervkapp 
{
	public class User 
	{
		[JsonProperty("id")]
		public uint Id {
			get;
			set;
		}

		[JsonProperty("first_name")]
		public string FirstName 
		{
			get;
			set;
		}
		[JsonProperty("last_name")]
		public string LastName 
		{
			get;
			set;
		}

		[JsonProperty("photo_id")]
		public string PhotoId 
		{
			get;
			set;
		}

		[JsonProperty("online")]
		public bool IsOnline 
		{
			get;
			set;
		}
	}
	public class Post 
	{
		[JsonProperty("id")]
		public uint Id {
			get;
			set;
		}
		[JsonProperty("owner_id")]
		public int OwnerId 
		{
			get;
			set;
		}
		[JsonProperty("from_id")]
		public int SourceId 
		{
			get;
			set;
		}

		[JsonProperty("date")]
		public uint Date 
		{
			get;
			set;
		}

		[JsonProperty("text")]
		public string Text 
		{
			get;
			set;
		}


		[JsonProperty("comments")]
		public AboutComments CommentsInfo 
		{
			get;
			set;
		}

		[JsonProperty("likes")]
		public AboutLikes LikesInfo 
		{
			get;
			set;
		}
		[JsonProperty("reposts")]
		public AboutReposts RepostsInfo 
		{
			get;
			set;
		}

		[JsonProperty("post_type")]
		public PostType Type 
		{
			get;
			set;
		}

		//[JsonProperty("signer_id")]
		//public uint SignerId
		//{
		//	get;
		//	set;
		//}
		//[JsonProperty("reply_owner_id")]
		//public int ReplyOwnerId
		//{
		//	get;
		//	set;
		//}
		//[JsonProperty("reply_post_id")]
		//public uint ReplyPostId
		//{
		//	get;
		//	set;
		//}

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
	public class AboutReposts 
	{
		[JsonProperty("count")]
		public uint Count 
		{
			get;
			set;
		}
		[JsonProperty("user_reposted")]
		public bool IsUserReposted 
		{
			get;
			set;
		}
	}
	public class AboutLikes 
	{
		[JsonProperty("count")]
		public uint Count 
		{
			get;
			set;
		}
		[JsonProperty("user_likes")]
		public bool WasUserLikes 
		{
			get;
			set;
		}
		[JsonProperty("can_likes")]
		public bool CanUserLikes 
		{
			get;
			set;
		}
		[JsonProperty("can_publish")]
		public bool CanUserPublish 
		{
			get;
			set;
		}
	}
	public class AboutComments {
		[JsonProperty("count")]
		public uint Count 
		{
			get;
			set;
		}
		[JsonProperty("can_post")]
		public bool CanUserPost 
		{
			get;
			set;
		}
	}
	public class ResolveResult 
	{
		[JsonProperty("type")]
		public ResolveType Type 
		{
			get;
			set;
		}
		[JsonProperty("object_id")]
		public uint Id 
		{
			get;
			set;
		}

	}
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ResolveType {
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