using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Repositories
{
    public class CourseRegisterRepository(OnlineEduContext context) : GenericRepository<CourseRegister>(context), ICourseRegisterRepository
    {
        private readonly OnlineEduContext _context = context;

        public List<CourseRegister> GetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> filter)
        {
            return _context.CourseRegisters.Where(filter).Include(x => x.Course).ThenInclude(x => x.CourseCategory).ToList();
        }
    }
}
