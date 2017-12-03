using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggingApp.Models;

namespace BloggingApp
{
	class Program
	{
		static BloggingModel db = new BloggingModel();
		static void Main(string[] args)
		{
			

			Console.ForegroundColor = ConsoleColor.Green;
			while (true)
			{
				ShowMenu();
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						CreateBlog();
						break;
					case "2":
						BlogList();
						break;
					case "3":
						NewPost();
						break;
					case "4":
						ListOfBlogsAndPost();
						break;
					case "5":
						return;
				}
			}
		}

		private static void ListOfBlogsAndPost()
		{
			BlogList();
			Console.Write("\tType a blog's name to see its title and content: ");
			var blogName = Console.ReadLine();
			var blog = db.Blog.SingleOrDefault(aBlog => aBlog.Name == blogName);
			String s = String.Format("{0,6} {1,20} {2,40} \n\n", "Blog Name", "Title", "Content");
			foreach (var aPost in db.Post.Where(post => post.Blog.Id == blog.Id))
			{
				Console.WriteLine("");
				s += String.Format("{0,6} {1,20} {2,50} \n\n", blogName, aPost.Title, aPost.Content);
				Console.WriteLine(s);
				
				Console.WriteLine("");
			}
		}

		private static void NewPost()
		{
			BlogList();
			Console.Write("\tChoose a Blog first: ");
			var blogName = Console.ReadLine();
			var blog = db.Blog.SingleOrDefault(aBlog => aBlog.Name == blogName);
			Console.Write("\tGive title of the post: ");
			var aTitle = Console.ReadLine();
			Console.Write("\type post's content: ");
			var aContent = Console.ReadLine();
			db.Post.Add(new Post {Title = aTitle, Content = aContent, Blog = blog});
			db.SaveChanges();
			Console.WriteLine("");
		
		}

		private static void BlogList()
		{
			foreach (var blogList in db.Blog)
			{
				Console.WriteLine(blogList.Name);
			}
		}

		private static void CreateBlog()
		{
			Console.Write("\tEnter a name for a new Blog: ");
			var name = Console.ReadLine();
			var blog = new Blog { Name = name };
			db.Blog.Add(blog);
			db.SaveChanges();
			Console.WriteLine("");
		}

		// Menu
		private static void ShowMenu()
		{
			Console.WriteLine("1. Add a Blog's Name");
			Console.WriteLine("2. List of Blog(s)");
			Console.WriteLine("3. Create new post");
			Console.WriteLine("4. List of items");
			Console.WriteLine("5. Quit");
			
			
		}
	}
}
