using Conference.Data;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Service
{
    public interface ITalksService
    {

        IEnumerable<Talks> GetAllTalks();
        Talks GetTalksById(int id);
        Talks CreateATalk(Talks talks);
        Talks UpdateATalk(Talks talks);
        void DeleteATalk(Talks talks);
        bool IsUnique(string name);

    }


    public class TalksService : ITalksService
    {

        private readonly ITalksRepository talksRepository;


        public TalksService(ITalksRepository talksRepository)
        {
            this.talksRepository = talksRepository;
        }

        public IEnumerable<Talks> GetAllTalks()
        {
            return talksRepository.GetAllTalks().ToList();
        }

        public Talks GetTalksById(int id)
        {
            return talksRepository.GetTalksById(id);
        }

        public Talks CreateATalk(Talks talks)
        {
            if (IsUnique(talks.Name)){
                return talksRepository.CreateATalk(talks);
            }
            return null;
        }

        public Talks UpdateATalk(Talks talks)
        {
            var updateATalk = talksRepository.UpdateATalk(talks);
            return updateATalk;
        }

        public void DeleteATalk(Talks talks)
        {
            talksRepository.DeleteATalk(talks);

        }

        public bool IsUnique(string name)
        {


            if (talksRepository.IsUnique(name) == true)
            {
                return true;
            }
            return false;
        }

    }
}
