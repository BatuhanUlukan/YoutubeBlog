using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class PortfolioVisitor : IEntityBase
    {
        public PortfolioVisitor() { }

        public PortfolioVisitor(Guid portfolioId, int visitorId)
        {
            PortfolioId = portfolioId;
            VisitorId = visitorId;
        }

        public Guid PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
    }
}
