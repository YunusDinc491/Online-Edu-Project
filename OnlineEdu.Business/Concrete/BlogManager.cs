using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System.Collections.Generic;

namespace OnlineEdu.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IRepository<Blog> repository, IBlogRepository blogRepository) : base(repository)
        {
            _blogRepository = blogRepository;
        }

        public Blog TGetBlogWithCategory(int id)
        {
            return _blogRepository.GetBlogWithCategory(id);
        }

        public List<Blog> TGetBlogsWithCategories()
        {
            return _blogRepository.GetBlogsWithCategories();
        }

        public List<Blog> TGetBlogsWithCategoriesByWriterId(int id)
        {
            return _blogRepository.GetBlogsWithCategoriesByWriterId(id);
        }

        public List<Blog> TGetLast4BlogsWithCategories()
        {
            return _blogRepository.GetLast4BlogsWithCategories();
        }

        public List<Blog> TGetBlogsByCategoryId(int id)
        {
            return _blogRepository.GetBlogsByCategoryId(id);
        }
    }
}
