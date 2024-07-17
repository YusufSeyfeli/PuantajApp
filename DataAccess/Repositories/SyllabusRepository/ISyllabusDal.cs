using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.SyllabusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.SyllabusRepository
{
    public interface ISyllabusDal : IEntityRepository<Syllabus>
    {
    }
}
