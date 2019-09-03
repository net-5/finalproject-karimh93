
using Conference.Data;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Service
{
    public interface ISpeakerService
    {
        Speakers DeleteSpeaker(Speakers speakers);
        bool IsUnique(string name);
        Speakers Update(Speakers speakers);
        Speakers Create(Speakers speakers);
        Speakers GetById(int id);
        IEnumerable<Speakers> GetSpeakers();
    }

    public class SpeakerService:ISpeakerService
    {

        private ISpeakersRepository speakersRepository;

        public SpeakerService(ISpeakersRepository speakersRepository)
        {
            this.speakersRepository = speakersRepository;
        }

        public IEnumerable<Speakers> GetSpeakers()
        {
            return speakersRepository.GetEditions();
        }

        public Speakers GetById(int id)
        {
            var getById = speakersRepository.GetById(id);
            return getById;
        }

        public Speakers Create(Speakers speakers)
        {
            if (IsUnique(speakers.Email))
            {
                return speakersRepository.CreateSpeakers(speakers);
            }
            return null;
        }

        public Speakers Update(Speakers speakers)
        {
            var up = speakersRepository.Update(speakers);
            return up;

        }
        

        public bool IsUnique(string name) {

            return speakersRepository.IsUnique(name);

          }

        public Speakers DeleteSpeaker(Speakers speakers)
        {
            var del = speakersRepository.Delete(speakers);

            return null;
        }

    }
}
