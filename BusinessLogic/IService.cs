using Model;

namespace Services
{
    public interface IService
    {
        Task<RandomJokes> GetRandomJokes();
        Task<int> GetJokeCount();
    }
}