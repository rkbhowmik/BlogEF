namespace BloggingApp.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class BloggingModel : DbContext
	{
		public BloggingModel()
			: base("name=Blogging")
		{
		}

		public virtual DbSet<Blog> Blog { get; set; }
		public virtual DbSet<Post> Post { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Blog>()
				.HasOptional(e => e.Post)
				.WithRequired(e => e.Blog);
		}
	}
}
