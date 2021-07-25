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
    public class IResponseServices : ResponseServices
    {
        private readonly TabacDbContext connexion;

        public IResponseServices(TabacDbContext context)
        {
            connexion = context;
        }
        public async Task<Response> CreateResponse(Response Response)
        {
            connexion.Responses.Add(Response);
            await connexion.SaveChangesAsync();
            return Response;
        }

        public async Task DeleteResponse(int id)
        {
            Response Response = new Response() { ResponseId = id };
            connexion.Responses.Remove(Response);
            await connexion.SaveChangesAsync();
        }

        public async Task<Response> GetResponseById(int id)
        { 
            return await connexion.Responses
           .Include(Response => Response)
           .FirstOrDefaultAsync(Response => Response.ResponseId == id);
        }

        public async Task<IEnumerable<Response>> GetResponsesList()
        {
            return await connexion.Responses.ToListAsync();
        }

        public async Task UpdateResponse(Response Response)
        {
            connexion.Responses.Update(Response);
            await connexion.SaveChangesAsync();
        }
    }
}
