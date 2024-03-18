using Colossal;
using Colossal.Menu.ClientHub;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ColossalCheatMenuV2.Menu
{
    internal class Boards : MonoBehaviour
    {
        public static GorillaLevelScreen[] joinScreens;
        public static Material boardmat;
        public static string joinscreentext;
        public static string coctext;


        private float rainbowtext = 0f;
        private static string textcolour = "magenta";
        public void Start()
        {
            boardmat = new Material(Shader.Find("GorillaTag/UberShader"));
            boardmat.color = new Color(0.6f, 0, 0.80f);

            if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("TreeRoom").gameObject.activeSelf)
            {
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/motdscreen").GetComponent<Renderer>().material = boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/screen").GetComponent<Renderer>().material = boardmat;

                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = boardmat;

                //GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/campgroundstructure/scoreboard/REMOVE board").GetComponent<MeshRenderer>().material = boardmat;

                //GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/-- PhysicalComputer UI --/monitor").GetComponent<Renderer>().material = boardmat;

                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd/motdtext").GetComponent<Text>().color = Color.cyan;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().color = Color.cyan;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().text = "UPDATES";
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenForest").GetComponent<Text>().color = Color.cyan;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCave").GetComponent<Text>().color = Color.cyan;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCity Front").GetComponent<Text>().color = Color.cyan;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCanyon").GetComponent<Text>().color = Color.cyan;
                CustomConsole.LogToConsole("Loaded Colours!");
            }
        }
        public void Update()
        {
            coctext = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features/FUD. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base</color><color=cyan>\nWM: No Fingers\nStarry: Creeper Monke/Tester\nAntic/ChatGPT: Tester\nCunzaki/Plinko: Tester\nBlobFish: DisableRig\n\nCurrent Menu Version: {Plugin.version}</color>";

            if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("TreeRoom").gameObject.activeSelf)
            {
                rainbowtext += Time.deltaTime;
                if (rainbowtext >= 0.1f)
                {
                    textcolour = "magenta";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = coctext;
                }
                if (rainbowtext >= 0.2f)
                {
                    textcolour = "red";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = coctext;
                }
                if (rainbowtext >= 0.3f)
                {
                    textcolour = "green";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = coctext;
                }
                if (rainbowtext >= 0.4f)
                {
                    textcolour = "blue";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = coctext;
                }
                if (rainbowtext >= 0.5f)
                {
                    textcolour = "cyan";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = coctext;
                }
                if (rainbowtext >= 0.6f)
                {
                    textcolour = "yellow";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = coctext;
                }
                if (rainbowtext >= 0.6f)
                {
                    rainbowtext = 0;
                }
            }
        }
    }
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnJoinedRoom")]
    internal class JoinedRoom
    {
        [HarmonyPrefix]
        private static void Postfix()
        {
            Boards.joinscreentext = $"<Colossal Cheat Menu V2>\nPhoton Name: {PhotonNetwork.LocalPlayer.NickName}\nUserID: {PhotonNetwork.LocalPlayer.UserId}\nRoom Name: {PhotonNetwork.CurrentRoom.Name}   Players: {PhotonNetwork.CurrentRoom.PlayerCount}\nMaster: {PhotonNetwork.MasterClient.NickName}   Public: {PhotonNetwork.CurrentRoom.IsVisible}";

            if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("TreeRoom").gameObject.activeSelf)
            {
                /*using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string rawData = client.GetStringAsync("https://pastebin.com/raw/bhLzrd4F").Result;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd/motdtext")
                            .GetComponent<Text>().text = rawData;
                        CustomConsole.LogToConsole("Loaded MOTD!");
                    }
                    catch (HttpRequestException ex)
                    {
                        CustomConsole.LogToConsole("Error: " + ex.Message);
                    }
                }*/
                
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = Boards.boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = Boards.boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = Boards.boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = Boards.boardmat;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = Boards.boardmat;

                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenForest").GetComponent<Text>().text = Boards.joinscreentext;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCave").GetComponent<Text>().text = Boards.joinscreentext;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCity Front").GetComponent<Text>().text = Boards.joinscreentext;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Tree Room Texts/WallScreenCanyon").GetComponent<Text>().text = Boards.joinscreentext;

                //GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI/ForestScoreboardAnchor/GorillaScoreBoard(Clone)/Board Text").GetComponent<Text>().color = Color.cyan;
                CustomConsole.LogToConsole("Loaded Colours And Info!\n");
            }
        }
    }
}
