using BepInEx;
using Colossal.Menu;
using Colossal.Menu.ClientHub;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Playables;
namespace Colossal.Menu
{
<<<<<<< Updated upstream

    // Group 1
    public static bool excelfly = false;
    public static bool tfly = false;
    public static int wallwalk = 0;
    public static int speed = 0;
    public static int speedlg = 0;
    public static int speedrg = 0;
    public static bool platforms = false;
    public static bool upsidedownmonkey = false;
    public static bool wateryair = false;
    public static bool longarms = false;
    public static bool SpinBot = false;

    // Group 2
    public static bool chams = false;
    public static bool boxesp = false;
    public static bool hollowboxesp = false;
    public static bool whyiseveryonelookingatme = false;
    public static bool noexpressions = false;

    // Group 3
    public static bool nofinger = false;
    public static bool taggun = false;
    public static bool legmod = false;
    public static bool creepermonkey = false;
    public static bool ghostmonkey = false;
    public static bool invismonkey = false;
    public static int tagaura = 0;
    public static bool tagall = false;
    public static bool freezemonkey = false;
    public static bool desync = false;

    // Group 4
    public static bool breaknametags = false;
    public static bool breakmodcheckers = false;
    public static bool pccheckbypass = false;
    public static bool fakequestmenu = false;

    //group 5
    public static int MenuColour = 0;
    public static int MenuPos = 0;
    public static bool MenuRGB = false;

    //group 6
    public static bool driftmode = false;
    public static bool noti = true;
    public static bool overlay = true;
    public static bool csghostclient = true;
}

internal class Configs : MonoBehaviour
{
    public static string folderPath = "Colossal";
    public static string fileExtension = ".json";
    public static string fileName = "NewConfig";
    public static string[] GetConfigFileNames()
=======
    [Serializable]
    public class PluginConfig
>>>>>>> Stashed changes
    {

        // Group 1
        public static bool excelfly = false;
        public static bool tfly = false;
        public static bool wallwalk = false;
        public static int speed = 0;
        public static int speedlg = 0;
        public static int speedrg = 0;
        public static bool platforms = false;
        public static bool upsidedownmonkey = false;
        public static bool wateryair = false;
        public static bool longarms = false;
        public static bool SpinBot = false;
        public static bool WASDFly = false;
        public static bool FloatyMonkey = false;

        // Group 2
        public static bool chams = false;
        public static bool boxesp = false;
        public static bool hollowboxesp = false;
        public static bool whyiseveryonelookingatme = false;
        public static bool noexpressions = false;

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

        // Group 4
        public static bool breaknametags = false;
        public static bool breakmodcheckers = false;
        public static bool pccheckbypass = false;
        public static bool fakequestmenu = false;

        //group 5
        public static int MenuPos = 0;
        public static int MenuColour = 0;
        public static bool MenuRGB = false;
        public static int GhostColour = 0;
        public static int BeamColour = 0;
        public static int ESPColour = 0;
        public static int GhostOpacity = 2;

        public static int WASDFlySpeed = 2;
        public static int FloatMonkeyAmmount = 0;
        public static int TagAuraAmmount = 2;
        public static int WallWalkAmmount = 2;

        //group 6
        public static bool driftmode = false;
        public static bool noti = true;
        public static bool overlay = true;
        public static bool csghostclient = true;
    }

    internal class Configs : MonoBehaviour
    {
        public static string folderPath = "Colossal";
        public static string fileExtension = ".json";
        public static string fileName = "NewConfig";
        public static string[] GetConfigFileNames()
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath, "*" + fileExtension);

                string[] fileNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    fileNames[i] = Path.GetFileNameWithoutExtension(files[i]);
                }

                return fileNames;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting config file names: {ex.Message}");
                return new string[] { "Error" };
            }
