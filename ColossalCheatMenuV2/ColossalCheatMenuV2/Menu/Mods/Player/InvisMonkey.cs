
﻿using Colossal.Menu;
using Colossal.Patches;
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
    public class InvisMonkey : MonoBehaviour
    {
        private GameObject ghost;
        public void Update()
        {
            if (PluginConfig.invismonkey && PhotonNetwork.InRoom)
            {
                if (!PluginConfig.invismonkey || !PhotonNetwork.InRoom)
                {
                    UnityEngine.Object.Destroy(GorillaTagger.Instance.GetComponent<InvisMonkey>());
                    return;
                }
                if (ControllerInputPoller.instance.leftControllerSecondaryButton)
                {
                    if(ghost == null) 
                        ghost = GhostManager.SpawnGhost();

                    if(DisableRig.disablerig)
                        DisableRig.disablerig = false;

                    ghost.GetComponent<VRRig>().mainSkin.material.color = GhostManager.ghostColor;
                    ghost.GetComponent<VRRig>().mainSkin.material.shader = Shader.Find("GUI/Text Shader");

                    GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(GorillaLocomotion.Player.Instance.headCollider.transform.position.x, -646.46466f, GorillaLocomotion.Player.Instance.headCollider.transform.position.z);
                    if (GorillaTagger.Instance.offlineVRRig.mainSkin.enabled)
                        GorillaTagger.Instance.offlineVRRig.mainSkin.enabled = false;
                    if (GorillaTagger.Instance.offlineVRRig.headMesh.active)
                        GorillaTagger.Instance.offlineVRRig.headMesh.active = false;
                    if (GorillaTagger.Instance.offlineVRRig.showName)
                        GorillaTagger.Instance.offlineVRRig.showName = false;
                    return;
                } else
                {
                    if (ghost != null)
                        GhostManager.DestroyGhost(ghost);
                    if(!DisableRig.disablerig)
                        DisableRig.disablerig = true;
                }
            }
            else
            {
                if(ghost != null)
                    GhostManager.DestroyGhost(ghost);
                if(!DisableRig.disablerig)
                    DisableRig.disablerig = true;

                if (!GorillaTagger.Instance.offlineVRRig.mainSkin.enabled)
                    GorillaTagger.Instance.offlineVRRig.mainSkin.enabled = true;
                if(!GorillaTagger.Instance.offlineVRRig.headMesh.active)
                    GorillaTagger.Instance.offlineVRRig.headMesh.active = true;
                if(!GorillaTagger.Instance.offlineVRRig.showName)
                    GorillaTagger.Instance.offlineVRRig.showName = true;

                Destroy(GorillaTagger.Instance.GetComponent<InvisMonkey>());
            }
        }
    }
}
