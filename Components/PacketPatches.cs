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
        private static bool ProcImpl(Packet __instance)
        {
            Log.Info($"Packet procImpl: {__instance.query.URL}");

            return true;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserData), "proc")]
        private static bool PacketGetUserDataProc(ref Packet.State __result, PacketGetUserData __instance)
        {
            Log.Info($"PacketGetUserData proc");

            UserManager instance = Singleton<UserManager>.instance;
            GetUserData query = __instance.query as GetUserData;

            if (FileSystem.Configuration.FileExists("UserData.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserDataResponse>("UserData.json");
            }
            else
            {
                query.response_ = GetUserDataResponse.create();
                query.response_.userData.trophyId = GameDefaultID.TrophyID.getValue();
                FileSystem.Configuration.SaveJson("UserData.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            instance.userDetail.copyFrom(query.response_.userData);
            instance.userDetail.setBpRank(query.response_.bpRank);

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserMusicItem), "proc")]
        private static bool PacketGetUserMusicItemProc(ref Packet.State __result, PacketGetUserMusicItem __instance)
        {
            Log.Info($"PacketGetUserMusicItem proc");

            GetUserMusicItem query = __instance.query as GetUserMusicItem;

            if (FileSystem.Configuration.FileExists("MusicItemData.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserMusicItemResponse>("MusicItemData.json");
            }
            else
            {
                query.response_ = GetUserMusicItemResponse.create();
                FileSystem.Configuration.SaveJson("MusicItemData.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserMusic), "proc")]
        private static bool PacketGetUserMusicProc(ref Packet.State __result, PacketGetUserMusic __instance)
        {
            Log.Info($"PacketGetUserMusic proc");

            GetUserMusic query = __instance.query as GetUserMusic;

            if (FileSystem.Configuration.FileExists("MusicData.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserMusicResponse>("MusicData.json");
            }
            else
            {
                query.response_ = GetUserMusicResponse.create();
                FileSystem.Configuration.SaveJson("MusicData.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserCard), "proc")]
        private static bool PacketGetUserCardProc(ref Packet.State __result, PacketGetUserCard __instance)
        {
            Log.Info($"PacketGetUserCard proc");

            GetUserCard query = __instance.query as GetUserCard;

            if (FileSystem.Configuration.FileExists("UserCard.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserCardResponse>("UserCard.json");
            }
            else
            {
                query.response_ = GetUserCardResponse.create();
                FileSystem.Configuration.SaveJson("UserCard.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserCharacter), "proc")]
        private static bool PacketGetUserCharacterProc(ref Packet.State __result, PacketGetUserCharacter __instance)
        {
            Log.Info($"PacketGetUserCharacter proc");

            GetUserCharacter query = __instance.query as GetUserCharacter;

            if (FileSystem.Configuration.FileExists("UserCharacter.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserCharacterResponse>("UserCharacter.json");
            }
            else
            {
                query.response_ = GetUserCharacterResponse.create();
                FileSystem.Configuration.SaveJson("UserCharacter.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserStory), "proc")]
        private static bool PacketGetUserStoryProc(ref Packet.State __result, PacketGetUserStory __instance)
        {
            Log.Info($"PacketGetUserStory proc");

            GetUserStory query = __instance.query as GetUserStory;

            if (FileSystem.Configuration.FileExists("UserStory.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserStoryResponse>("UserStory.json");
            }
            else
            {
                query.response_ = GetUserStoryResponse.create();
                FileSystem.Configuration.SaveJson("UserStory.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserChapter), "proc")]
        private static bool PacketGetUserChapterProc(ref Packet.State __result, PacketGetUserChapter __instance)
        {
            Log.Info($"PacketGetUserChapter proc");

            GetUserChapter query = __instance.query as GetUserChapter;

            if (FileSystem.Configuration.FileExists("UserChapter.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserChapterResponse>("UserChapter.json");
            }
            else
            {
                query.response_ = GetUserChapterResponse.create();
                FileSystem.Configuration.SaveJson("UserChapter.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserDeckByKey), "proc")]
        private static bool PacketGetUserDeckByKeyProc(ref Packet.State __result, PacketGetUserDeckByKey __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserDeckByKey proc");

            GetUserDeckByKey query = __instance.query as GetUserDeckByKey;

            if (FileSystem.Configuration.FileExists("UserDeckByKey.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserDeckByKeyResponse>("UserDeckByKey.json");
            }
            else
            {
                query.response_ = GetUserDeckByKeyResponse.create();
                FileSystem.Configuration.SaveJson("UserDeckByKey.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserTrainingRoomByKey), "proc")]
        private static bool PacketGetUserTrainingRoomByKeyProc(ref Packet.State __result, PacketGetUserTrainingRoomByKey __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserTrainingRoomByKey proc");

            GetUserTrainingRoomByKey query = __instance.query as GetUserTrainingRoomByKey;

            if (FileSystem.Configuration.FileExists("UserTrainingRoomByKey.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserTrainingRoomByKeyResponse>("UserTrainingRoomByKey.json");
            }
            else
            {
                query.response_ = GetUserTrainingRoomByKeyResponse.create();
                FileSystem.Configuration.SaveJson("UserTrainingRoomByKey.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserOption), "proc")]
        private static bool PacketGetUserOptionProc(ref Packet.State __result, PacketGetUserOption __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserOption proc");

            GetUserOption query = __instance.query as GetUserOption;

            if (FileSystem.Configuration.FileExists("UserOption.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserOptionResponse>("UserOption.json");
            }
            else
            {
                query.response_ = GetUserOptionResponse.create();
                FileSystem.Configuration.SaveJson("UserOption.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserActivityMusic), "proc")]
        private static bool PacketGetUserActivityMusicProc(ref Packet.State __result, PacketGetUserActivityMusic __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserActivityMusic proc");

            GetUserActivity query = __instance.query as GetUserActivity;

            if (FileSystem.Configuration.FileExists("UserActivityMusic.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserActivityResponse>("UserActivityMusic.json");
            }
            else
            {
                query.response_ = GetUserActivityResponse.create();
                FileSystem.Configuration.SaveJson("UserActivityMusic.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserActivityPlay), "proc")]
        private static bool PacketGetUserActivityPlayProc(ref Packet.State __result, PacketGetUserActivityPlay __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserActivityPlay proc");

            GetUserActivity query = __instance.query as GetUserActivity;

            if (FileSystem.Configuration.FileExists("UserActivityPlay.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserActivityResponse>("UserActivityPlay.json");
            }
            else
            {
                query.response_ = GetUserActivityResponse.create();
                FileSystem.Configuration.SaveJson("UserActivityPlay.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserRatinglog), "proc")]
        private static bool PacketGetUserRatinglogProc(ref Packet.State __result, PacketGetUserRatinglog __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserRatinglog proc");

            GetUserRatinglog query = __instance.query as GetUserRatinglog;

            if (FileSystem.Configuration.FileExists("UserRatingLog.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserRatinglogResponse>("UserRatingLog.json");
            }
            else
            {
                query.response_ = GetUserRatinglogResponse.create();
                FileSystem.Configuration.SaveJson("UserRatingLog.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserRecentRating), "proc")]
        private static bool PacketGetUserRecentRatingProc(ref Packet.State __result, PacketGetUserRecentRating __instance)
        {
            Log.Info($"PacketGetUserRecentRating proc");

            GetUserRecentRating query = __instance.query as GetUserRecentRating;

            if (FileSystem.Configuration.FileExists("UserRecentRating.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserRecentRatingResponse>("UserRecentRating.json");
            }
            else
            {
                query.response_ = GetUserRecentRatingResponse.create();
                FileSystem.Configuration.SaveJson("UserRecentRating.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
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
        private static bool PacketGetUserItemProc(ref Packet.State __result, PacketGetUserItem __instance)
        {
            Log.Info($"PacketGetUserItem proc");

            GetUserItem query = __instance.query as GetUserItem;

            string itemKind = UserItemKind(__instance).ToString();

            if (userItemFS.FileExists($"{itemKind}.json"))
            {
                query.response_ = userItemFS.LoadJson<GetUserItemResponse>($"{itemKind}.json");
            }
            else
            {
                query.response_ = GetUserItemResponse.create();
                userItemFS.SaveJson($"{itemKind}.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserEventPoint), "proc")]
        private static bool PacketGetUserEventPointProc(ref Packet.State __result, PacketGetUserEventPoint __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserEventPoint proc");

            GetUserEventPoint query = __instance.query as GetUserEventPoint;

            if (FileSystem.Configuration.FileExists("UserEventPoint.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserEventPointResponse>("UserEventPoint.json");
            }
            else
            {
                query.response_ = GetUserEventPointResponse.create();
                FileSystem.Configuration.SaveJson("UserEventPoint.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserEventRanking), "proc")]
        private static bool PacketGetUserEventRankingProc(ref Packet.State __result, PacketGetUserEventRanking __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserEventRanking proc");

            GetUserEventRanking query = __instance.query as GetUserEventRanking;

            if (FileSystem.Configuration.FileExists("UserEventRanking.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserEventRankingResponse>("UserEventRanking.json");
            }
            else
            {
                query.response_ = GetUserEventRankingResponse.create();
                FileSystem.Configuration.SaveJson("UserEventRanking.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserMissionPoint), "proc")]
        private static bool PacketGetUserMissionPointProc(ref Packet.State __result, PacketGetUserMissionPoint __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserMissionPoint proc");

            GetUserMissionPoint query = __instance.query as GetUserMissionPoint;

            if (FileSystem.Configuration.FileExists("UserMissionPoint.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserMissionPointResponse>("UserMissionPoint.json");
            }
            else
            {
                query.response_ = GetUserMissionPointResponse.create();
                FileSystem.Configuration.SaveJson("UserMissionPoint.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserLoginBonus), "proc")]
        private static bool PacketGetUserLoginBonusProc(ref Packet.State __result, PacketGetUserLoginBonus __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserLoginBonus proc");

            GetUserLoginBonus query = __instance.query as GetUserLoginBonus;

            if (FileSystem.Configuration.FileExists("UserLoginBonus.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserLoginBonusResponse>("UserLoginBonus.json");
            }
            else
            {
                query.response_ = GetUserLoginBonusResponse.create();
                FileSystem.Configuration.SaveJson("UserLoginBonus.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserRegion), "proc")]
        private static bool PacketGetUserRegionProc(ref Packet.State __result, PacketGetUserRegion __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserRegion proc");

            GetUserRegion query = __instance.query as GetUserRegion;

            if (FileSystem.Configuration.FileExists("UserRegion.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserRegionResponse>("UserRegion.json");
            }
            else
            {
                query.response_ = GetUserRegionResponse.create();
                FileSystem.Configuration.SaveJson("UserRegion.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserBpBase), "proc")]
        private static bool PacketGetUserBpBaseProc(ref Packet.State __result, PacketGetUserBpBase __instance)
        {
            // TODO: check what needs doing here?
            Log.Info($"PacketGetUserBpBase proc");

            GetUserBpBase query = __instance.query as GetUserBpBase;

            if (FileSystem.Configuration.FileExists("UserBpBase.json"))
            {
                query.response_ = FileSystem.Configuration.LoadJson<GetUserBpBaseResponse>("UserBpBase.json");
            }
            else
            {
                query.response_ = GetUserBpBaseResponse.create();
                FileSystem.Configuration.SaveJson("UserBpBase.json", query.response_);
            }

            query.response_.userId = Singleton<UserManager>.instance.UserId;

            __result = Packet.State.Done;

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGameLogin), "proc")]
        private static bool PacketGameLoginProc(ref Packet.State __result, PacketGameLogin __instance)
        {
            Log.Info($"PacketGameLoginProc proc");

            Singleton<UserManager>.instance.startLockExtention();

            __result = Packet.State.Done;
            (__instance.query as GameLogin).response_ = new GameLoginResponse()
            {
                returnCode = 1
            };

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserPreview), "proc")]
        private static bool PacketGetUserPreviewProc(ref Packet.State __result)
        {
            Log.Info($"PacketGetUserPreview proc");

            __result = Packet.State.Done;

            return false;
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
                if (FileSystem.Configuration.FileExists("UserData.json"))
                {
                    GetUserDataResponse temporary = FileSystem.Configuration.LoadJson<GetUserDataResponse>("UserData.json");

                    temporary.userData = array[0];
                    temporary.userId = Singleton<UserManager>.instance.UserId;
                    temporary.bpRank = (int)UserUtil.calcBpRank(Singleton<UserManager>.instance.BattlePoint);

                    FileSystem.Configuration.SaveJson("UserData.json", temporary);
                }
            }

            void UpdateUserOption(MU3.Client.UserOption[] array)
            {
                string fileName = "UserOption.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserOptionResponse temporary = FileSystem.Configuration.LoadJson<GetUserOptionResponse>(fileName);

                    temporary.userOption = array[0];
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserActivity()
            {
                UserManager instance = Singleton<UserManager>.instance;

                void UpdateForType(string fileName, List<MU3.User.UserActivity> array)
                {
                    if (FileSystem.Configuration.FileExists(fileName))
                    {
                        GetUserActivityResponse temporary = FileSystem.Configuration.LoadJson<GetUserActivityResponse>(fileName);

                        foreach (var item in array)
                        {
                            MU3.Client.UserActivity item2 = new MU3.Client.UserActivity();
                            item.copyTo(item2);
                            
                            temporary.userActivityList = new[] { item2 }
                                .Concat(temporary.userActivityList)
                                .ToArray();
                        }

                        temporary.length = temporary.userActivityList.Length;
                        temporary.userId = Singleton<UserManager>.instance.UserId;

                        FileSystem.Configuration.SaveJson(fileName, temporary);
                    }
                }

                UpdateForType("UserActivityMusic.json", instance.userActivityMusic);
                UpdateForType("UserActivityPlay.json", instance.userActivityPlay);
            }

            void UpdateUserRecentRating(MU3.Client.UserRecentRating[] array)
            {
                string fileName = "UserRecentRating.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserRecentRatingResponse temporary = FileSystem.Configuration.LoadJson<GetUserRecentRatingResponse>(fileName);

                    foreach (var item in array)
                    {
                        temporary.userRecentRatingList = new[] { item }
                            .Concat(temporary.userRecentRatingList)
                            .ToArray();
                    }

                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserBattleScore(MU3.Client.UserBpBase[] array)
            {
                string fileName = "UserBpBase.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserBpBaseResponse temporary = FileSystem.Configuration.LoadJson<GetUserBpBaseResponse>(fileName);

                    foreach (var item in array)
                    {
                        temporary.userBpBaseList = new[] { item }
                            .Concat(temporary.userBpBaseList)
                            .ToArray();
                    }

                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserCharacter(MU3.Client.UserCharacter[] array)
            {
                string fileName = "UserCharacter.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserCharacterResponse temporary = FileSystem.Configuration.LoadJson<GetUserCharacterResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userCharacterList = temporary.userCharacterList
                            .Where(a => a.characterId != item.characterId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userCharacterList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserCard(MU3.Client.UserCard[] array)
            {
                string fileName = "UserCard.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserCardResponse temporary = FileSystem.Configuration.LoadJson<GetUserCardResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userCardList = temporary.userCardList
                            .Where(a => a.cardId != item.cardId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userCardList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserDeck(MU3.Client.UserDeck[] array)
            {
                string fileName = "UserDeck.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserDeckByKeyResponse temporary = FileSystem.Configuration.LoadJson<GetUserDeckByKeyResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userDeckList = temporary.userDeckList
                            .Where(a => a.deckId != item.deckId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userDeckList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserTrainingRoom(MU3.Client.UserTrainingRoom[] array)
            {
                string fileName = "UserTrainingRoom.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserTrainingRoomByKeyResponse temporary = FileSystem.Configuration.LoadJson<GetUserTrainingRoomByKeyResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userTrainingRoomList = temporary.userTrainingRoomList
                            .Where(a => a.roomId != item.roomId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userTrainingRoomList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserChapter(MU3.Client.UserChapter[] array)
            {
                string fileName = "UserChapter.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserChapterResponse temporary = FileSystem.Configuration.LoadJson<GetUserChapterResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userChapterList = temporary.userChapterList
                            .Where(a => a.chapterId != item.chapterId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userChapterList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserMusicItem(MU3.Client.UserMusicItem[] array)
            {
                string fileName = "UserMusicItem.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserMusicItemResponse temporary = FileSystem.Configuration.LoadJson<GetUserMusicItemResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userMusicItemList = temporary.userMusicItemList
                            .Where(a => a.musicId != item.musicId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userMusicItemList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserLoginBonus(MU3.Client.UserLoginBonus[] array)
            {
                string fileName = "UserLoginBonus.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserLoginBonusResponse temporary = FileSystem.Configuration.LoadJson<GetUserLoginBonusResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userLoginBonusList = temporary.userLoginBonusList
                            .Where(a => a.bonusId != item.bonusId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userLoginBonusList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserEventPoint(MU3.Client.UserEventPoint[] array)
            {
                string fileName = "UserEventPoint.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserEventPointResponse temporary = FileSystem.Configuration.LoadJson<GetUserEventPointResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userEventPointList = temporary.userEventPointList
                            .Where(a => a.eventId != item.eventId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userEventPointList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserMissionPoint(MU3.Client.UserMissionPoint[] array)
            {
                string fileName = "UserMissionPoint.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserMissionPointResponse temporary = FileSystem.Configuration.LoadJson<GetUserMissionPointResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userMissionPointList = temporary.userMissionPointList
                            .Where(a => a.eventId != item.eventId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userMissionPointList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateUserRatingLog(MU3.Client.UserRatinglog[] array)
            {
                string fileName = "UserRatingLog.json";

                if (FileSystem.Configuration.FileExists(fileName))
                {
                    GetUserRatinglogResponse temporary = FileSystem.Configuration.LoadJson<GetUserRatinglogResponse>(fileName);

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userRatinglogList = temporary.userRatinglogList
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userRatinglogList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson(fileName, temporary);
                }
            }

            void UpdateItems(UserItem[] array)
            {
                void UpdateForType(ItemType itemType, string file)
                {
                    if (userItemFS.FileExists(file))
                    {
                        GetUserItemResponse temporary = userItemFS.LoadJson<GetUserItemResponse>(file);

                        foreach (var item in array.Where(a => a.itemKind == (int)itemType))
                        {
                            // remove existing item and add new one
                            temporary.userItemList = temporary.userItemList
                                .Where(a => a.itemId != item.itemId)
                                .Concat(new[] { item })
                                .ToArray();
                        }

                        temporary.length = temporary.userItemList.Length;
                        temporary.userId = Singleton<UserManager>.instance.UserId;

                        userItemFS.SaveJson(file, temporary);
                    }
                }

                UpdateForType(ItemType.Trophy, "Trophy.json");
                UpdateForType(ItemType.GachaTicket, "GachaTicket.json");
                UpdateForType(ItemType.LimitBreakItem, "LimitBreakItem.json");
                UpdateForType(ItemType.NamePlate, "NamePlate.json");
                UpdateForType(ItemType.Present, "Present.json");
                UpdateForType(ItemType.ProfileVoice, "ProfileVoice.json");
            }

            void UpdateStory(MU3.Client.UserStory[] array)
            {
                if (FileSystem.Configuration.FileExists("UserStory.json"))
                {
                    GetUserStoryResponse temporary = FileSystem.Configuration.LoadJson<GetUserStoryResponse>("UserStory.json");

                    foreach (var item in array)
                    {
                        // remove existing item and add new one
                        temporary.userStoryList = temporary.userStoryList
                            .Where(a => a.storyId != item.storyId)
                            .Concat(new[] { item })
                            .ToArray();
                    }

                    temporary.length = temporary.userStoryList.Length;
                    temporary.userId = Singleton<UserManager>.instance.UserId;

                    FileSystem.Configuration.SaveJson("UserStory.json", temporary);
                }
            }

            var upsert = query.request_.upsertUserAll;

            UpdateUserData(upsert.userData);
            UpdateUserOption(upsert.userOption);
            UpdateUserActivity();
            UpdateUserRecentRating(upsert.userRecentRatingList);
            UpdateUserBattleScore(upsert.userBpBaseList);
            // what the even does this do
            //UpdateUserMusicDetail(upsert.userMusicDetailList);
            UpdateUserCharacter(upsert.userCharacterList);
            UpdateUserCard(upsert.userCardList);
            UpdateUserDeck(upsert.userDeckList);
            UpdateUserTrainingRoom(upsert.userTrainingRoomList);
            if (upsert.isNewStoryList.Contains("1")) UpdateStory(upsert.userStoryList);
            UpdateUserChapter(upsert.userChapterList);
            if (upsert.isNewItemList.Contains("1")) UpdateItems(upsert.userItemList);
            UpdateUserMusicItem(upsert.userMusicItemList);
            UpdateUserLoginBonus(upsert.userLoginBonusList);
            UpdateUserEventPoint(upsert.userEventPointList);
            if (upsert.isNewMissionPointList.Contains("1")) UpdateUserMissionPoint(upsert.userMissionPointList);
            UpdateUserRatingLog(upsert.userRatinglogList);

            typeof(PacketUpsertUserAll).GetMethod("clearFlags", (BindingFlags)62).Invoke(__instance, null);

            if (UserManager.Exists)
            {
                Singleton<UserManager>.instance.updateLastRemainedGP();
            }

            __result = Packet.State.Done;
            (__instance.query as UpsertUserAll).response_ = new UpsertUserAllResponse()
            {
                returnCode = 1
            };

            return false;
        }

        [MethodPatch(PatchType.Prefix, typeof(PacketGetUserPreview), "get_Response")]
        private static bool UserPreviewResponsePatch(ref GetUserPreviewResponse __result)
        {
            Log.Info($"PacketGetUserPreview Response");

            __result = GetUserPreviewResponse.create();

            if (FileSystem.Configuration.FileExists("UserPrev.json"))
            {
                __result = FileSystem.Configuration.LoadJson<GetUserPreviewResponse>("UserPrev.json");
            }
            else
            {
                __result.userId = 1337u;
                __result.isLogin = false;
                __result.lastLoginDate = DateTime.Now.ToString();
                __result.userName = Environment.UserName;
                __result.reincarnationNum = 1;
                __result.level = 1;
                __result.exp = 0;
                __result.playerRating = 0;
                __result.lastGameId = "";
                __result.lastRomVersion = Singleton<MU3.Sys.System>.instance.config.romVersionInfo.versionNo.versionString;
                __result.lastDataVersion = Singleton<MU3.Sys.System>.instance.config.dataVersionInfo.versionNo.versionString;
                __result.lastPlayDate = DateTime.Now.ToString();
                __result.trophyId = GameDefaultID.TrophyID.getValue();

                FileSystem.Configuration.SaveJson("UserPrev.json", __result);
            }

            return false;
        }
    }
}
