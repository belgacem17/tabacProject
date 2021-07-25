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
    public class ICommantaireServices : CommantaireServices
    {
        private readonly TabacDbContext connexion;

        public ICommantaireServices(TabacDbContext context)
        {
            connexion = context;
        }
        public async Task<Commantaire> CreateCommantaire(Commantaire Commantaire)
        {
            connexion.Commantaires.Add(Commantaire);
            await connexion.SaveChangesAsync();
            return Commantaire;
        }

        public async Task DeleteCommantaire(int id)
        {
            Commantaire Commantaire = new Commantaire() { CommantaireId = id };
            connexion.Commantaires.Remove(Commantaire);
            await connexion.SaveChangesAsync();
        }

        public async Task<Commantaire> GetCommantaireById(int id)
        {
            //return await connexion.Commantaire.Find(id);
            return await connexion.Commantaires
           .Include(Commantaire => Commantaire)
           .FirstOrDefaultAsync(Commantaire => Commantaire.CommantaireId == id);
        }

        public async Task<IEnumerable<Commantaire>> GetCommantairesList()
        {
            return await connexion.Commantaires.ToListAsync();
        }

        public async Task UpdateCommantaire(Commantaire Commantaire)
        {
            connexion.Commantaires.Update(Commantaire);
            await connexion.SaveChangesAsync();
        }
    }
}

