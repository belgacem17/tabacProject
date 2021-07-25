using Microsoft.EntityFrameworkCore;
using ProjectTABAC.Data;
using ProjectTABAC.Models;
using ProjectTABAC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTABAC.IServices
{
    public class INewsServices : NewsServices
    {
        private readonly TabacDbContext connexion;

        public INewsServices(TabacDbContext context)
        {
            connexion = context;
        }
        public async Task<News> CreateNews(News News)
        {
            connexion.News.Add(News);
            await connexion.SaveChangesAsync();
            return News;
        }

        public async Task DeleteNews(int id)
        {
            News News = new News() { NewsId = id };
            connexion.News.Remove(News);
            await connexion.SaveChangesAsync();
        }

        public async Task<News> GetNewsById(int id)
        {
            //return await connexion.News.Find(id);
            return await connexion.News
           .Include(News => News)
           .FirstOrDefaultAsync(News => News.NewsId == id);
        }

        public async Task<IEnumerable<News>> GetNewsList()
        {
            return await connexion.News
                 .Include(u => u.User)
                 .ToListAsync();
        }

        public async Task UpdateNews(News News)
        {
            connexion.News.Update(News);
            await connexion.SaveChangesAsync();
        }
    }
} 