<<<<<<< Updated upstream

            string newFileName = $"{fileName}_{nextFileNumber}{fileExtension}";

            string filePath = Path.Combine(folderPath, newFileName);

            List<object> values = new List<object>
            {
                // Group 1
                PluginConfig.excelfly,
                PluginConfig.tfly,
                PluginConfig.wallwalk,
                PluginConfig.speed,
                PluginConfig.speedlg,
                PluginConfig.speedrg,
                PluginConfig.platforms,
                PluginConfig.upsidedownmonkey,
                PluginConfig.wateryair,
                PluginConfig.longarms,
                PluginConfig.SpinBot,

                // Group 2
                PluginConfig.chams,
                PluginConfig.boxesp,
                PluginConfig.hollowboxesp,
                PluginConfig.whyiseveryonelookingatme,
                PluginConfig.noexpressions,

                // Group 3
                PluginConfig.nofinger,
                PluginConfig.taggun,
                PluginConfig.legmod,
                PluginConfig.creepermonkey,
                PluginConfig.ghostmonkey,
                PluginConfig.invismonkey,
                PluginConfig.tagaura,
                PluginConfig.tagall,
                PluginConfig.freezemonkey,
                PluginConfig.desync,

                // Group 4
                PluginConfig.breaknametags,
                PluginConfig.breakmodcheckers,
                PluginConfig.pccheckbypass,
                PluginConfig.fakequestmenu,

                //group 5
                PluginConfig.driftmode,
                PluginConfig.noti,
                PluginConfig.overlay,
                PluginConfig.csghostclient,

                //group 6
                PluginConfig.MenuColour,
                PluginConfig.MenuPos,
            };

            string jsonContent = JsonConvert.SerializeObject(values, Formatting.Indented);

            File.WriteAllText(filePath, jsonContent);

            Notifacations.SendNotification($"<color=blue>[CONFIG]</color> SAVED : {filePath}");
            Console.WriteLine($"saved to {filePath}");
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            string json = File.ReadAllText(filePath);
            List<object> values = JsonConvert.DeserializeObject<List<object>>(json);

            if (values.Count != 35)
            {
                Console.WriteLine($"Error loading plugin configuration from {filePath}: Incorrect number of values.");
                Notifacations.SendNotification($"<color=blue>[CONFIG]</color> ERROR : {filePath}");
                return;
            }
            /*for (int i = 0; i < values.Length; i++)
            {
                Debug.Log($"Value at index {i}: {values[i]}");
            }*/

            Menu.Movement[0].AssociatedBool = Convert.ToBoolean(values[0]);
            Menu.Movement[1].AssociatedBool = Convert.ToBoolean(values[1]);
            Menu.Movement[2].stringsliderind = Convert.ToInt32(values[2]);
            Menu.Speed[0].stringsliderind = Convert.ToInt32(values[3]);
            Menu.Speed[1].stringsliderind = Convert.ToInt32(values[4]);
            Menu.Speed[2].stringsliderind = Convert.ToInt32(values[5]);
            Menu.Movement[4].AssociatedBool = Convert.ToBoolean(values[6]);
            Menu.Movement[5].AssociatedBool = Convert.ToBoolean(values[7]);
            Menu.Movement[6].AssociatedBool = Convert.ToBoolean(values[8]);
            Menu.Movement[7].AssociatedBool = Convert.ToBoolean(values[9]);
            Menu.Movement[8].AssociatedBool = Convert.ToBoolean(values[10]);

            Menu.Visual[0].AssociatedBool = Convert.ToBoolean(values[11]);
            Menu.Visual[1].AssociatedBool = Convert.ToBoolean(values[12]);
            Menu.Visual[2].AssociatedBool = Convert.ToBoolean(values[13]);
            Menu.Visual[4].AssociatedBool = Convert.ToBoolean(values[14]);
            Menu.Visual[5].AssociatedBool = Convert.ToBoolean(values[15]);

            Menu.Player[0].AssociatedBool = Convert.ToBoolean(values[16]);
            Menu.Player[1].AssociatedBool = Convert.ToBoolean(values[17]);
            Menu.Player[2].AssociatedBool = Convert.ToBoolean(values[18]);
            Menu.Player[3].AssociatedBool = Convert.ToBoolean(values[19]);
            Menu.Player[4].AssociatedBool = Convert.ToBoolean(values[20]);
            Menu.Player[5].AssociatedBool = Convert.ToBoolean(values[21]);
            Menu.Player[6].stringsliderind = Convert.ToInt32(values[22]);
            Menu.Player[7].AssociatedBool = Convert.ToBoolean(values[23]);
            Menu.Player[8].AssociatedBool = Convert.ToBoolean(values[24]);
            Menu.Player[9].AssociatedBool = Convert.ToBoolean(values[25]);

            Menu.Modders[0].AssociatedBool = Convert.ToBoolean(values[26]);
            Menu.Modders[1].AssociatedBool = Convert.ToBoolean(values[27]);
            Menu.Modders[3].AssociatedBool = Convert.ToBoolean(values[28]);

            Menu.MainMenu[7].AssociatedBool = Convert.ToBoolean(values[29]);
            Menu.MainMenu[8].AssociatedBool = Convert.ToBoolean(values[30]);
            Menu.MainMenu[9].AssociatedBool = Convert.ToBoolean(values[31]);
            Menu.MainMenu[10].AssociatedBool = Convert.ToBoolean(values[32]);

            Menu.Settings[0].stringsliderind = Convert.ToInt32(values[33]);
            Menu.Settings[1].stringsliderind = Convert.ToInt32(values[34]);

            Notifacations.SendNotification($"<color=blue>[CONFIG]</color> LOADED : {filePath}");
            Console.WriteLine($"loaded {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading plugin configuration from {filePath}: {ex.Message}");
