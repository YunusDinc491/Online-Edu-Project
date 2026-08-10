using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineEdu.Business.Concrete
{
    public class CourseRegisterManager : GenericManager<CourseRegister>, ICourseRegisterService
    {
        private readonly ICourseRegisterRepository _courseRegisterRepository;

        public CourseRegisterManager(IRepository<CourseRegister> repository, ICourseRegisterRepository courseRegisterRepository) : base(repository)
        {
            _courseRegisterRepository = courseRegisterRepository;
        }

        public List<CourseRegister> TGetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> filter)
        {
            return _courseRegisterRepository.GetAllWithCourseAndCategory(filter);
        }
    }
}
