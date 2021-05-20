using System;
using System.Linq;
using KycManager.Models;

namespace KycManager.TenantRepository
{
    public class TenantProvider : ITenantProvider
    {
        KycDbContext _context;

        public TenantProvider (KycDbContext context)
        {
            _context = context;
        }

        public Tenant GetTenant(string TenantId)
        {
            Guid Id = Guid.Parse(TenantId);
            return _context.Tenants.Find(Id);
        }

    }
}
