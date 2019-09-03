using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ITalksRepository
    {
        Talks CreateATalk(Talks talks);
        Talks UpdateATalk(Talks talks);
        Talks GetTalksById(int id);
        IEnumerable<Talks> GetAllTalks();
        void DeleteATalk(Talks talks);
        bool IsUnique(string name);
    }



    public class TalksRepository:ITalksRepository
    {

        private readonly ConferenceContext conferenceContext;

        public TalksRepository(ConferenceContext conferenceContext)
        {
            this.conferenceContext = conferenceContext;
        }

        public IEnumerable<Talks> GetAllTalks()
        {
            return conferenceContext.Talks.ToList();
        }

        public Talks GetTalksById(int id)
        {
            return conferenceContext.Talks.Find(id);
        }

        public Talks CreateATalk(Talks talks)
        {
            var createATalk = conferenceContext.Talks.Add(talks);
            conferenceContext.SaveChanges();
            return createATalk.Entity;
        }

        public Talks UpdateATalk(Talks talks)
        {
            var updateATalk = conferenceContext.Talks.Update(talks);
            conferenceContext.SaveChanges();
            return updateATalk.Entity;
        }

        public void DeleteATalk(Talks talks)
        {
            var deleteATalk = conferenceContext.Talks.Remove(talks);
            conferenceContext.SaveChanges();

        }

        public bool IsUnique(string name)
        {
            var isUnique = conferenceContext.Talks.Count(x => x.Name == name);
            if (isUnique == 0)
            {
                return true;
            }
            return false;
        }

    }
}
