using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTABAC.Models;

namespace ProjectTABAC.Services
{
 public   interface QuestionServices
    {
        Task<IEnumerable<Question>> GetQuestionsList();
        Task<Question> GetQuestionById(int id);
        Task<Question> CreateQuestion(Question Question);
        Task UpdateQuestion(Question Question);
        Task DeleteQuestion(int id);
    }
}
