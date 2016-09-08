using System.Collections.Generic;
using System.Linq;
using Plain.Model.Models;

namespace Plain.BLL.Article
{
    public class ArticleService:BaseService<Basic_Article>,IArticleService
    {
        public List<Basic_Article> GetArticlesByCategory(string category)
        {
            return
                this.CurrentResposity.GetListNoTracking(r => r.Category == category && r.ArticleStatus == 1)
                    .OrderByDescending(r => r.ModifyTIme)
                    .ToList();
        }
    }
}