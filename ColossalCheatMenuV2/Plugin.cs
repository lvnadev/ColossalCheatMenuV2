using Colossal.Menu.ClientHub.Notifacation;
using Colossal.Menu.ClientHub;
using Colossal.Menu;
using Colossal.Mods;
using Colossal.Patches;
using ColossalCheatMenuV2.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Colossal
{
    public class Plugin : MonoBehaviour
    {
        public static GameObject holder;
        public static Font gtagfont;

        public const float version = 5.8f;

        public static bool oculus =  false;
        public static bool sussy = false;

        public static float playtime;
        public static string playtimestring;

        private void Start()
        {
            CustomConsole.LogToConsole("[COLOSSAL] Plugin Start Call");

            AutoUpdate();

            CustomConsole.LogToConsole("[COLOSSAL] Spawned Holder");
            holder = new GameObject("Holder");
            holder.AddComponent<Boards>();
            holder.AddComponent<EventNotifacation>();
            holder.AddComponent<JoinNotifacation>();
            holder.AddComponent<LeaveNotifacation>();
            holder.AddComponent<MasterChangeNotifacation>();
            holder.AddComponent<Configs>();
            holder.AddComponent<Controls>();
            holder.AddComponent<GUICreator>();

            oculus = Directory.GetFiles(Environment.CurrentDirectory, "OculusXRPlugin.dll", SearchOption.AllDirectories).Length > 0;

            gtagfont = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text")?.GetComponent<Text>().font;

            if (gtagfont != null && holder != null)
            {
                Menu.Menu.LoadOnce();
                CustomConsole.LogToConsole("[COLOSSAL] Loaded menu start");

                Overlay.SpawnOverlay();
                CustomConsole.LogToConsole("[COLOSSAL] Loaded overlay");

                Notifacations.SpawnNoti();
                CustomConsole.LogToConsole("[COLOSSAL] Loaded noti");
            }
        }

        private void Update()
        {
            Menu.Menu.Load();

            Dictionary<Type, bool> componentConditions = new Dictionary<Type, bool>
            {
                { typeof(CustomConsole), true },
                { typeof(ThisGuyIsUsingColossal), true },
                { typeof(LongArm), PluginConfig.longarms },
                // ... (other entries omitted for brevity)
            };

            foreach (var kvp in componentConditions)
            {
                if (holder != null)
                {
                    if (kvp.Value && holder.GetComponent(kvp.Key) == null)
                    {
                        holder.AddComponent(kvp.Key);
                    }
                }
                else
                {
                    CustomConsole.LogToConsole("[COLOSSAL] Holder is null");
                    holder = new GameObject("Holder");
                }
            }

            // Playtime counter
            playtime += Time.deltaTime;

            int hours = (int)(playtime / 3600);
            int minutes = (int)((playtime % 3600) / 60);
            int seconds = (int)(playtime % 60);

            playtimestring = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void AutoUpdate()
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
                        string rawDataVersion = client.GetStringAsync("https://raw.githubusercontent.com/ColossusYTTV/ColossalCheatMenuV2/main/AutoUpdate/version.txt").Result;
                        CustomConsole.LogToConsole($"[COLOSSAL] Current version on server: {rawDataVersion}");
                        CustomConsole.LogToConsole($"[COLOSSAL] Current version on Local: {version}");

                        if (float.TryParse(rawDataVersion, out float serverVersion) && version < serverVersion)
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
                    catch (HttpRequestException ex)
                    {
                        CustomConsole.LogToConsole($"Error: {ex.Message}");
                    }
                }
            }
            else
            {
                CustomConsole.LogToConsole("[COLOSSAL] No matching file found.");
            }
        }
    }
}