=======
            try
            {
                string[] existingFiles = Directory.GetFiles(folderPath, "*" + fileExtension);

                int nextFileNumber = 1;
                while (existingFiles.Any(file => Path.GetFileNameWithoutExtension(file).EndsWith(nextFileNumber.ToString())))
                {
                    nextFileNumber++;
                }

                string newFileName = $"{fileName}_{nextFileNumber}{fileExtension}";

                string filePath = Path.Combine(folderPath, newFileName);

                List<object> values = new List<object>
                {
                    // Group 1
                    PluginConfig.excelfly,
                    PluginConfig.tfly,
                    PluginConfig.wallwalk,
                    PluginConfig.speed,
                    PluginConfig.speedlg,
                    PluginConfig.speedrg,
                    PluginConfig.platforms,
                    PluginConfig.upsidedownmonkey,
                    PluginConfig.wateryair,
                    PluginConfig.longarms,
                    PluginConfig.SpinBot,
                    PluginConfig.WASDFly,
                    PluginConfig.FloatyMonkey,

                    // Group 2
                    PluginConfig.chams,
                    PluginConfig.boxesp,
                    PluginConfig.hollowboxesp,
                    PluginConfig.whyiseveryonelookingatme,
                    PluginConfig.noexpressions,

                    // Group 3
                    PluginConfig.nofinger,
                    PluginConfig.taggun,
                    PluginConfig.legmod,
                    PluginConfig.creepermonkey,
                    PluginConfig.ghostmonkey,
                    PluginConfig.invismonkey,
                    PluginConfig.tagaura,
                    PluginConfig.tagall,
                    PluginConfig.freezemonkey,
                    PluginConfig.desync,

                    // Group 4
                    PluginConfig.breaknametags,
                    PluginConfig.breakmodcheckers,
                    PluginConfig.pccheckbypass,

                    //group 5
                    PluginConfig.driftmode,
                    PluginConfig.noti,
                    PluginConfig.overlay,
                    PluginConfig.csghostclient,

                    //group 6
                    PluginConfig.MenuColour,
                    PluginConfig.MenuPos,
                    PluginConfig.GhostColour,
                    PluginConfig.BeamColour,
                    PluginConfig.ESPColour,
                    PluginConfig.GhostOpacity,
                    PluginConfig.WASDFlySpeed,
                    PluginConfig.FloatMonkeyAmmount,
                    PluginConfig.TagAuraAmmount,
                    PluginConfig.WallWalkAmmount
                };

                string jsonContent = JsonConvert.SerializeObject(values, Formatting.Indented);

                File.WriteAllText(filePath, jsonContent);

                Notifacations.SendNotification($"<color=blue>[CONFIG]</color> SAVED : {filePath}");
                Console.WriteLine($"saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving plugin configuration: {ex.Message}");
            }
        }

        public static void LoadConfig(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                List<object> values = JsonConvert.DeserializeObject<List<object>>(json);

                if (values.Count != 45)
                {
                    Console.WriteLine($"Error loading plugin configuration from {filePath}: Incorrect number of values.");
                    Notifacations.SendNotification($"<color=blue>[CONFIG]</color> ERROR : {filePath}");

                    for (int i = 0; i < values.Count; i++)
                    {
                        Debug.Log($"Value at index {i}: {values[i]}");
                    }
                    return;
                }

                for (int i = 0; i < values.Count; i++)
                {
                    Debug.Log($"Value at index {i}: {values[i]}");
                }

                Menu.Movement[0].AssociatedBool = Convert.ToBoolean(values[0]);
                Menu.Movement[1].AssociatedBool = Convert.ToBoolean(values[1]);
                Menu.Movement[2].AssociatedBool = Convert.ToBoolean(values[2]);
                Menu.Speed[0].stringsliderind = Convert.ToInt32(values[3]);
                Menu.Speed[1].stringsliderind = Convert.ToInt32(values[4]);
                Menu.Speed[2].stringsliderind = Convert.ToInt32(values[5]);
                Menu.Movement[4].AssociatedBool = Convert.ToBoolean(values[6]);
                Menu.Movement[5].AssociatedBool = Convert.ToBoolean(values[7]);
                Menu.Movement[6].AssociatedBool = Convert.ToBoolean(values[8]);
                Menu.Movement[7].AssociatedBool = Convert.ToBoolean(values[9]);
                Menu.Movement[8].AssociatedBool = Convert.ToBoolean(values[10]);
                Menu.Movement[9].AssociatedBool = Convert.ToBoolean(values[11]);
                Menu.Movement[10].AssociatedBool = Convert.ToBoolean(values[12]);

                Menu.Visual[0].AssociatedBool = Convert.ToBoolean(values[13]);
                Menu.Visual[1].AssociatedBool = Convert.ToBoolean(values[14]);
                Menu.Visual[2].AssociatedBool = Convert.ToBoolean(values[15]);
                Menu.Visual[4].AssociatedBool = Convert.ToBoolean(values[16]);
                Menu.Visual[5].AssociatedBool = Convert.ToBoolean(values[17]);

                Menu.Player[0].AssociatedBool = Convert.ToBoolean(values[18]);
                Menu.Player[1].AssociatedBool = Convert.ToBoolean(values[19]);
                Menu.Player[2].AssociatedBool = Convert.ToBoolean(values[20]);
                Menu.Player[3].AssociatedBool = Convert.ToBoolean(values[21]);
                Menu.Player[4].AssociatedBool = Convert.ToBoolean(values[22]);
                Menu.Player[5].AssociatedBool = Convert.ToBoolean(values[23]);
                Menu.Player[6].AssociatedBool = Convert.ToBoolean(values[24]);
                Menu.Player[7].AssociatedBool = Convert.ToBoolean(values[25]);
                Menu.Player[8].AssociatedBool = Convert.ToBoolean(values[26]);
                Menu.Player[9].AssociatedBool = Convert.ToBoolean(values[27]);

                Menu.Modders[0].AssociatedBool = Convert.ToBoolean(values[28]);
                Menu.Modders[1].AssociatedBool = Convert.ToBoolean(values[29]);
                Menu.Modders[2].AssociatedBool = Convert.ToBoolean(values[30]);

                Menu.MainMenu[7].AssociatedBool = Convert.ToBoolean(values[31]);
                Menu.MainMenu[8].AssociatedBool = Convert.ToBoolean(values[32]);
                Menu.MainMenu[9].AssociatedBool = Convert.ToBoolean(values[33]);
                Menu.MainMenu[10].AssociatedBool = Convert.ToBoolean(values[34]);

                Menu.ColourSettings[0].stringsliderind = Convert.ToInt32(values[35]);
                Menu.Settings[2].stringsliderind = Convert.ToInt32(values[36]);
                Menu.ColourSettings[1].stringsliderind = Convert.ToInt32(values[37]);
                Menu.ColourSettings[2].stringsliderind = Convert.ToInt32(values[38]);
                Menu.ColourSettings[3].stringsliderind = Convert.ToInt32(values[39]);
                Menu.ColourSettings[4].stringsliderind = Convert.ToInt32(values[40]);

                Menu.MiscSettings[0].stringsliderind = Convert.ToInt32(values[41]);
                Menu.MiscSettings[1].stringsliderind = Convert.ToInt32(values[42]);
                Menu.MiscSettings[2].stringsliderind = Convert.ToInt32(values[43]);
                Menu.MiscSettings[3].stringsliderind = Convert.ToInt32(values[44]);

                Notifacations.SendNotification($"<color=blue>[CONFIG]</color> LOADED : {Menu.Settings[3].StringArray[Menu.Settings[3].stringsliderind]}");
                Console.WriteLine($"loaded {Menu.Settings[3].StringArray[Menu.Settings[3].stringsliderind]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading plugin configuration from {filePath}: {ex.Message}");
            }
>>>>>>> Stashed changes
        }
    }
}