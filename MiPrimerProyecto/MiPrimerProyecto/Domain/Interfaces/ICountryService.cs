using MiPrimerProyecto.DAL.Entities;

namespace MiPrimerProyecto.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>>GetCountriesAsync();//Una de las tantas firmas de un metodo

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid Id);
    }
}
