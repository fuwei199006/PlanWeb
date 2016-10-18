
using  Framework.Contract;

namespace Plain.Dto.Request
{
    public class MenuRequest:Framework.Contract.Request
    {
        public MenuRequest()
        {
            this.Top = 20;
        }
    }
}