
﻿using Colossal.Menu;
using Colossal.Patches;
using GorillaNetworking;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class GhostMonkey : MonoBehaviour
    {
        private GameObject ghost;
        private GameObject point;
        private GameObject pointl;
        private GameObject pointr;
        private GameObject pointh;

        public void Update()
        {
            if (PluginConfig.ghostmonkey && PhotonNetwork.InRoom)
            {
                if (ControllerInputPoller.instance.rightControllerSecondaryButton)
                {
                    if (ghost == null)
                        ghost = GhostManager.SpawnGhost();

                    if(point == null)
                    {
                        point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        Destroy(point.GetComponent<Collider>());
                        point.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        point.GetComponent<Renderer>().material.color = GhostManager.ghostColor;
                        point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                        point.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                        point.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                    }
                    if(pointl == null)
                    {
                        pointl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        Destroy(pointl.GetComponent<Collider>());
                        pointl.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        pointl.GetComponent<Renderer>().material.color = GhostManager.ghostColor;
                        pointl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                        pointl.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandPlayer.gameObject.transform.position;
                        pointl.transform.rotation = GorillaTagger.Instance.offlineVRRig.leftHandPlayer.gameObject.transform.rotation;
                    }
                    if (pointr == null)
                    {
                        pointr = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        Destroy(pointr.GetComponent<Collider>());
                        pointr.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        pointr.GetComponent<Renderer>().material.color = GhostManager.ghostColor;
                        pointr.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                        pointr.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandPlayer.gameObject.transform.position;
                        pointr.transform.rotation = GorillaTagger.Instance.offlineVRRig.rightHandPlayer.gameObject.transform.rotation;
                    }
                    if (pointh == null)
                    {
                        pointh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        Destroy(pointh.GetComponent<Collider>());
                        pointh.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        pointh.GetComponent<Renderer>().material.color = GhostManager.ghostColor;
                        pointh.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                        pointh.transform.position = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                        pointh.transform.rotation = GorillaTagger.Instance.offlineVRRig.headMesh.transform.rotation;
                    }

                    if (DisableRig.disablerig)
                        DisableRig.disablerig = false;

                    if (!DisableRig.disablerig)
                    {
                        GorillaTagger.Instance.offlineVRRig.transform.position = point.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.rotation = point.transform.rotation;

                        GorillaTagger.Instance.offlineVRRig.leftHandTransform.position = pointl.transform.position;
                        GorillaTagger.Instance.offlineVRRig.leftHandTransform.rotation = pointl.transform.rotation;

                        GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = pointr.transform.position;
                        GorillaTagger.Instance.offlineVRRig.rightHandTransform.rotation = pointr.transform.rotation;

                        GorillaTagger.Instance.offlineVRRig.headConstraint.position = pointh.transform.position;
                        GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = pointh.transform.rotation;
                    }

                    ghost.GetComponent<VRRig>().mainSkin.material.color = GhostManager.ghostColor;
                    ghost.GetComponent<VRRig>().mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                }
                else
                {
                    if (!DisableRig.disablerig)
                        DisableRig.disablerig = true;
                    if (ghost != null)
                        GhostManager.DestroyGhost(ghost);

                    if (point != null)
                        Destroy(point);
                    if (pointl != null)
                        Destroy(pointl);
                    if (pointr != null)
                        Destroy(pointr);
                    if (pointh != null)
                        Destroy(pointh);
                }
            }
            else
            {
                if (ghost != null)
                    GhostManager.DestroyGhost(ghost);

                if (point != null)
                    Destroy(point);
                if (pointl != null)
                    Destroy(pointl);
                if (pointr != null)
                    Destroy(pointr);
                if (pointh != null)
                    Destroy(pointh);

                if (DisableRig.disablerig)
                    DisableRig.disablerig = false;

                Destroy(holder.GetComponent<GhostMonkey>());
            }
        }
    }
}
