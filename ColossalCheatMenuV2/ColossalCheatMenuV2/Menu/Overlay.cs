using ColossalCheatMenuV2.Menu;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Menu.ClientHub {
    public class Overlay : MonoBehaviour {
        private float deltaTime;

        public static GameObject OverlayHub;
        public static Text OverlayHubText;

        public static GameObject OverlayHubRoom;
        public static Text OverlayHubTextRoom;

        public static void SpawnOverlay()
        {
            (OverlayHub, OverlayHubText) = GUICreator.CreateTextGUI("", "OverlayHub", TextAnchor.LowerLeft, new Vector3(0, 0f, 3.6f));
            (OverlayHubRoom, OverlayHubTextRoom) = GUICreator.CreateTextGUI("", "OverlayHubRoom", TextAnchor.LowerRight, new Vector3(0, 0f, 3.6f));
        }

        public void Update() {
            if (PluginConfig.overlay && Menu.agreement && !PluginConfig.fullghostmode) 
            {
                deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
                float fps = 1.0f / deltaTime;

                if(PhotonNetwork.InRoom)
                    OverlayHubTextRoom.text = $"<color={Menu.MenuColour}>RoomName: </color>{PhotonNetwork.CurrentRoom.Name}\n<color={Menu.MenuColour}>Players: </color>{PhotonNetwork.CurrentRoom.PlayerCount}";
                else 
                {
                    if (OverlayHubTextRoom.text != null)
                        OverlayHubTextRoom.text = "";
                }
                OverlayHubText.text = $"<color={Menu.MenuColour}>Ping: </color>{PhotonNetwork.GetPing()}\n<color={Menu.MenuColour}>FPS: </color>{fps.ToString("F2")}\n<color={Menu.MenuColour}>Play Time: </color>{Plugin.playtimestring}";
            } 
            else 
            {
                if (OverlayHubText.text != null)
                    OverlayHubText.text = "";
                if (OverlayHubTextRoom.text != null)
                    OverlayHubTextRoom.text = "";
            }
        }
    }
}
