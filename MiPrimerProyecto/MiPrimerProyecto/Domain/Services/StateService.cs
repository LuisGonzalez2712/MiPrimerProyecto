using Microsoft.EntityFrameworkCore;
using MiPrimerProyecto.DAL;
using MiPrimerProyecto.DAL.Entities;
using MiPrimerProyecto.Domain.Interfaces;

namespace MiPrimerProyecto.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStateByCountryIdAsync(Guid countryId)
        {
            try
            {

                var states = await _context.States.Where(s => s.CountryId == countryId).ToListAsync();
                return states;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByNameAsync(string name)
        {
            var state = await _context.States.FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
            return state;
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                if (state == null) return null;

                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
