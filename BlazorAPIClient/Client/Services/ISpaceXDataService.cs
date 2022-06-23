using Client.Contract;

namespace Client.Services;

public interface ISpaceXDataService
{
    Task<RocketDTO[]> GetAllRockets();
}
