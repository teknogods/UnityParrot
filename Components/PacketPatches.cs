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

                    FileSystem.Configuration.SaveJson("UserStory.json", temporary);
                }
            }

            UpdateItems(query.request_.upsertUserAll.userItemList);
            UpdateUserData(query.request_.upsertUserAll.userData);
            UpdateStory(query.request_.upsertUserAll.userStoryList);

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
