using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ISpeakersRepository
    {
        IEnumerable<Speakers> GetEditions();
        Speakers GetById(int id);
        Speakers CreateSpeakers(Speakers editions);
        Speakers Update(Speakers editions);

        Speakers Delete(Speakers editions);

        bool IsUnique(string name);



    }


    public class SpeakersRepository : ISpeakersRepository
    {

        private ConferenceContext conferenceContext;


        public SpeakersRepository(ConferenceContext context)
        {
            this.conferenceContext = context;
        }

        public IEnumerable<Speakers> GetEditions()
        {
            return conferenceContext.Speakers.ToList();
        }

        public Speakers GetById(int id)
        {
            var getById = conferenceContext.Speakers.Find(id);
            return getById;
        }

        public Speakers CreateSpeakers(Speakers speakers)
        {
            var create = conferenceContext.Speakers.Add(speakers);
            conferenceContext.SaveChanges();
            return create.Entity;
        }

        public Speakers Update(Speakers speakers)
        {
            var up = conferenceContext.Speakers.Update(speakers);
            conferenceContext.SaveChanges();
            return up.Entity;
        }

        public Speakers Delete(Speakers speakers)
        {
            var del = conferenceContext.Speakers.Remove(speakers);
            conferenceContext.SaveChanges();
            return null;
        }

        public bool IsUnique(string name)
        {
            var unique = conferenceContext.Speakers.Count(x => x.CompanyName == name);

            if (unique == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
