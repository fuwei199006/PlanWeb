using Framework.Contract;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.PowerService
{
   public interface IPowerService
    {
        PagedList<Basic_Power> GetPowerPage(PowerRequest request);


        List<Basic_Power> GetPowerList();
        List<Basic_Power> GetPowerListBtPowerIds(List<int> ids );
        Basic_Power GetPowerById(int id);

        Basic_Power UpdatePower(Basic_Power power);
        void DeletePower(List<int> ids);

        Basic_Power AddPower(Basic_Power power);
    }
}
