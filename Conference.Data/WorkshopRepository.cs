using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface IWorkShopRepository
    {
        IEnumerable<Workshops> GetAllWorkshops();
        Workshops GetWorkshopById(int id);
        Workshops CreateAWorkShop(Workshops workshops);
        void DeleteAWorkShop(Workshops workshops);
        Workshops UpdateAWorkShop(Workshops workshops);
        bool IsUnique(string name);
    }



    public class WorkShopRepository : IWorkShopRepository
    {
        private readonly ConferenceContext conferenceContext;

        public WorkShopRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;

        }

        public IEnumerable<Workshops> GetAllWorkshops()
        {
            return conferenceContext.Workshops.ToList();
        }

        public Workshops GetWorkshopById(int id)
        {
            return conferenceContext.Workshops.Find(id);
        }

        public Workshops CreateAWorkShop(Workshops workshops)
        {
            var createAWorkShop = conferenceContext.Workshops.Add(workshops);
            conferenceContext.SaveChanges();
            return createAWorkShop.Entity;
        }

        public Workshops UpdateAWorkShop(Workshops workshops)
        {
            var updateAWorkShop = conferenceContext.Workshops.Update(workshops);
            conferenceContext.SaveChanges();
            return updateAWorkShop.Entity;
        }

        public void DeleteAWorkShop(Workshops workshops)
        {
            conferenceContext.Workshops.Remove(workshops);
            conferenceContext.SaveChanges();

        }

        public bool IsUnique(string name)
        {
            var IsUnique = conferenceContext.Workshops.Count(x => x.Name == name);
            if (IsUnique == 0)
            {
            return true;
            }
            return false;
        }

    }
}
