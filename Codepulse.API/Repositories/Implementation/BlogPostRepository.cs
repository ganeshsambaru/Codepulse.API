using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;

namespace CodePulse.API.Repositories.Implementation
{
    public class BlogPostRepositary : IBlogPostRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostRepositary(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
      

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }


    }
}
