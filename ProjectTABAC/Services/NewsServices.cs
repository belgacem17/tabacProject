using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTABAC.Models;

namespace ProjectTABAC.Services
{
  public  interface NewsServices
    {
        Task<IEnumerable<News>> GetNewsList();
        Task<News> GetNewsById(int id);
        Task<News> CreateNews(News News);
        Task UpdateNews(News News);
        Task DeleteNews(int id);
    }
}
