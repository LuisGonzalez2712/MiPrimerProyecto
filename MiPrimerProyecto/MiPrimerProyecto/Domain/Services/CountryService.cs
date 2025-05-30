using Microsoft.EntityFrameworkCore;
using MiPrimerProyecto.DAL;
using MiPrimerProyecto.DAL.Entities;
using MiPrimerProyecto.Domain.Interfaces;

namespace MiPrimerProyecto.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                var countries = await _context.countries.ToListAsync();
                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {   
            try
            {
                var country = await _context.countries.FirstOrDefaultAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.countries.Add(country);//el metodo add me perimite crear el objeto en el contexto de mi DB
                await _context.SaveChangesAsync();//Con este metodo guardamos el pais en la tabla country

                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.countries.Update(country);//virtualizo mi objeto
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid Id)
        {
            try
            {
                var country = await GetCountryByIdAsync(Id);
                if (country == null) 
                {
                    return null;
                }

                _context.countries.Remove(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}
