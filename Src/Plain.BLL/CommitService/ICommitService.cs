using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.CommitService
{
   public interface ICommitService:IBaseService<Basic_Commit>
    {
        List<Basic_Commit> GetCommitListById(int articleId);
        void AddCommit(Basic_Commit commit);
    }
}
