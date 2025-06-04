using Microsoft.Identity.Client;

namespace MiPrimerProyecto.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;


        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //creamos un metodo SeederAsync
        //este metodo es una especie de MAIN()
        //Este metodo tendra la responsabilidad de repoblar todas las tablas de la DB

        public async Task SeederAsync()
        {
            //Agregamos un metodo propio de EF que hace las veces del comando update-databse
            //Es un metodo que me creara la DB inmediatamente ponga en ejecucion mi api

            await _context.Database.EnsureCreatedAsync();

            //Desde aqui vamos creando metodos que me sirvan para repoblar mi DB
            await PopulateCountriesAsyn();
        }

        #region Private Methos

        private async Task PopulateCountriesAsyn()
        {
            if (!_context.countries.Any()) //El metodo Any(), me verifica de que por lo menos exista un registro
            {

            }

        }
        #endregion
    }
}
