using OnlineEdu.Entity.Entities;
using System.Collections.Generic;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();
        List<Blog> TGetBlogsByCategoryId(int id);
        Blog TGetBlogWithCategory(int id);
        List<Blog> TGetLast4BlogsWithCategories();
        List<Blog> TGetBlogsWithCategoriesByWriterId(int id);
    }
}
