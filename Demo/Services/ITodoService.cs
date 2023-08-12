using Demo.Models;

namespace Demo.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetDotos();
    }
}
