using Plain.Model.Models;
using Plain.Model.Models.Model;

namespace Plain.BLL.RegisterService
{
    public class RegisterService: BaseService<Basic_Register>,IRegisterService
    {
        public Basic_Register AddRegister(Basic_Register basicRegister)
        {
            return this.CurrentResposity.Add(basicRegister);
        }

        public Basic_Register GetRegisterByToken(string token)
        {
            return this.CurrentResposity.GetNoTracking(r => r.RegisterToken.ToString() == token&&r.RegisterStatus);
        }

        public Basic_Register DeleteRegister(string token)
        {
            var entity = this.CurrentResposity.Get(r => r.RegisterToken.ToString() == token);
            if (entity != null)
            {
                entity.RegisterStatus = false;
                entity.RegisterConfirmPassword = entity.RegisterPassword;
                
                return this.CurrentResposity.Update(entity);
            }
            return null;
        }
    }
}