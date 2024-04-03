using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Colossal.Menu
{
    public class ThisGuyIsUsingColossal : MonoBehaviour
    {
        Hashtable hash = new Hashtable
        {
            { "colossal", "colossal" }
        };

        void Update()
        {
            if (PhotonNetwork.InRoom && GorillaTagger.Instance.myVRRig != null)
            {
                if(PluginConfig.csghostclient && !GorillaTagger.Instance.myVRRig.Controller.CustomProperties.ContainsKey("colossal"))
                    GorillaTagger.Instance.myVRRig.Controller.SetCustomProperties(hash);
                else if(GorillaTagger.Instance.myVRRig.Controller.CustomProperties.ContainsKey("colossal"))
                    GorillaTagger.Instance.myVRRig.Controller.CustomProperties.Remove(hash);
            }

            HashSet<VRRig> processedVRRigs = new HashSet<VRRig>();
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != null && !vrrig.isOfflineVRRig && !processedVRRigs.Contains(vrrig))
                {
                    if (PluginConfig.csghostclient)
                    {
                        if (vrrig.Creator.CustomProperties.ContainsKey("colossal"))
                        {
                            vrrig.playerText.color = Color.magenta;
                            vrrig.playerText.text = "[CCM] " + vrrig.Creator.NickName;
                        }
                    }
                    else
                    {
                        vrrig.playerText.color = Color.white;
                        vrrig.playerText.text = vrrig.Creator.NickName;
                    }
                    processedVRRigs.Add(vrrig);
                }
            }
        }
    }
}