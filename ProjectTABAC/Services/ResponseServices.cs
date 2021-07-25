using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTABAC.Models;

namespace ProjectTABAC.Services
{
    public interface ResponseServices
    {
        Task<IEnumerable<Response>> GetResponsesList();
        Task<Response> GetResponseById(int id);
        Task<Response> CreateResponse(Response Response);
        Task UpdateResponse(Response Response);
        Task DeleteResponse(int id);
    }
}
