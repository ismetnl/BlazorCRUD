using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLeaflet.Samples.Data
{
    public class AirportServices
    {
        #region Private members
        private AirportDbContext dbContext;
        #endregion
        #region Constructor
        public AirportServices(AirportDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion
        #region Public methods
        /// <summary>
        /// This method returns the list of product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Airport>> GetAirportAsync()
        {
            return await dbContext.Airport.ToListAsync();
        }

        public async Task<Airport> AddAirportAsync(Airport Airport)
        {
            try
            {
                dbContext.Airport.Add(Airport);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Airport;
        }
        public Airport FindAirport(String name)
        {
            var productExist = dbContext.Airport.FirstOrDefault(a => a.Name == name);

            if (productExist != null)
            {
                return productExist;
            }
            else
            {
                return null;
            }
        }


        
        /// <summary>
        /// This method update and existing product and saves the changes
        /// </summary>
        /// <param name="Airport"></param>
        /// <returns></returns>
        public async Task<Airport> UpdateAirportAsync(Airport Airport)
        {
            try
            {
                var productExist = dbContext.Airport.FirstOrDefault(p => p.Id == Airport.Id);
                if (productExist != null)
                {
                    dbContext.Update(Airport);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Airport;
        }
        /// <summary>
        /// This method removes and existing product from the DbContext and saves it
        /// </summary>
        /// <param name="Airport"></param>
        /// <returns></returns>
        public async Task DeleteAirportAsync(Airport Airport)
        {
            try
            {
                dbContext.Airport.Remove(Airport);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
