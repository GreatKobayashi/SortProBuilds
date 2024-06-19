﻿using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Exceptions;
using DefeatYourOpponent.Domain.Repositories;
using Reactive.Bindings;
using RiotApiWrapper.Entities;
using RiotApiWrapper.Entities.Match;
using RiotApiWrapper.Exceptions;
using RiotApiWrapper.Misc;

namespace DefeatYourOpponent.UI.ViewModel
{
    public class MatchIndexViewModel
    {
        private readonly IApiRepository _apiRepository;

        public ReactivePropertySlim<List<MatchEntity>> MatchList { get; private set; } = new();
        public ReactivePropertySlim<bool> IsLoading { get; private set; } = new();

        public MatchIndexViewModel(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
            IsLoading.Value = false;
        }

        public async Task GetMatchEntitiesByRiotIdAsync(
            Region region, string riotId, string tagLine, SerchTagEntity serchTag, int count)
        {
            MatchList.Value?.Clear();

            IsLoading.Value = true;

            try
            {
                MatchList.Value = await _apiRepository.GetMatchesAsync(region, riotId, tagLine, serchTag, count);

                var offset = count;
                while (MatchList.Value.Count < count)
                {
                    var shortageCount = count - MatchList.Value.Count;
                    var additional = await _apiRepository.GetMatchesAsync(region, riotId, tagLine, serchTag, shortageCount, offset);
                    var temp = new List<MatchEntity>(MatchList.Value);
                    temp.AddRange(additional);
                    MatchList.Value = temp;
                    offset += shortageCount;
                    if (offset > 50)
                    {
                        throw new InternalException("該当マッチ数不足");
                    }
                }
            }
            finally
            {
                IsLoading.Value = false;
            }
        }

        public ParticipantEntity GetOpponentEntity(MatchEntity match, ParticipantEntity target)
        {
            return match.Participants.First(x => x.Position == target.Position && x.Id != target.Id);
        }
    }
}