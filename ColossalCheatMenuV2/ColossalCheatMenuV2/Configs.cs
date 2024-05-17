using BepInEx;
using Colossal.Menu;
using Colossal.Menu.ClientHub;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Playables;
using static Valve.VR.SteamVR_ExternalCamera;
namespace Colossal.Menu
{
    public static class PluginConfig
    {
        public static bool excelfly = false;
        public static bool tfly = false;
        public static bool wallwalk = false;
        public static bool speed = false;
        public static bool speedlg = false;
        public static bool speedrg = false;
        public static bool nearspeed = false;
        public static bool platforms = false;
        public static bool upsidedownmonkey = false;
        public static bool wateryair = false;
        public static bool longarms = false;
        public static bool SpinBot = false;
        public static bool WASDFly = false;
        public static bool FloatyMonkey = false;
        public static bool Timer = false;
        public static bool ClimbableGorillas = false;
        public static bool NearPulse = false;
        public static bool PlayerScale = false;

        // Group 2
        public static bool chams = false;
        public static bool boxesp = false;
        public static bool hollowboxesp = false;
        public static bool whyiseveryonelookingatme = false;
        public static bool noexpressions = false;
        public static bool tracers = false;
        public static bool boneesp = false;
        public static bool firstperson = false;
        public static bool fullbright = false;

        // Group 3
        public static bool nofinger = false;
        public static bool taggun = false;
        public static bool legmod = false;
        public static bool creepermonkey = false;
        public static bool ghostmonkey = false;
        public static bool invismonkey = false;
        public static bool tagaura = false;
        public static bool tagall = false;
        public static bool freezemonkey = false;
        public static bool desync = false;
        public static bool hitboxes = false;

        // Group 4
        public static bool breaknametags = false;
        public static bool breakmodcheckers = false;
        public static bool pccheckbypass = false;
        public static bool fakequestmenu = false;

        //group 5
        public static bool Notifications = true;
        public static bool overlay = true;
        public static bool fullghostmode = false;
        public static bool tooltips = true;

        //group 6
        public static int MenuPosition = 0;
        public static int MenuColour = 0;
        public static int GhostColour = 0;
        public static int BeamColour = 0;
        public static int ESPColour = 0;
        public static int GhostOpacity = 2;
        public static int HitBoxesOpacity = 0;
        public static int HitBoxesColour = 0;

        public static int WASDFlySpeed = 2;
        public static int FloatMonkeyAmmount = 0;
        public static int TagAuraAmmount = 2;
        public static int WallWalkAmmount = 2;
        public static int TimerSpeed = 0;
        public static int FirstPersonFOV = 0;
        public static int ExcelFlySpeed = 0;
        public static int TracerPosition = 0;
        public static int TracerSize = 0;
        public static int hitboxesradius = 0;
        public static int speedammount = 0;
        public static int speedlgammount = 0;
        public static int speedrgammount = 0;
        public static int nearspeedammount = 0;
        public static int nearspeeddistance = 0;
        public static int NearPulseDistance = 0;
        public static int NearPulseAmmount = 0;
        public static int skycolour = 0;
    }

    internal class Configs : MonoBehaviour
    {
        public static string folderPath = "Colossal";
        public static string fileExtension = ".json";
        public static string fileName = "NewConfig";

        public static string[] GetConfigFileNames()
        {
            string[] result;
            try
            {
                CustomConsole.LogToConsole("[COLOSSAL] Getting Config Files");

                string[] files = Directory.GetFiles(Configs.folderPath, "*" + Configs.fileExtension);
                string[] array = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    array[i] = Path.GetFileNameWithoutExtension(files[i]);
                }
                result = array;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting config file names: " + ex.Message);
                result = new string[]
                {
                    "Error"
                };
            }
            return result;
        }

        public void Start()
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            else if (Directory.GetFiles(folderPath).Length == 0)
                SaveConfig();
        }
        public static void SaveConfig()
        {
            try
            {
                CustomConsole.LogToConsole("[COLOSSAL] Saving Config");

                string[] existingFiles = Directory.GetFiles(folderPath, "*" + fileExtension);
                int nextFileNumber = 1;
                while (existingFiles.Any(file => Path.GetFileNameWithoutExtension(file).EndsWith(nextFileNumber.ToString())))
                {
                    nextFileNumber++;
                }
                string newFileName = $"{fileName}_{nextFileNumber}{fileExtension}";
                string filePath = Path.Combine(folderPath, newFileName);

                var values = new Dictionary<string, object>();
                foreach (var prop in typeof(PluginConfig).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    values[prop.Name] = prop.GetValue(null);
                }
                string jsonContent = JsonConvert.SerializeObject(values, Formatting.Indented);
                File.WriteAllText(filePath, jsonContent);

                Notifacations.SendNotification($"<color=blue>[CONFIG]</color> SAVED : {filePath}");
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }
        public static void LoadConfig(string filePath)
        {
            try
            {
                CustomConsole.LogToConsole("[COLOSSAL] Loading Config");

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    foreach (var prop in typeof(PluginConfig).GetFields(BindingFlags.Public | BindingFlags.Static))
                    {
                        if (values.ContainsKey(prop.Name))
                        {
                            object parsedValue = values[prop.Name];
                            if (parsedValue is long longValue)
                            {
                                // Convert long to int
                                parsedValue = (int)longValue;
                            }
                            prop.SetValue(null, parsedValue); // Set value directly

                            CustomConsole.LogToConsole($"Set {prop.FieldType} '{prop.Name}' to '{parsedValue}'.");
                        }
                    }

                    Notifacations.SendNotification($"<color=blue>[CONFIG]</color> LOADED : {Menu.Settings[3].StringArray[Menu.Settings[3].stringsliderind]}");
                }
                else
                {
                    CustomConsole.LogToConsole("Config file not found: " + filePath);
                    Notifacations.SendNotification($"<color=blue>[CONFIG]</color> ERROR : {filePath}");
                }
            }
            catch (Exception ex)
            {
                CustomConsole.LogToConsole("Error loading config: " + ex.Message);
                Notifacations.SendNotification($"<color=blue>[CONFIG]</color> ERROR : {filePath}");
            }
        }
    }
}