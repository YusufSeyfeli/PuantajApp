using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.EmailParameterRepository.Constans;
using Business.Repositories.EmailParameterRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.EmailParameterRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.EmailParameter;
using Entities.Dtos.EmailParameterDtos;
using Entities.Dtos.UserDtos;
using System.Net;
using System.Net.Mail;

namespace Business.Repositories.EmailParameterRepository
{
    public class EmailParameterManager : IEmailParameterService
    {
        private readonly IEmailParameterDal _emailParameterDal;
        private readonly IMapper _mapper;

        public EmailParameterManager(IEmailParameterDal emailParameterDal, IMapper mapper)
        {
            _emailParameterDal = emailParameterDal;
            _mapper = mapper;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(EmailParameterValidator))]
        public async Task<IResult> Add(EmailParameterDto emailParameterDto)
        {

            var mapper = _mapper.Map<EmailParameter>(emailParameterDto);
            try
            {
                await _emailParameterDal.Add(mapper);
                return new SuccessResult(EmailParameterMessages.AddedEmailParameter);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }

        [SecuredAspect()]
        public async Task<IResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new ErrorDataResult<EmailParameter>("Id boş gönderilemez!!");
            }
            try
            {
                await _emailParameterDal.Delete(id);
                return new SuccessResult(EmailParameterMessages.DeletedEmailParameter);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<IDataResult<EmailParameter>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new ErrorDataResult<EmailParameter>("Id boş gönderilemez!!");
            }
            return new SuccessDataResult<EmailParameter>(await _emailParameterDal.Get(p => p.EmailParameterGuidId == id));
        }

        public async Task<EmailParameter> GetFirst()
        {
            return await _emailParameterDal.GetFirst();
        }

        [CacheAspect()]
        public async Task<IDataResult<List<EmailParameterGetListDto>>> GetList()
        {
            List<EmailParameter> listEmailParameter = await _emailParameterDal.GetAll();

            var myListEmailParameter = _mapper.Map<List<EmailParameterGetListDto>>(listEmailParameter);
            return new SuccessDataResult<List<EmailParameterGetListDto>>(myListEmailParameter);
        }

        public async Task<IResult> SendEmail(EmailParameter emailParameter, string body, string subject, string emails)
        {
            using (MailMessage mail = new MailMessage())
            {
                string[] setEmails = emails.Split(",");
                mail.From = new MailAddress(emailParameter.Email);
                foreach (var email in setEmails)
                {
                    mail.To.Add(email);
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = emailParameter.Html;
                //mail.Attachments.Add();
                using (SmtpClient smtp = new SmtpClient(emailParameter.Smtp))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailParameter.Email, emailParameter.Password);
                    smtp.EnableSsl = emailParameter.SSL;
                    smtp.Port = emailParameter.Port;
                    await smtp.SendMailAsync(mail);
                }
            }
            return new SuccessResult(EmailParameterMessages.EmailSendSuccesiful);

        }

        [SecuredAspect()]
        [ValidationAspect(typeof(EmailParameterValidator))]
        public async Task<IResult> Update(EmailParameterUpdateDto emailParameterUpdateDto)
        {
            if (emailParameterUpdateDto.EmailParameterGuidId == Guid.Empty)
            {
                return new ErrorDataResult<EmailParameterUpdateDto>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<EmailParameter>(emailParameterUpdateDto);
            try
            {
                await _emailParameterDal.Update(mapper);
                return new SuccessResult(EmailParameterMessages.UpdatedEmailParameter);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
