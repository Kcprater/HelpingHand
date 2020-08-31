using HelpingHand.Data;
using HelpingHand.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Services
{
    public class ServiceService
    {
        private readonly Guid _ID;
        public ServiceService(Guid Id)
        {
            _ID = Id;
        }
        public bool CreateService(ServiceCreate model)
        {
            var service = new Service()
            {
                ID = _ID,
                ProviderID = model.ProviderID,
                Category = model.Category,
                Experience = model.Experience,
                Rate = model.Rate,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Services.Add(service);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ServiceListItem> GetServices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var serviceQuery = ctx.Services.Where(e => e.ID == _ID).Select(e => new ServiceListItem
                {
                    ServiceID = e.ServiceID,
                    ProviderID = e.ProviderID,
                    Category = e.Category,
                    Experience = e.Experience,
                    Rate = e.Rate,
                }
                );
                return serviceQuery.ToArray();
            }
        }
        public ServiceDetail GetServiceById(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var service = ctx.Services.Single(e => e.ServiceID == serviceId);
                return new ServiceDetail
                {
                    ServiceID = service.ServiceID,
                    ProviderID = service.ProviderID,
                    ID = service.ID,
                    Category = service.Category,
                    Experience = service.Experience,
                    Rate = service.Rate,
                };
            }
        }
        public bool UpdateService(ServiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var service = ctx.Services.Single(e => e.ServiceID == model.ServiceID && e.ID == _ID);
                service.Category = model.Category;
                service.Experience = model.Experience;
                service.Rate = model.Rate;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool ServiceDelete(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var service = ctx.Services.Single(e => e.ServiceID == serviceId && e.ID == _ID);
                ctx.Services.Remove(service);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
