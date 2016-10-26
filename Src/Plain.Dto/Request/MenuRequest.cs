
using  Framework.Contract;

namespace Plain.Dto.Request
{
    public class MenuRequest: Framework.Contract.Request
    {
        public MenuRequest()
        {
            Top = 10;
        }
        public string MenuName { get; set; }
    }
}