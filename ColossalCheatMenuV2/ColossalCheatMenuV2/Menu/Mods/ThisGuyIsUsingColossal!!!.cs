using ExitGames.Client.Photon;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Colossal.Mods
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
                    if(PluginConfig.csghostclient)
                    {
                        bool isColossal = vrrig.Creator.CustomProperties.ContainsKey("colossal");
                        if (isColossal)
                        {
                            //vrrig.mainSkin.material.SetColor("_EmissionColor", Color.magenta * 2.5f);

                            RectTransform nametagRect = vrrig.playerText.GetComponent<RectTransform>();
                            nametagRect.localPosition = Vector3.up * 180f + Vector3.right * 25f;
                            Quaternion rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
                            nametagRect.transform.rotation = rotation;
                            nametagRect.localScale = new Vector3(5, 5, 5);
                            vrrig.playerText.color = Color.magenta;
                        }
                        else
                        {
                            RectTransform nametagRect = vrrig.playerText.GetComponent<RectTransform>();
                            nametagRect.localPosition = Vector3.up * 180f + Vector3.right * 25f;
                            Quaternion rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
                            nametagRect.transform.rotation = rotation;
                            nametagRect.localScale = new Vector3(5, 5, 5);
                        }
                    }
                    else
                    {
                        vrrig.playerText.enabled = false;
                    }

                    processedVRRigs.Add(vrrig);
                }
            }
        }
    }
}
