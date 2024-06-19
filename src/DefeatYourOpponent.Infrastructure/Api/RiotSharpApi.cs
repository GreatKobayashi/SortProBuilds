﻿//using DefeatYourOpponent.Domain;
//using DefeatYourOpponent.Domain.Entities;
//using DefeatYourOpponent.Domain.Entities.Commons;
//using DefeatYourOpponent.Domain.Exceptions;
//using DefeatYourOpponent.Domain.Logics;
//using DefeatYourOpponent.Domain.Repositories;
//using RiotSharp.Misc;
//using System.Net.Http.Json;

//namespace DefeatYourOpponent.Infrastructure.WebApi
//{
//    public class RiotSharpWebApi : IApiRepository, ITimeLineRepository
//    {
//        private HttpClient _httpClient;

//        public RiotSharpWebApi()
//        {
//            _httpClient = new HttpClient()
//            {
//                BaseAddress = new Uri(Shared.SettingEntity.RiotControllerSetting.BaseUrl)
//            };
//        }

//        public async Task<List<GameResultEntity>> GetGameResultEntitiesAsync(
//            Region region, string summonerName, TagEntity tags, int count)
//        {
//            var requestBody = new RiotApiGetGameResultRequestBody(region, summonerName, tags, count);

//            HttpResponseMessage response;
//            try
//            {
//                response = await _httpClient.PostAsJsonAsync(
//                    Shared.SettingEntity.RiotControllerSetting.GetGameResultsUrl, requestBody);
//            }
//            catch (Exception ex)
//            {
//                throw new InternalException("サーバー接続失敗", ex);
//            }

//            return ResponseConverter.Convert<List<GameResultEntity>>(response);
//        }

//        public async Task<GameDetailEntity> GetGameDetailAsync(Region region, string matchId, int targetId, int opponentId)
//        {
//            HttpResponseMessage response;
//            try
//            {
//                response = await _httpClient.GetAsync(
//                    Shared.SettingEntity.RiotControllerSetting.CreateGameDetailUrlQuery(region, matchId, targetId, opponentId));
//            }
//            catch (Exception ex)
//            {
//                throw new InternalException("サーバー接続失敗", ex);
//            }

//            return ResponseConverter.Convert<GameDetailEntity>(response);
//        }
//    }
//}
