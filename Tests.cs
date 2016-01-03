using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using supervkapp;
using Moq;


namespace Tests
{
	class Test
	{
		[Test]
		public void ParseUrlIsCorrect()
		{
			Assert.AreEqual(Api.ParseUrl(@"https://vk.com/id404/"), "id404");
			Assert.AreEqual(Api.ParseUrl(@"https://vk.com/egorveidt/"), "egorveidt");
		}

		[Test]
		public void ParseUrlIsNOTCorrect()
		{
			var ex = Assert.Throws<Exception>(() => Api.ParseUrl(@"https://vk.com/12345"));
			Assert.That(ex.Message, Is.EqualTo("Url is not correct."));

		}

		private Api _ApiTestUnit;

		[Test]
		public void LogicUnitTest()
		{
			var ApiTestUnit = new Mock<Api>();

			ApiTestUnit.Setup(api => api.GetUser(1)).Returns(
				new User()
				{
					Id = 1,
					FirstName = "Egor",
					LastName = "Veidt"
				});

			ApiTestUnit.Setup(api => api.GetUsers(1, 2, 3)).Returns(
				new List<User>()
				{
					new User()
					{
						Id = 1,
						FirstName = "Egor",
						LastName = "Veidt"
					},
					new User()
					{
						Id = 2,
						FirstName = "NeEgor",
						LastName = "NeVeidt"
					},
					new User()
					{
						Id = 3,
						FirstName = "lol",
						LastName = "olo"
					}
				});

			ApiTestUnit.Setup(api => api.ResolvePageAddress("egorveidt")).Returns(
				new ResolveResult()
				{
					Id = 1,
					Type = ResolveType.User
				});
			ApiTestUnit.Setup(api => api.GetFriends(1)).Returns(
				new List<User>()
				{
					new User()
					{
						Id = 2,
						FirstName = "NeEgor",
						LastName = "NeVeidt"
					},
					new User()
					{
						Id = 3,
						FirstName = "lol",
						LastName = "olo"
					}
				});

			ApiTestUnit.Setup(api => api.GetWallPosts(1, 10, 0)).Returns(
				new List<Post>()
				{
					new Post()
					{
						Id = 1,
						OwnerId = 1,
						LikesInfo = new AboutLikes()
						{
							Count = 15
						},
						Date = 1000 + (7 * 24 * 3600)
					},
					new Post()
					{
						Id = 2,
						OwnerId = 1,
						LikesInfo = new AboutLikes()
						{
							Count = 6
						},
						Date = 1000 + (7 * 24 * 3600)
					},
					new Post()
					{
						Id = 3,
						OwnerId = 1,
						LikesInfo = new AboutLikes()
						{
							Count = 7
						},
						Date = 1000 + (7 * 24 * 3600)
					}
				});
			ApiTestUnit.Setup(api => api.GetWallPosts(2, 10, 0)).Returns(
				new List<Post>()
				{
					new Post()
					{
						Id = 4,
						OwnerId = 2,
						LikesInfo = new AboutLikes()
						{
							Count = 8
						},
						Date = 1000 + (7 * 24 * 3600)
					},
					new Post()
					{
						Id = 5,
						OwnerId = 2,
						LikesInfo = new AboutLikes()
						{
							Count = 9
						},
						Date = 1000 + (7 * 24 * 3600)
					},
					new Post()
					{
						Id = 6,
						OwnerId = 2,
						LikesInfo = new AboutLikes()
						{
							Count = 10
						},
						Date = 3 * 24 * 3600
					}
				});
			ApiTestUnit.Setup(api => api.GetWallPosts(3, 10, 0)).Returns(
				new List<Post>()
				{
					new Post()
					{
						Id = 7,
						OwnerId = 3,
						LikesInfo = new AboutLikes()
						{
							Count = 1
						},
						Date = 1000 + (7 * 24 * 3600)
					},
					new Post()
					{
						Id = 8,
						OwnerId = 3,
						LikesInfo = new AboutLikes()
						{
							Count = 2
						},
						Date = 1000 + (7 * 24 * 3600)
					},
					new Post()
					{
						Id = 9,
						OwnerId = 3,
						LikesInfo = new AboutLikes()
						{
							Count = 3
						},
						Date = 1000 + (7 * 24 * 3600)
					}
				});

			_ApiTestUnit = ApiTestUnit.Object;
		}

		}
		//[Test]
		//public void GetFriendsTopPostsIsCorrect() {
		//	var vkobject = new Api();
		//	var posts = vkobject.GetFriendsTopPosts("vk.com/egorveidt", 7 * 24 * 3600, 10);
		//	Assert.AreEqual(posts.Count, 10);
		//	Assert.AreEqual(posts[0].LikesInfo.Count, 51);
		//	Assert.AreEqual(posts[9].LikesInfo.Count, 37);
		//}

	}
