using YoutubeBlog.Entity.DTOs.Portfolios;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IPortfolioService
    {
        Task<List<PortfolioDto>> GetAllPortfoliosWithCategoryNonDeletedAsync();
        Task<List<PortfolioDto>> GetAllPortfoliosWithCategoryDeletedAsync();
        Task<PortfolioDto> GetPortfolioWithCategoryNonDeletedAsync(string portfolioSlug);
        Task CreatePortfolioAsync(PortfolioAddDto portfolioAddDto);
        Task<string> UpdatePortfolioAsync(PortfolioUpdateDto portfolioUpdateDto);
        Task<string> SafeDeletePortfolioAsync(string portfolioTitle);
        Task<string> UndoDeletePortfolioAsync(string portfolioTitle);
        Task<List<PortfolioDto>> GetRandomPortfoliosAsync(int count);
        Task<PortfolioListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 12,
            bool isAscending = false);
        Task<string> HardDeletePortfolioAsync(string portfolioTitle);


    }
}
