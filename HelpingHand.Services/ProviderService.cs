using HelpingHand.Data;
using HelpingHand.Models.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Services
{
    public class ProviderService
    {
        private readonly Guid _ID;
        public ProviderService(Guid Id)
        {
            _ID = Id;
        }
        public bool CreateProvider(ProviderCreate model)
        {
            var provider = new Provider()
            {
                ID = _ID,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                City = model.City,
                State = model.State
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Providers.Add(provider);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProviderListItem> GetProviders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var providerQuery = ctx.Providers.Where(e => e.ID == _ID).Select(e => new ProviderListItem
                {
                    ProviderID = e.ProviderID,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    City = e.City,
                    State = e.State
                }
                );
                return providerQuery.ToArray();
            }
        }
        public ProviderDetail GetProviderById(int providerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var provider = ctx.Providers.Single(e => e.ProviderID == providerId);
                return new ProviderDetail
                {
                    ProviderID = provider.ProviderID,
                    ID = provider.ID,
                    Name = provider.Name,
                    Email = provider.Email,
                    Phone = provider.Phone,
                    City = provider.City,
                    State = provider.State
                };
            }
        }
        public bool UpdateProvider(ProviderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var provider = ctx.Providers.Single(e => e.ProviderID == model.ProviderID && e.ID == _ID);
                provider.Name = model.Name;
                provider.Email = model.Email;
                provider.Phone = model.Phone;
                provider.City = model.City;
                provider.State = model.State;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool ProviderDelete(int providerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var provider = ctx.Providers.Single(e => e.ProviderID == providerId && e.ID == _ID);
                ctx.Providers.Remove(provider);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}