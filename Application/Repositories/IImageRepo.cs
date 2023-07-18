using Domain;

namespace Application.Repositories;

public interface IImageRepo
{
    public Task AddNewAsync(Image image);
    public Task DeleteAsync(Image image);
    public Task UpdateAsync(Image image);
    public Task<Image> GetByAsync(int id);
    public Task<List<Image>> GetAllAsync();
}
