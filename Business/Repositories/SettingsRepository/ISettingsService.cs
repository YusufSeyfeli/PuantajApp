using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.SettingsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.SettingsRepository
{
    public interface ISettingsService
    {
        Task<IResult> Add(SettingsDto settingsDto);
        Task<IResult> Update(SettingsUpdateDto settingsUpdateDto);
        Task<IResult> Delete(Guid settingsGuidId);
        Task<IDataResult<List<SettingsGetListDto>>> GetList();
        Task<IDataResult<Settings>> GetById(Guid SettingsGuidId);
        Task<Settings> GetByIdForSettingsService(Guid SettingsGuidId);

    }
}
