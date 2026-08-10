using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OnlineEdu.DataAccess.Repositories
{
    public class BlogRepository(OnlineEduContext context) : GenericRepository<Blog>(context), IBlogRepository
    {
        private readonly OnlineEduContext _context = context;

        public List<Blog> GetBlogsByCategoryId(int id)
        {
            return _context.Blogs.Include(x => x.blogCategory).Include(x => x.Writer).Where(x => x.BlogCategoryId == id).ToList();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.blogCategory).Include(x => x.Writer).ToList();
        }

        public List<Blog> GetBlogsWithCategoriesByWriterId(int id)
        {
            return _context.Blogs.Include(x => x.blogCategory).Where(x => x.WriterId == id).ToList();
        }

        public Blog GetBlogWithCategory(int id)
        {
            return _context.Blogs.Include(x => x.blogCategory).Include(x => x.Writer).FirstOrDefault(x => x.BlogId == id);
        }

        public List<Blog> GetLast4BlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.blogCategory).OrderByDescending(x => x.BlogId).Take(4).ToList();
        }
    }
}
