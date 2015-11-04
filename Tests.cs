using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using supervkapp;

namespace Tests {
	class Test {
		[Test]
		public void ParseUrlIsCorrect() {
			Assert.AreEqual(Api.ParseUrl(@"https://vk.com/id404/"), "id404");
			Assert.AreEqual(Api.ParseUrl(@"https://vk.com/egorveidt/"), "egorveidt");
		}

		[Test]
		public void GetFriendsTopPostsIsCorrect() {
			var vkobject = new Api();
			var posts = vkobject.GetFriendsTopPosts("vk.com/egorveidt", 7 * 24 * 3600, 10);
			Assert.AreEqual(posts.Count, 10);
			Assert.AreEqual(posts[0].LikesInfo.Count, 51);
			Assert.AreEqual(posts[9].LikesInfo.Count, 37);
		}

	}
}
