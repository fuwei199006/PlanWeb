using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plain.Dto.Request;
using Plain.Model.Models.Model;
using Framework.Contract;

namespace Plain.BLL.PowerService
{
    public class PowerService : BaseService<Basic_Power>, IPowerService
    {
        public Basic_Power AddPower(Basic_Power power)
        {
            return this.Add(power);
        }

        public void DeletePower(List<int> ids)
        {
            this.DeleteEntities(ids);
        }

        public IQueryable<Basic_Power> GetPowerListBtPowerIds(List<int> ids)
        {
            return this.LoadEntitiesNoTracking(r => ids.Contains(r.Id));
        }

        public Basic_Power GetPowerById(int id)
        {
            return this.GetEntityById(id);
        }

        public List<Basic_Power> GetPowerList()
        {
            return this.LoadEntitiesNoTracking(r=>r.PowerStatus==1).ToList();
        }

        public PagedList<Basic_Power> GetPowerPage(PowerRequest request)
        {
            if (string.IsNullOrEmpty(request.PowerName))
            {
                return this.LoadEntitiesByPage(r => true, r => r.CreateTime, request.PageSize, request.PageIndex);
            }
            return this.LoadEntitiesByPage(r => r.PoweName.Contains(request.PowerName), r => r.CreateTime, request.PageSize, request.PageIndex);

        }

        public Basic_Power UpdatePower(Basic_Power power)
        {
            return this.Update(power);
        }
    }
}
