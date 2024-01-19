namespace CountrySearcher.Domain.Interfaces.Repository
{
    public interface IRepositoryManager
    {
        ICountryRepository CountryRepository { get; }
        Task SaveAsync();
    }
}
