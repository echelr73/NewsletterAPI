using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface INewsletterCollection
    {
        Task Insert(Newsletter newsletter);

        Task Update(Newsletter newsletter);
        Task Delete(string id);

        Task<List<Newsletter>> GetAll();

        Task<Newsletter> Get(string id);
    }
}
