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
    public class IReclamationServices : ReclamationServices
    {
        private readonly TabacDbContext connexion;

        public IReclamationServices(TabacDbContext context)
        {
            connexion = context;
        }
        public async Task<Reclamation> CreateReclamation(Reclamation Reclamation)
        {
            connexion.Reclamations.Add(Reclamation);
            await connexion.SaveChangesAsync();
            return Reclamation;
        }

        public async Task DeleteReclamation(int id)
        {
            Reclamation Reclamation = new Reclamation() { ReclamationId = id };
            connexion.Reclamations.Remove(Reclamation);
            await connexion.SaveChangesAsync();
        }

        public async Task<Reclamation> GetReclamationById(int id)
        {
            //return await connexion.Reclamation.Find(id);
            return await connexion.Reclamations
           .Include(Reclamation => Reclamation)
           .FirstOrDefaultAsync(Reclamation => Reclamation.ReclamationId == id);
        }

        public async Task<IEnumerable<Reclamation>> GetReclamationsList()
        {
            return await connexion.Reclamations.ToListAsync();
        }

        public async Task UpdateReclamation(Reclamation Reclamation)
        {
            connexion.Reclamations.Update(Reclamation);
            await connexion.SaveChangesAsync();
        }
    }
}