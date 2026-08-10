using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseCategoryManager : GenericManager<CourseCategory>, ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public CourseCategoryManager(IRepository<CourseCategory> repository, ICourseCategoryRepository courseCategoryRepository) : base(repository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _courseCategoryRepository.DontShowOnHome(id);
        }

        public void TShowOnHome(int id)
        {
            _courseCategoryRepository.ShowOnHome(id);
        }
    }
}
