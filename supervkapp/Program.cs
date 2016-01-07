using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using supervkapp;
using ORM;
using Domains;
using ORM.UnitOfWork;
using Repositories;

namespace supervkapp
{
	class Program
	{
		private const string ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=supervkappdb"; //
		static void Main(string[] args)
		{
			var nhibernatehelper = new NHibernateHelper(ConnectionString);
			var unitofwork = new UnitOfWork(nhibernatehelper.SessionFactory);

			//попробуем чонить добавить в бд

			var user = new UserDomain
			{
				//Id = "egorveidt", какого черта я сделал интовый айдишник, фаак !!! переделать
				FirstName = "Егор",
				LastName = "Пичугов",
				Age = 21,
				Male = true
			};
			var post = new PostDomain
			{
				Date = new DateTime(2016, 01, 07),
				Text = "test text exst",
			};
			var userRepository = new Repository<UserDomain>(unitofwork.Session);
			user.AddPost(post);
			userRepository.Save(user);
			unitofwork.Commit();

		}
		static void Test()
		{
			var vkobject = new Api();
			var posts = vkobject.GetFriendsTopPosts("https://vk.com/egorveidt/", (7 * 24 * 3600), 10);
			foreach (var post in posts)
			{
				Console.WriteLine("PostID \t {0} \t ownerID: {1} \t likes: {2}", post.Id, post.OwnerId, post.LikesInfo.Count);
			}
			Console.ReadKey();
		}
	}
}
