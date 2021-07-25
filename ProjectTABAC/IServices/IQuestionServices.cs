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
    public class IQuestionServices : QuestionServices
    {
        private readonly TabacDbContext connexion;

        public IQuestionServices(TabacDbContext context)
        {
            connexion = context;
        }
        public async Task<Question> CreateQuestion(Question Question)
        {
            connexion.Questions.Add(Question);
            await connexion.SaveChangesAsync();
            return Question;
        }

        public async Task DeleteQuestion(int id)
        {
            Question Question = new Question() { QuestionId = id };
            connexion.Questions.Remove(Question);
            await connexion.SaveChangesAsync();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            //return await connexion.Question.Find(id);
            return await connexion.Questions
           .Include(Question => Question)
           .FirstOrDefaultAsync(Question => Question.QuestionId == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsList()
        {
            return await connexion.Questions.ToListAsync();
        }

        public async Task UpdateQuestion(Question Question)
        {
            connexion.Questions.Update(Question);
            await connexion.SaveChangesAsync();
        }
    }
}
