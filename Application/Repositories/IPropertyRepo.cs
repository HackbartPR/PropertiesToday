using Domain;

namespace Application.Repositories;

public interface IPropertyRepo
{
    Task AddNewAsync(Property property);
    Task UpdateAsync(Property property);
    Task DeleteAsync(int id);
    Task<Property> GetByIdAsync(int id);
    Task<List<Property>> GetAllAsync();
}
