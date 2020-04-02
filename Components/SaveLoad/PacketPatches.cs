using Harmony;
using MU3.AM;
using MU3.Client;
using MU3.DataStudio;
using MU3.DB;
using MU3.User;
using MU3.Util;
using NekoClient.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

/* why are fuckin weebs so bad at game */
/* sega y u do it like dis */
namespace UnityParrot.Components
{
    class PacketPatches : MonoBehaviour
    {
        void Start()
        {
            Harmony.PatchAllInType(typeof(PacketPatches));
        }

        [MethodPatch(PatchType.Prefix, typeof(Packet), "procImpl")]
        private static bool ProcImpl(ref Packet.State __result, Packet __instance, ref Packet.State ___state_)
        {
            Log.Info($"Packet procImpl: {__instance.query.URL}");
            ___state_ = Packet.State.Done;
            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserData), "proc")]
        private static bool PacketGetUserDataProc(ref Packet.State __result, ref PacketGetUserData __instance)
        {
            Log.Info($"PacketGetUserData proc");

            GetUserData query = __instance.query as GetUserData;

            if (!FileSystem.Configuration.FileExists("UserData.json"))
            {
                query.response_ = GetUserDataResponse.create();
                query.response_.userData.trophyId = GameDefaultID.TrophyID.getValue();
                query.response_.userId = Singleton<UserManager>.instance.UserId;
                FileSystem.Configuration.SaveJson("UserData.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserDataResponse>("UserData.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserPreview), "proc")]
        private static bool PacketGetUserPreviewGetResponse(ref Packet.State __result, ref PacketGetUserPreview __instance)
        {
            Log.Info($"PacketGetUserPreview proc");

            GetUserPreview query = __instance.query as GetUserPreview;

            if (!FileSystem.Configuration.FileExists("UserPrev.json"))
            {
                query.response_ = GetUserPreviewResponse.create();
                query.response_.trophyId = GameDefaultID.TrophyID.getValue();
                query.response_.userId = Singleton<UserManager>.instance.UserId;
                FileSystem.Configuration.SaveJson("UserPrev.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserPreviewResponse>("UserPrev.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserMusicItem), "proc")]
        private static bool PacketGetUserMusicItemProc(ref Packet.State __result, ref PacketGetUserMusicItem __instance)
        {
            Log.Info($"PacketGetUserMusicItem proc");

            GetUserMusicItem query = __instance.query as GetUserMusicItem;

            if (!FileSystem.Configuration.FileExists("UserMusicItem.json"))
            {
                query.response_ = GetUserMusicItemResponse.create();
                FileSystem.Configuration.SaveJson("UserMusicItem.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserMusicItemResponse>("UserMusicItem.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserMusic), "proc")]
        private static bool PacketGetUserMusicProc(ref Packet.State __result, ref PacketGetUserMusic __instance)
        {
            Log.Info($"PacketGetUserMusic proc");

            GetUserMusic query = __instance.query as GetUserMusic;

            if (!FileSystem.Configuration.FileExists("UserMusic.json"))
            {
                query.response_ = GetUserMusicResponse.create();
                FileSystem.Configuration.SaveJson("UserMusic.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserMusicResponse>("UserMusic.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserCard), "proc")]
        private static bool PacketGetUserCardProc(ref Packet.State __result, ref PacketGetUserCard __instance)
        {
            Log.Info($"PacketGetUserCard proc");

            GetUserCard query = __instance.query as GetUserCard;

            if (!FileSystem.Configuration.FileExists("UserCard.json"))
            {
                query.response_ = GetUserCardResponse.create();
                FileSystem.Configuration.SaveJson("UserCard.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserCardResponse>("UserCard.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserCharacter), "proc")]
        private static bool PacketGetUserCharacterProc(ref Packet.State __result, ref PacketGetUserCharacter __instance)
        {
            Log.Info($"PacketGetUserCharacter proc");

            GetUserCharacter query = __instance.query as GetUserCharacter;

            if (!FileSystem.Configuration.FileExists("UserCharacter.json"))
            {
                query.response_ = GetUserCharacterResponse.create();
                FileSystem.Configuration.SaveJson("UserCharacter.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserCharacterResponse>("UserCharacter.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserStory), "proc")]
        private static bool PacketGetUserStoryProc(ref Packet.State __result, ref PacketGetUserStory __instance)
        {
            Log.Info($"PacketGetUserStory proc");

            GetUserStory query = __instance.query as GetUserStory;

            if (!FileSystem.Configuration.FileExists("UserStory.json"))
            {
                query.response_ = GetUserStoryResponse.create();
                FileSystem.Configuration.SaveJson("UserStory.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserStoryResponse>("UserStory.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserChapter), "proc")]
        private static bool PacketGetUserChapterProc(ref Packet.State __result, ref PacketGetUserChapter __instance)
        {
            Log.Info($"PacketGetUserChapter proc");

            GetUserChapter query = __instance.query as GetUserChapter;

            if (!FileSystem.Configuration.FileExists("UserChapter.json"))
            {
                query.response_ = GetUserChapterResponse.create();
                FileSystem.Configuration.SaveJson("UserChapter.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserChapterResponse>("UserChapter.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserDeckByKey), "proc")]
        private static bool PacketGetUserDeckByKeyProc(ref Packet.State __result, ref PacketGetUserDeckByKey __instance)
        {
            Log.Info($"PacketGetUserDeckByKey proc");

            GetUserDeckByKey query = __instance.query as GetUserDeckByKey;

            if (!FileSystem.Configuration.FileExists("UserDeckByKey.json"))
            {
                query.response_ = GetUserDeckByKeyResponse.create();
                FileSystem.Configuration.SaveJson("UserDeckByKey.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserDeckByKeyResponse>("UserDeckByKey.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserTrainingRoomByKey), "proc")]
        private static bool PacketGetUserTrainingRoomByKeyProc(ref Packet.State __result, ref PacketGetUserTrainingRoomByKey __instance)
        {
            Log.Info($"PacketGetUserTrainingRoomByKey proc");

            GetUserTrainingRoomByKey query = __instance.query as GetUserTrainingRoomByKey;

            if (!FileSystem.Configuration.FileExists("UserTrainingRoomByKey.json"))
            {
                query.response_ = GetUserTrainingRoomByKeyResponse.create();
                FileSystem.Configuration.SaveJson("UserTrainingRoomByKey.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserTrainingRoomByKeyResponse>("UserTrainingRoomByKey.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserOption), "proc")]
        private static bool PacketGetUserOptionProc(ref Packet.State __result, ref PacketGetUserOption __instance)
        {
            Log.Info($"PacketGetUserOption proc");

            GetUserOption query = __instance.query as GetUserOption;

            if (!FileSystem.Configuration.FileExists("UserOption.json"))
            {
                query.response_ = GetUserOptionResponse.create();
                FileSystem.Configuration.SaveJson("UserOption.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserOptionResponse>("UserOption.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserActivityMusic), "proc")]
        private static bool PacketGetUserActivityMusicProc(ref Packet.State __result, ref PacketGetUserActivityMusic __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserActivityMusic proc");

            GetUserActivity query = __instance.query as GetUserActivity;

            if (!FileSystem.Configuration.FileExists("UserActivityMusic.json"))
            {
                query.response_ = GetUserActivityResponse.create();
                FileSystem.Configuration.SaveJson("UserActivityMusic.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserActivityResponse>("UserActivityMusic.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserActivityPlay), "proc")]
        private static bool PacketGetUserActivityPlayProc(ref Packet.State __result, ref PacketGetUserActivityPlay __instance)
        {
            Log.Info($"PacketGetUserActivityPlay proc");

            GetUserActivity query = __instance.query as GetUserActivity;

            if (!FileSystem.Configuration.FileExists("UserActivityPlay.json"))
            {
                query.response_ = GetUserActivityResponse.create();
                FileSystem.Configuration.SaveJson("UserActivityPlay.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserActivityResponse>("UserActivityPlay.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserRatinglog), "proc")]
        private static bool PacketGetUserRatinglogProc(ref Packet.State __result, ref PacketGetUserRatinglog __instance)
        {
            Log.Info($"PacketGetUserRatinglog proc");

            GetUserRatinglog query = __instance.query as GetUserRatinglog;

            if (!FileSystem.Configuration.FileExists("UserRatingLog.json"))
            {
                query.response_ = GetUserRatinglogResponse.create();
                FileSystem.Configuration.SaveJson("UserRatingLog.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserRatinglogResponse>("UserRatingLog.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserRecentRating), "proc")]
        private static bool PacketGetUserRecentRatingProc(ref Packet.State __result, ref PacketGetUserRecentRating __instance)
        {
            Log.Info($"PacketGetUserRecentRating proc");

            GetUserRecentRating query = __instance.query as GetUserRecentRating;

            if (!FileSystem.Configuration.FileExists("UserRecentRating.json"))
            {
                query.response_ = GetUserRecentRatingResponse.create();
                FileSystem.Configuration.SaveJson("UserRecentRating.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserRecentRatingResponse>("UserRecentRating.json");
            return true;
        }

        static FileSystem userItemFS = new FileSystem("UnityParrot\\Configuration\\UserItem");
        static FieldInfo userItemKind;

        static ItemType UserItemKind(PacketGetUserItem instance)
        {
            if (userItemKind == null)
            {
                userItemKind = typeof(PacketGetUserItem).GetField("_itemKind", (BindingFlags)62);
            }

            return (ItemType)userItemKind.GetValue(instance);
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserItem), "proc")]
        private static bool PacketGetUserItemProc(ref Packet.State __result, PacketGetUserItem __instance, ItemType ____itemKind)
        {
            Log.Info($"PacketGetUserItem proc");

            GetUserItem query = __instance.query as GetUserItem;

            string itemKindStr = ____itemKind.ToString();
            if (!userItemFS.FileExists($"{itemKindStr}.json"))
            {
                query.response_ = GetUserItemResponse.create();
                userItemFS.SaveJson($"{itemKindStr}.json", query.response_);
            }

            query.response_ = userItemFS.LoadJson<GetUserItemResponse>($"{itemKindStr}.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserEventPoint), "proc")]
        private static bool PacketGetUserEventPointProc(ref Packet.State __result, ref PacketGetUserEventPoint __instance)
        {
            Log.Info($"PacketGetUserEventPoint proc");

            GetUserEventPoint query = __instance.query as GetUserEventPoint;

            if (!FileSystem.Configuration.FileExists("UserEventPoint.json"))
            {
                query.response_ = GetUserEventPointResponse.create();
                FileSystem.Configuration.SaveJson("UserEventPoint.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserEventPointResponse>("UserEventPoint.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserEventRanking), "proc")]
        private static bool PacketGetUserEventRankingProc(ref Packet.State __result, ref PacketGetUserEventRanking __instance)
        {
            Log.Info($"PacketGetUserEventRanking proc");

            GetUserEventRanking query = __instance.query as GetUserEventRanking;

            if (!FileSystem.Configuration.FileExists("UserEventRanking.json"))
            {
                query.response_ = GetUserEventRankingResponse.create();
                FileSystem.Configuration.SaveJson("UserEventRanking.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserEventRankingResponse>("UserEventRanking.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserMissionPoint), "proc")]
        private static bool PacketGetUserMissionPointProc(ref Packet.State __result, ref PacketGetUserMissionPoint __instance)
        {
            Log.Info($"PacketGetUserMissionPoint proc");

            GetUserMissionPoint query = __instance.query as GetUserMissionPoint;

            if (!FileSystem.Configuration.FileExists("UserMissionPoint.json"))
            {
                query.response_ = GetUserMissionPointResponse.create();
                FileSystem.Configuration.SaveJson("UserMissionPoint.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserMissionPointResponse>("UserMissionPoint.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserLoginBonus), "proc")]
        private static bool PacketGetUserLoginBonusProc(ref Packet.State __result, ref PacketGetUserLoginBonus __instance)
        {
            Log.Info($"PacketGetUserLoginBonus proc");

            GetUserLoginBonus query = __instance.query as GetUserLoginBonus;

            if (!FileSystem.Configuration.FileExists("UserLoginBonus.json"))
            {
                query.response_ = GetUserLoginBonusResponse.create();
                FileSystem.Configuration.SaveJson("UserLoginBonus.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserLoginBonusResponse>("UserLoginBonus.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserRegion), "proc")]
        private static bool PacketGetUserRegionProc(ref Packet.State __result, ref PacketGetUserRegion __instance)
        {
            Log.Info($"PacketGetUserRegion proc");

            GetUserRegion query = __instance.query as GetUserRegion;

            if (!FileSystem.Configuration.FileExists("UserRegion.json"))
            {
                query.response_ = GetUserRegionResponse.create();
                FileSystem.Configuration.SaveJson("UserRegion.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserRegionResponse>("UserRegion.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserBpBase), "proc")]
        private static bool PacketGetUserBpBaseProc(ref Packet.State __result, ref PacketGetUserBpBase __instance)
        {
            Log.Info($"PacketGetUserBpBase proc");

            GetUserBpBase query = __instance.query as GetUserBpBase;

            if (!FileSystem.Configuration.FileExists("UserBpBase.json"))
            {
                query.response_ = GetUserBpBaseResponse.create();
                FileSystem.Configuration.SaveJson("UserBpBase.json", query.response_);
            }

            query.response_ = FileSystem.Configuration.LoadJson<GetUserBpBaseResponse>("UserBpBase.json");
            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGameLogin), "proc")]
        private static bool PacketGameLoginProc(ref Packet.State __result, PacketGameLogin __instance)
        {
            Log.Info($"PacketGameLoginProc proc");

            (__instance.query as GameLogin).response_ = new GameLoginResponse()
            {
                returnCode = 1
            };

            return true;
        }

        [MethodPatch(PatchType.Transpiler, typeof(MU3.Scene_39_Logout), "Upsert_Init")]
        private static IEnumerable<CodeInstruction> UpsertInitTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);

            codes.RemoveRange(0, 10);

            return codes.AsEnumerable();
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketUpsertUserAll), "proc")]
        private static bool PacketUpsertUserAllProc(ref Packet.State __result, PacketUpsertUserAll __instance)
        {
            Log.Info($"!!!!! SAVING !!!!!");

            UpsertUserAll query = __instance.query as UpsertUserAll;

            void UpdateUserData(UserData[] array)
            {
                GetUserDataResponse temporary = new GetUserDataResponse();
                temporary.userData = array[0];
                temporary.userId = Singleton<UserManager>.instance.UserId;
                temporary.bpRank = (int)UserUtil.calcBpRank(Singleton<UserManager>.instance.BattlePoint);
                FileSystem.Configuration.SaveJson("UserData.json", temporary);

                GetUserPreviewResponse temporary1 = new GetUserPreviewResponse();
                temporary1.userId = temporary.userId;
                temporary1.isLogin = false;
                temporary1.lastLoginDate = temporary.userData.lastPlayDate;
                temporary1.userName = temporary.userData.userName;
                temporary1.reincarnationNum = temporary.userData.reincarnationNum;
                temporary1.level = temporary.userData.level;
                temporary1.exp = temporary.userData.exp;
                temporary1.playerRating = temporary.userData.playerRating;
                temporary1.lastGameId = temporary.userData.lastGameId;
                temporary1.lastRomVersion = temporary.userData.lastRomVersion;
                temporary1.lastDataVersion = temporary.userData.lastDataVersion;
                temporary1.lastPlayDate = temporary.userData.lastPlayDate;
                temporary1.nameplateId = temporary.userData.nameplateId;
                temporary1.trophyId = temporary.userData.trophyId;
                temporary1.cardId = temporary.userData.cardId;
                temporary1.dispPlayerLv = 1;
                temporary1.dispRating = 1;
                temporary1.dispBP = 1;
                temporary1.headphone = 0;
                FileSystem.Configuration.SaveJson("UserPrev.json", temporary1);
            }

            void UpdateUserOption(MU3.Client.UserOption[] array)
            {
                GetUserOptionResponse temporary = GetUserOptionResponse.create();
                temporary.userOption = array[0];
                temporary.userId = Singleton<UserManager>.instance.UserId;
                FileSystem.Configuration.SaveJson("UserOption.json", temporary);
            }

            void UpdateUserActivity()
            {
                void UpdateForType(string fileName, List<MU3.User.UserActivity> array, UserActivityConst.Kind kind)
                {
                    GetUserActivityResponse temporary = new GetUserActivityResponse();
                    List<MU3.Client.UserActivity> userActivityList = new List<MU3.Client.UserActivity>();
                    foreach (var item in array)
                    {
                        MU3.Client.UserActivity activity = new MU3.Client.UserActivity();
                        item.copyTo(activity);
                        userActivityList.Add(activity);
                    }

                    temporary.userActivityList = userActivityList.ToArray();
                    temporary.length = temporary.userActivityList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;
                    temporary.kind = (int) kind;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }

                UserManager instance = Singleton<UserManager>.instance;
                UpdateForType("UserActivityMusic.json", instance.userActivityMusic, UserActivityConst.Kind.Music);
                UpdateForType("UserActivityPlay.json", instance.userActivityPlay, UserActivityConst.Kind.PlayActivity);
            }

            void UpdateUserRecentRating(MU3.Client.UserRecentRating[] array)
            {
                string fileName = "UserRecentRating.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserRecentRatingResponse recentRating = GetUserRecentRatingResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, recentRating);
                }

                GetUserRecentRatingResponse temporary = FileSystem.Configuration.LoadJson<GetUserRecentRatingResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userRecentRatingList = new[] { item }
                        .Concat(temporary.userRecentRatingList)
                        .ToArray();
                }

                temporary.userId = Singleton<UserManager>.instance.UserId;
                temporary.length = temporary.userRecentRatingList.Length;
                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserBpBase(MU3.Client.UserBpBase[] array)
            {
                string fileName = "UserBpBase.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserBpBaseResponse bpBase = GetUserBpBaseResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, bpBase);
                }

                GetUserBpBaseResponse temporary = FileSystem.Configuration.LoadJson<GetUserBpBaseResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userBpBaseList = new[] { item }
                        .Concat(temporary.userBpBaseList)
                        .ToArray();
                }

                temporary.length = temporary.userBpBaseList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;
                FileSystem.Configuration.SaveJson("UserBpBase.json", temporary);
            }


            void UpdateUserCharacter(MU3.Client.UserCharacter[] array)
            {
                string fileName = "UserCharacter.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserCharacterResponse userCharacter = GetUserCharacterResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userCharacter);
                }

                GetUserCharacterResponse temporary = FileSystem.Configuration.LoadJson<GetUserCharacterResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userCharacterList = temporary.userCharacterList
                        .Where(a => a.characterId != item.characterId)
                        .Concat(new[] { item })
                        .ToArray();
                }

                temporary.length = temporary.userCharacterList.Length;
                temporary.nextIndex = 0;
                temporary.userId = Singleton<UserManager>.instance.UserId;
                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserCard(MU3.Client.UserCard[] array)
            {
                string fileName = "UserCard.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserCardResponse userCard = GetUserCardResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userCard);
                }

                GetUserCardResponse temporary = FileSystem.Configuration.LoadJson<GetUserCardResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userCardList = temporary.userCardList
                        .Where(a => a.cardId != item.cardId)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userCardList.Length;
                temporary.nextIndex = 0;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserDeck(MU3.Client.UserDeck[] array)
            {
                string fileName = "UserDeckByKey.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserDeckByKeyResponse userDeckByKey = GetUserDeckByKeyResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userDeckByKey);
                }

                GetUserDeckByKeyResponse temporary = FileSystem.Configuration.LoadJson<GetUserDeckByKeyResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userDeckList = temporary.userDeckList
                        .Where(a => a.deckId != item.deckId)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userDeckList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserTrainingRoom(MU3.Client.UserTrainingRoom[] array)
            {
                string fileName = "UserTrainingRoomByKey.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserTrainingRoomByKeyResponse userTrainingRoom = GetUserTrainingRoomByKeyResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userTrainingRoom);
                }

                GetUserTrainingRoomByKeyResponse temporary = FileSystem.Configuration.LoadJson<GetUserTrainingRoomByKeyResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userTrainingRoomList = temporary.userTrainingRoomList
                        .Where(a => a.roomId != item.roomId)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userTrainingRoomList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson("UserTrainingRoom.json", temporary);
            }

            void UpdateUserStory(MU3.Client.UserStory[] array)
            {
                string fileName = "UserStory.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserStoryResponse userStory = GetUserStoryResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userStory);
                }

                GetUserStoryResponse temporary = FileSystem.Configuration.LoadJson<GetUserStoryResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userStoryList = temporary.userStoryList
                        .Where(a => a.storyId != item.storyId)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userStoryList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserChapter(MU3.Client.UserChapter[] array)
            {
                string fileName = "UserChapter.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserChapterResponse userChapter = GetUserChapterResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userChapter);
                }

                GetUserChapterResponse temporary = FileSystem.Configuration.LoadJson<GetUserChapterResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userChapterList = new[] { item }
                        .Concat(temporary.userChapterList)
                        .ToArray();
                }
                temporary.length = temporary.userChapterList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserItem(UserItem[] array)
            {
                void UpdateForType(string fileName, ItemType itemType)
                {
                    if (!userItemFS.FileExists(fileName))
                    {
                        GetUserItemResponse userItemList = GetUserItemResponse.create();
                        userItemFS.SaveJson(fileName, userItemList);
                    }

                    GetUserItemResponse temporary = userItemFS.LoadJson<GetUserItemResponse>(fileName);
                    foreach (var item in array.Where(a => a.itemKind == (int)itemType))
                    {
                        temporary.userItemList = temporary.userItemList
                            .Where(a => a.itemId != item.itemId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userItemList.Length;
                    temporary.itemKind = (int)itemType;
                    temporary.nextIndex = 0;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    userItemFS.SaveJson(fileName, temporary);
                }

                UpdateForType("Trophy.json", ItemType.Trophy);
                UpdateForType("GachaTicket.json", ItemType.GachaTicket);
                UpdateForType("LimitBreakItem.json", ItemType.LimitBreakItem);
                UpdateForType("NamePlate.json", ItemType.NamePlate);
                UpdateForType("Present.json", ItemType.Present);
                UpdateForType("ProfileVoice.json", ItemType.ProfileVoice);
            }

            void UpdateUserMusicItem(MU3.Client.UserMusicItem[] array)
            {
                string fileName = "UserMusicItem.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserMusicItemResponse userMusicItemList = GetUserMusicItemResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userMusicItemList);
                }

                GetUserMusicItemResponse temporary = FileSystem.Configuration.LoadJson<GetUserMusicItemResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userMusicItemList = temporary.userMusicItemList
                        .Where(a => a.musicId != item.musicId)
                        .Concat(new[] { item })
                        .ToArray();
                }

                temporary.length = temporary.userMusicItemList.Length;
                temporary.nextIndex = 0;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserMusic(MU3.Client.UserMusicDetail[] array)
            {
                string fileName = "UserMusic.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserMusicResponse userMusicList = GetUserMusicResponse.create();
                    UserMusicDetail userMusicDetail = new UserMusicDetail();
                    userMusicList.length = 0;
                    FileSystem.Configuration.SaveJson(fileName, userMusicList);
                }

                GetUserMusicResponse temporary = FileSystem.Configuration.LoadJson<GetUserMusicResponse>(fileName);
                foreach (var item in array)
                {
                    bool addedItem = false;
                    foreach (var userMusic in temporary.userMusicList) {
                        if (userMusic.length != 0)
                        {
                            if (item.musicId == userMusic.userMusicDetailList[0].musicId)
                            {
                                userMusic.userMusicDetailList = userMusic.userMusicDetailList
                                    .Where(a => a.level != item.level)
                                    .Concat(new[] { item })
                                    .ToArray();
                                userMusic.length = userMusic.userMusicDetailList.Length;
                                addedItem = true;
                                break;
                            }
                        }
                    }

                    if (!addedItem)
                    {
                        MU3.Client.UserMusic userMusic = new MU3.Client.UserMusic();
                        userMusic.userMusicDetailList = userMusic.userMusicDetailList.Add(item).ToArray();
                        userMusic.length = userMusic.userMusicDetailList.Length;
                        temporary.userMusicList = temporary.userMusicList.Add(userMusic).ToArray();
                        temporary.length = temporary.userMusicList.Length;
                    }
                }

                temporary.nextIndex = 0;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserLoginBonus(MU3.Client.UserLoginBonus[] array)
            {
                string fileName = "UserLoginBonus.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserLoginBonusResponse userLoginBonus = GetUserLoginBonusResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userLoginBonus);
                }

                GetUserLoginBonusResponse temporary = FileSystem.Configuration.LoadJson<GetUserLoginBonusResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userLoginBonusList = temporary.userLoginBonusList
                        .Where(a => a.bonusId != item.bonusId)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userLoginBonusList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserEventPoint(MU3.Client.UserEventPoint[] array)
            {
                string fileName = "UserEventPoint.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserEventPointResponse userEventPoint = GetUserEventPointResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userEventPoint);
                }

                GetUserEventPointResponse temporary = FileSystem.Configuration.LoadJson<GetUserEventPointResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userEventPointList = temporary.userEventPointList
                        .Where(a => a.eventId != item.eventId)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userEventPointList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserMissionPoint(MU3.Client.UserMissionPoint[] array)
            {
                string fileName = "UserMissionPoint.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserMissionPointResponse userEventPoint = GetUserMissionPointResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userEventPoint);
                }

                GetUserMissionPointResponse temporary = FileSystem.Configuration.LoadJson<GetUserMissionPointResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userMissionPointList = temporary.userMissionPointList
                        .Where(a => a.eventId != item.eventId)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userMissionPointList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }

            void UpdateUserRatingLog(MU3.Client.UserRatinglog[] array)
            {
                string fileName = "UserRatingLog.json";
                if (!FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserRatinglogResponse userEventPoint = GetUserRatinglogResponse.create();
                    FileSystem.Configuration.SaveJson(fileName, userEventPoint);
                }

                GetUserRatinglogResponse temporary = FileSystem.Configuration.LoadJson<GetUserRatinglogResponse>(fileName);
                foreach (var item in array)
                {
                    temporary.userRatinglogList = temporary.userRatinglogList
                        .Where(a => a.highestRating != item.highestRating)
                        .Concat(new[] { item })
                        .ToArray();
                }
                temporary.length = temporary.userRatinglogList.Length;
                temporary.userId = Singleton<UserManager>.instance.UserId;

                FileSystem.Configuration.SaveJson(fileName, temporary);
            }


            if (query == null)
            {
                Log.Info("!!!!! No data to save. !!!!!");
                return false;
            }

            var upsert = query.request_.upsertUserAll;

            UpdateUserData(upsert.userData);
            UpdateUserOption(upsert.userOption);
            UpdateUserActivity();
            UpdateUserRecentRating(upsert.userRecentRatingList);
            UpdateUserBpBase(upsert.userBpBaseList);
            if (!string.IsNullOrEmpty(upsert.isNewMusicDetailList)) UpdateUserMusic(upsert.userMusicDetailList);
            if (!string.IsNullOrEmpty(upsert.isNewCharacterList)) UpdateUserCharacter(upsert.userCharacterList);
            if (!string.IsNullOrEmpty(upsert.isNewCardList)) UpdateUserCard(upsert.userCardList);
            if (!string.IsNullOrEmpty(upsert.isNewDeckList)) UpdateUserDeck(upsert.userDeckList);
            if (!string.IsNullOrEmpty(upsert.isNewTrainingRoomList)) UpdateUserTrainingRoom(upsert.userTrainingRoomList);
            if (!string.IsNullOrEmpty(upsert.isNewStoryList)) UpdateUserStory(upsert.userStoryList);
            if (!string.IsNullOrEmpty(upsert.isNewChapterList)) UpdateUserChapter(upsert.userChapterList);
            if (!string.IsNullOrEmpty(upsert.isNewItemList)) UpdateUserItem(upsert.userItemList);
            if (!string.IsNullOrEmpty(upsert.isNewMusicItemList)) UpdateUserMusicItem(upsert.userMusicItemList);
            if (!string.IsNullOrEmpty(upsert.isNewLoginBonusList)) UpdateUserLoginBonus(upsert.userLoginBonusList);
            if (!string.IsNullOrEmpty(upsert.isNewEventPointList)) UpdateUserEventPoint(upsert.userEventPointList);
            if (!string.IsNullOrEmpty(upsert.isNewMissionPointList)) UpdateUserMissionPoint(upsert.userMissionPointList);
            if (!string.IsNullOrEmpty(upsert.isNewRatinglogList)) UpdateUserRatingLog(upsert.userRatinglogList);
            if (UserManager.Exists)
            {
                Singleton<UserManager>.instance.updateLastRemainedGP();
            }
            typeof(PacketUpsertUserAll).GetMethod("clearFlags", (BindingFlags)62).Invoke(__instance, null);

            __result = Packet.State.Done;
            (__instance.query as UpsertUserAll).response_ = new UpsertUserAllResponse()
            {
                returnCode = 1
            };

            return false;
        }
    }
}
