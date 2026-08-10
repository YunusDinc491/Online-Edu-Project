using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineEdu.Business.Concrete
{
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(IRepository<Course> repository, ICourseRepository courseRepository) : base(repository)
        {
            _courseRepository = courseRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _courseRepository.DontShowOnHome(id);
        }

        public List<Course> TGetAllCoursesWithCategories()
        {
            return _courseRepository.GetAllCoursesWithCategories();
        }

        public List<Course> TGetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null)
        {
            return _courseRepository.GetAllCoursesWithCategories(filter);
        }

        public List<Course> TGetCoursesByTeacherId(int id)
        {
            return _courseRepository.GetCoursesByTeacherId(id);
        }

        public void TShowOnHome(int id)
        {
            _courseRepository.ShowOnHome(id);
        }
    }
}
