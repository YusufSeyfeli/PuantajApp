using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.StudentDtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.StudentRepository
{
    public interface IStudentDal : IEntityRepository<Student>
    {

    }
}
