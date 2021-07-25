using ProjectTABAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTABAC.Services
{
  public  interface ReclamationServices
    {
        Task<IEnumerable<Reclamation>> GetReclamationsList();
        Task<Reclamation> GetReclamationById(int id);
        Task<Reclamation> CreateReclamation(Reclamation Reclamation);
        Task UpdateReclamation(Reclamation Reclamation);
        Task DeleteReclamation(int id);
    }
}
