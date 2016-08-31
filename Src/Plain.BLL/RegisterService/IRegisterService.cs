using Plain.Model.Models;

namespace Plain.BLL.RegisterService
{
    public interface IRegisterService:IBaseService<Basic_Register>
    {
        Basic_Register AddRegister(Basic_Register basicRegister);
        Basic_Register GetRegisterByToken(string token);
        Basic_Register DeleteRegister(string token);

    }
}