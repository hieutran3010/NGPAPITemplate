using EFPostgresEngagement.Abstract;

namespace Beke.AdminService
{
    public class ApplicationUserProvider: IDbTracker
    {
        public string GetAuthor()
        {
            return "System";
        }
    }
}