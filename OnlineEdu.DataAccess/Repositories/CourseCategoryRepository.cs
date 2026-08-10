using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class CourseCategoryRepository(OnlineEduContext context) : GenericRepository<CourseCategory>(context), ICourseCategoryRepository
    {
        private readonly OnlineEduContext _context = context;

        public void DontShowOnHome(int id)
        {
            var value = _context.CourseCategories.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.CourseCategories.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}
