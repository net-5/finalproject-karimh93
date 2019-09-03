
using Conference.Data;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Service
{
    public interface IEditionService
    {


        IEnumerable<Editions> GetEditions();
        Editions GetById(int id);
        Editions CreateEdition(Editions editions);
        Editions Update(Editions editions);

        void DeleteEdition(Editions editions);

        bool Isunique(string name);
    }


    public class EditionService : IEditionService
    {

        private IEditionRepository editionRepository;

        public EditionService(IEditionRepository editionRepository)
        {
            this.editionRepository = editionRepository;
        }

        public IEnumerable<Editions> GetEditions()
        {
            return editionRepository.GetEditions();
        }

        public Editions GetById(int id)
        {
            var getById = editionRepository.GetById(id);
            return getById;
        }

        public Editions CreateEdition(Editions editions)
        {

            if (Isunique(editions.Name))
            {
                return editionRepository.CreateEdition(editions);
            }
            return null;
    }

        public Editions Update(Editions editions)
        {
            var up = editionRepository.Update(editions);
            return up;
        }

        public void DeleteEdition(Editions editions)
        {
            editionRepository.Delete(editions);
            
        }

        public bool Isunique(string name)
        {
            return editionRepository.IsUnique(name);
        }
    }
}
