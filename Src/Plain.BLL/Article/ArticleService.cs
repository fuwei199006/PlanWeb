using System.Collections.Generic;
using System.Linq;
using Plain.Model.Models;
using Plain.Model.Models.Model;

namespace Plain.BLL.Article
{
    public class ArticleService:BaseService<Basic_Article>,IArticleService
    {
        public List<Basic_Article> GetArticlesByCategory(string category)
        {
            
            return
                this.LoadEntitiesNoTracking(r => r.Category == category && r.ArticleStatus == 1)
                    .OrderByDescending(r => r.ModifyTIme)
                    .ToList();
        }

        public List<Basic_Article> GetArticles()
        {
          return this.LoadEntitiesNoTracking(r=>r.ArticleStatus==1).ToList();
        }

        public Basic_Article GetArticlesById(int id)
        {
            return this.GetEntityByIdNoTracking(id);
        }

        public void AddArticleList(List<Basic_Article> articles)
        {
              this.AddRange(articles);
        }
    }
}