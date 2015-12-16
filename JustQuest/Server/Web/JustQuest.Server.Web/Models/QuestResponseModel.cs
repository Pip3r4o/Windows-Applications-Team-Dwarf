namespace JustQuest.Server.Web.Models
{
    using System.Collections.Generic;
    using AutoMapper;
    using Contracts;
    using Data.Models;

    public class QuestResponseModel : IMapFrom<Quest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Task { get; set; }

        public int PointsAward { get; set; }

        // TODO: DECIDE WHETHER ANSWER VALIDATION WILL HAPPEN ON SERVER OR CLIENT
        public ICollection<string> PossibleAnswers { get; set; }

        public ICollection<HintResponseModel> Hints { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Quest, QuestResponseModel>()
                .ForMember(ad => ad.PointsAward,
                    opts =>
                        opts.MapFrom(
                            ad =>
                                ad.NumberOfRemainingCorrectGuesses == 3
                                    ? 100
                                    : ad.NumberOfRemainingCorrectGuesses == 2 ? 50 : 20));

        }
    }
}