using Plain.Model.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.BLL.CommitService
{
    public class CommitService : BaseService<Basic_Commit>, ICommitService
    {
        public List<Basic_Commit> GetCommitListById(int articleId)
        {
            return this.LoadEntities(r => r.ArticleId == articleId);
        }
    }
}
