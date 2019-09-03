using Conference.Data;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Service
{
    public interface IWorkShopService
    {
        IEnumerable<Workshops> GetAllWorkshops();
        Workshops GetWorkshopsById(int id);
        Workshops CreateAWorkshop(Workshops workshops);
        Workshops UpdateAWorkshop(Workshops workshops);
        void DeleteAWorkshop(Workshops workshops);
        bool IsUnique(string name);



    }



    public class WorkShopService : IWorkShopService
    {

        private readonly IWorkShopRepository workShopRepository;

        public WorkShopService(IWorkShopRepository workShopRepository)
        {
            this.workShopRepository = workShopRepository;
        }


        public IEnumerable<Workshops> GetAllWorkshops()
        {
            return workShopRepository.GetAllWorkshops();
        }

        public Workshops GetWorkshopsById(int id)
        {
            return workShopRepository.GetWorkshopById(id);
        }

        public Workshops CreateAWorkshop(Workshops workshops)
        {
            if (IsUnique(workshops.Name))
            {
                return workShopRepository.CreateAWorkShop(workshops);
            }
            return null;
        }

        public Workshops UpdateAWorkshop(Workshops workshops)
        {
            return workShopRepository.UpdateAWorkShop(workshops);
        }

        public void DeleteAWorkshop(Workshops workshops)
        {
            workShopRepository.DeleteAWorkShop(workshops);
        }

        public bool IsUnique(string name)
        {

            if (workShopRepository.IsUnique(name) == true)
            {

                return true;

            }

            return false;

        }
    }
}
