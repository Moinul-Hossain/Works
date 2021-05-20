using KycManager.Models;

namespace KycManager.TenantRepository
{
    public interface ITenantProvider
    {
        Tenant GetTenant(string TenantId);
    }
}
