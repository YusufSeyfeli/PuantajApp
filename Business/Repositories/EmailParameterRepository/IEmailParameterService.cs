using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.EmailParameter;
using Entities.Dtos.EmailParameterDtos;

namespace Business.Repositories.EmailParameterRepository
{
    public interface IEmailParameterService
    {
        Task<IResult> Add(EmailParameterDto emailParameterDto);
        Task<IResult> Update(EmailParameterUpdateDto emailParameterUpdateDto);
        Task<IResult> Delete(Guid id);
        Task<IDataResult<List<EmailParameterGetListDto>>> GetList();
        Task<IDataResult<EmailParameter>> GetById(Guid EmailParameterGuidId);
        Task<EmailParameter> GetFirst();
        Task<IResult> SendEmail(EmailParameter emailParameter, string body, string subject, string emails);
    }
}
