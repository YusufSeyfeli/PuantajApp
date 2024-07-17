using Core.DataAccess.EntityFramework;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.SyllabusDtos;
using Entities.Dtos.TallyDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.SyllabusRepository
{

    public class EfSyllabusDal : EfEntityRepositoryBase<Syllabus, SimpleContextDb>, ISyllabusDal
    {

    }
}
