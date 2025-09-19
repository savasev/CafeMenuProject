using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Core.Entities;
using CafeMenuProject.DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMenuProject.Business.Concrete
{
    /// <summary>
    /// Property service
    /// </summary>
    public class PropertyService : IPropertyService
    {
        #region Fields

        private readonly IRepository<Property> _propertyRepository;

        #endregion

        #region Ctor

        public PropertyService(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        #endregion

        #region Methods

        public async Task DeletePropertyAsync(Property property)
        {
            await _propertyRepository.DeleteAsync(property);
        }

        public async Task<IList<Property>> GetAllPropertysAsync()
        {
            return await _propertyRepository.GetAllAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetByIdAsync(id);
        }

        public async Task InsertPropertyAsync(Property property)
        {
            await _propertyRepository.InsertAsync(property);
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            await _propertyRepository.UpdateAsync(property);
        }

        #endregion
    }
}
