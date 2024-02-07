﻿using DefeatYourOpponent.Domain.Entities.Commons;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IGameResultRepository
    {
        public Task<List<GameResultEntity>> GetGameResultEntitiesAsync(string summonerName, Dictionary<string, string> tags);
    }
}