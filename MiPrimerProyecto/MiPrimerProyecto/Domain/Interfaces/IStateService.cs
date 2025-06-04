using MiPrimerProyecto.DAL.Entities;

namespace MiPrimerProyecto.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStateByCountryIdAsync(Guid countryId);

        Task<State> CreateStateAsync(State state);

        Task<State> GetStateByNameAsync(string name);

        Task<State> EditStateAsync(State state);

        Task<State> DeleteStateAsync(Guid id);
    }
}
