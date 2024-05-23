using ColossalCheatMenuV2.Menu;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Colossal.Menu.ClientHub
{
    public class Overlay : MonoBehaviour
    {
        private float deltaTime;

        private static GameObject OverlayHub;
        private static Text OverlayHubText;
        private static GameObject OverlayHubRoom;
        private static Text OverlayHubTextRoom;

        public static void SpawnOverlay()
        {
            (OverlayHub, OverlayHubText) = GUICreator.CreateTextGUI("", "OverlayHub", TextAnchor.LowerLeft, new Vector3(0, 0f, 3.6f));
            (OverlayHubRoom, OverlayHubTextRoom) = GUICreator.CreateTextGUI("", "OverlayHubRoom", TextAnchor.LowerRight, new Vector3(0, 0f, 3.6f));
        }

        public void Update()
        {
            if (ShouldDisplayOverlay())
            {
                UpdateOverlay();
            }
            else
            {
                HideOverlay();
            }
        }

        private bool ShouldDisplayOverlay()
        {
            return PluginConfig.overlay && Menu.agreement && !PluginConfig.fullghostmode;
        }

        private void UpdateOverlay()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;

            if (PhotonNetwork.InRoom)
            {
                OverlayHubTextRoom.text = $"<color={Menu.MenuColour}>RoomName: </color>{PhotonNetwork.CurrentRoom.Name}\n<color={Menu.MenuColour}>Players: </color>{PhotonNetwork.CurrentRoom.PlayerCount}";
            }
            else
            {
                OverlayHubTextRoom.text = "";
            }

            OverlayHubText.text = $"<color={Menu.MenuColour}>Ping: </color>{PhotonNetwork.GetPing()}\n<color={Menu.MenuColour}>FPS: </color>{fps.ToString("F2")}\n<color={Menu.MenuColour}>Play Time: </color>{Plugin.playtimestring}";
        }

        private void HideOverlay()
        {
            OverlayHubText.text = "";
            OverlayHubTextRoom.text = "";
        }
    }
}