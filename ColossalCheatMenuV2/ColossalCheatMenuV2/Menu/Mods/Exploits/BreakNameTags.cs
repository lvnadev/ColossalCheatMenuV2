using Colossal.Menu;
using GorillaNetworking;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class BreakNameTags : MonoBehaviour
    {
        bool once = false;
        string fuckedname = "GET FUCKED BY COLOSSAL CHEAT MENU V2 GET FUCKED BY COLOSSAL CHEAT MENU V2\nGET FUCKED BY COLOSSAL CHEAT MENU V2 GET FUCKED BY COLOSSAL CHEAT MENU V2\nGET FUCKED BY COLOSSAL CHEAT MENU V2 GET FUCKED BY COLOSSAL CHEAT MENU V2\nGET FUCKED BY COLOSSAL CHEAT MENU V2 GET FUCKED BY COLOSSAL CHEAT MENU V2\nGET FUCKED BY COLOSSAL CHEAT MENU V2 GET FUCKED BY COLOSSAL CHEAT MENU V2\nGET FUCKED BY COLOSSAL CHEAT MENU V2 GET FUCKED BY COLOSSAL CHEAT MENU V2\n";
        string normalname;
        public void Start() => normalname = PhotonNetwork.NickName;
        public void Update()
        {
            if (PluginConfig.breaknametags)
            {
                if(PhotonNetwork.InRoom && PhotonNetwork.LocalPlayer.NickName != fuckedname)
                {
                    PhotonNetwork.LocalPlayer.NickName = fuckedname;
                    GorillaComputer.instance.currentName = fuckedname;
                    GorillaComputer.instance.savedName = fuckedname;
                    PlayerPrefs.SetString("GorillaLocomotion.PlayerName", fuckedname);
                }
            }
            else
            {
                if (PhotonNetwork.LocalPlayer.NickName != normalname)
                {
                    PhotonNetwork.LocalPlayer.NickName = normalname;
                    GorillaComputer.instance.currentName = normalname;
                    GorillaComputer.instance.savedName = normalname;
                    PlayerPrefs.SetString("GorillaLocomotion.PlayerName", normalname);
                }
                Destroy(holder.GetComponent<BreakNameTags>());
            }
        }
    }
}
