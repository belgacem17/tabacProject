using ProjectTABAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTABAC.Services
{
    public interface CommantaireServices
    {
        Task<IEnumerable<Commantaire>> GetCommantairesList();
        Task<Commantaire> GetCommantaireById(int id);
        Task<Commantaire> CreateCommantaire(Commantaire Commantaire);
        Task UpdateCommantaire(Commantaire Commantaire);
        Task DeleteCommantaire(int id);
    }
}
