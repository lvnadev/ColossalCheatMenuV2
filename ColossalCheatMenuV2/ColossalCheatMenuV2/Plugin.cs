using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Colossal.Menu.ClientHub;
using Colossal.Menu.ClientHub.Notifacation;
using Colossal.Mods;
using ColossalCheatMenuV2.Menu;
using ColossalOnevent;
using Photon.Pun;
using PlayFab;
using UnityEngine;
using UnityEngine.UI;
using static Valve.VR.SteamVR_ExternalCamera;

namespace Colossal {
    //[BepInPlugin("org.ColossusYTTV.ColossalCheatMenuV2", "ColossalCheatMenuV2", "1.0.0")]
    public class Plugin : MonoBehaviour {
        //public static int called = 0;
        //public static float instantate = 0;

        public static float reporttimer = 0;


        public static GameObject hud;
        public static GameObject holder;

        public static float version = 5.2f;
        public static bool sussy = false;

        public void Start()
        {
            Debug.Log("[COLOSSAL] Plugin Start Call");


            AutoUpdate();


            Debug.Log("[COLOSSAL] Spawned Holder");
            holder = new GameObject();
            holder.name = "Holder";
            holder.AddComponent<Boards>();
            holder.AddComponent<EventNotifacation>();
            holder.AddComponent<JoinNotifacation>();
            holder.AddComponent<LeaveNotifacation>();
            holder.AddComponent<MasterChangeNotifacation>();
            holder.AddComponent<Configs>();


            Menu.Menu.LoadOnce();
            CustomConsole.LogToConsole("[COLOSSAL] Loaded menu start functions");

            CustomConsole.LogToConsole("[COLOSSAL] Getting configs");
            Configs.GetConfigFileNames();

            hud = GameObject.Find("CLIENT_HUB");
        }
        public void Update() {
            Menu.Menu.Load();
            Dictionary<Type, bool> componentConditions = new Dictionary<Type, bool>
            {
                { typeof(CustomConsole), true },
                { typeof(ThisGuyIsUsingColossal), true },
                { typeof(LongArm), PluginConfig.longarms },
                { typeof(WhyIsEveryoneLookingAtMe), PluginConfig.whyiseveryonelookingatme },
                { typeof(ExcelFly), PluginConfig.excelfly },
                { typeof(WateryAir), PluginConfig.wateryair },
                { typeof(FreezeMonkey), PluginConfig.freezemonkey },
                { typeof(Platforms), PluginConfig.platforms },
                { typeof(TFly), PluginConfig.tfly },
                { typeof(UpsideDownMonkey), PluginConfig.upsidedownmonkey },
                { typeof(Chams), PluginConfig.chams },
                { typeof(HollowBoxEsp), PluginConfig.hollowboxesp },
                { typeof(BoxEsp), PluginConfig.boxesp },
                { typeof(CreeperMonkey), PluginConfig.creepermonkey },
                { typeof(GhostMonkey), PluginConfig.ghostmonkey },
                { typeof(InvisMonkey), PluginConfig.invismonkey },
                { typeof(LegMod), PluginConfig.legmod },
                { typeof(TagGun), PluginConfig.taggun },
                { typeof(TagAll), PluginConfig.tagall },
                { typeof(BreakModChecker), PluginConfig.breakmodcheckers },
                { typeof(BreakNameTags), PluginConfig.breaknametags },
                { typeof(SpinBot), PluginConfig.SpinBot },
                { typeof(Desync), PluginConfig.desync },
                { typeof(FakeQuestMenu), PluginConfig.fakequestmenu },

            };
            foreach (var kvp in componentConditions)
            {
                if(holder != null)
                {
                    if (kvp.Value && holder.GetComponent(kvp.Key) == null)
                    {
                        holder.AddComponent(kvp.Key);
                    }
                } else
                {
                    Debug.Log("Holder is null");
                }
            }
        }

        public void AutoUpdate()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(directoryPath, "*ColossalCheatMenu*.dll", SearchOption.AllDirectories);

            if (files.Length > 0)
            {
                string filePath = files[0];
                CustomConsole.LogToConsole($"[COLOSSAL] Found CCM: {filePath}");

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string rawData = client.GetStringAsync("https://raw.githubusercontent.com/ColossusYTTV/ColossalCheatMenuV2/main/AutoUpdate/version.txt").Result;
                        CustomConsole.LogToConsole($"[COLOSSAL] Current version on server: {rawData}");
                        CustomConsole.LogToConsole($"[COLOSSAL] Current version on Local: {version}");

                        float serverVersion;
                        if (float.TryParse(rawData, out serverVersion))
                        {
                            if (version < serverVersion)
                            {
                                CustomConsole.LogToConsole("[COLOSSAL] Local is on an old update. Will Update on restart...");

                                string serverFileUrl = "https://github.com/ColossusYTTV/ColossalCheatMenuV2/raw/main/AutoUpdate/ColossalCheatMenuV2.dll";
                                string tempFilePath = Path.GetTempFileName();

                                using (WebClient webClient = new WebClient())
                                {
                                    try
                                    {
                                        webClient.DownloadFile(serverFileUrl, tempFilePath);
                                        CustomConsole.LogToConsole("[COLOSSAL] Downloaded new CCM version.");

                                        File.Delete(filePath);
                                        CustomConsole.LogToConsole("[COLOSSAL] Deleted old menu dll.");

                                        File.Move(tempFilePath, filePath);
                                        CustomConsole.LogToConsole("[COLOSSAL] Moved new menu dll into place.");
                                    }
                                    catch (WebException ex)
                                    {
                                        CustomConsole.LogToConsole($"[COLOSSAL] Error downloading file: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                CustomConsole.LogToConsole("[COLOSSAL] Local is up-to-date!");
                            }
                        }
                        else
                        {
                            CustomConsole.LogToConsole("[COLOSSAL] Failed to parse server version.");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        CustomConsole.LogToConsole("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                CustomConsole.LogToConsole("[COLOSSAL] No matching file found.");
            }
        }


        /*public void FixedUpdate() {
            if (PhotonNetwork.InRoom) {
                instantate += Time.deltaTime;
            } else {
                instantate = 0;
                called = 0;
            }

            if (instantate >= 120) {
                called = 0;
            }
        }*/
    }
}