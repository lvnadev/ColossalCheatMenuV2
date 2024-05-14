
﻿using Colossal.Menu;
using Colossal.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class SpinBot : MonoBehaviour
    {
        private GameObject ghost;
        private GameObject point;
        private GameObject pointl;
        private GameObject pointr;
        private GameObject pointh;
        private GameObject pointParent;
        public void Update()
        {
            if (PluginConfig.SpinBot)
            {
                if (ghost == null)
                    ghost = GhostManager.SpawnGhost();

                if (pointParent == null)
                {
                    pointParent = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Destroy(pointParent.GetComponent<Collider>());
                    pointParent.transform.localScale = Vector3.zero;

                    pointParent.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                }

                if (point == null)
                {
                    point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(point.GetComponent<Collider>());
                    point.transform.localScale = Vector3.zero;
                    point.GetComponent<Renderer>().material.color = GhostManager.ghostColor;
                    point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                    point.transform.parent = pointParent.transform;
                    point.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                    point.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                }
                if (pointl == null)
                {
                    pointl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(pointl.GetComponent<Collider>());
                    pointl.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    pointl.GetComponent<Renderer>().material.color = GhostManager.ghostColor;
                    pointl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

                    pointl.transform.parent = pointParent.transform;
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

                    pointr.transform.parent = pointParent.transform;
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

                    pointh.transform.parent = pointParent.transform;
                    pointh.transform.position = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                    pointh.transform.rotation = GorillaTagger.Instance.offlineVRRig.headMesh.transform.rotation;
                }

                if (ghost != null)
                {
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

                        //Spinning SS rig
                        pointParent.transform.Rotate(0, 0, 50 * Time.deltaTime);
                    }

                    //Setting Position
                    pointParent.transform.position = GorillaLocomotion.Player.Instance.bodyCollider.transform.position;

                    //Updating CS rig
                    VRRig vrrig = ghost.GetComponent<VRRig>();
                    vrrig.mainSkin.material.color = GhostManager.ghostColor;
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");

                    vrrig.transform.position = point.transform.position;
                    vrrig.transform.rotation = point.transform.rotation;

                    vrrig.leftHandTransform.position = pointl.transform.position;
                    vrrig.leftHandTransform.rotation = pointl.transform.rotation;

                    vrrig.rightHandTransform.position = pointr.transform.position;
                    vrrig.rightHandTransform.rotation = pointr.transform.rotation;

                    vrrig.headConstraint.position = pointh.transform.position;
                    vrrig.headConstraint.rotation = pointh.transform.rotation;

                    //ghost.transform.Rotate(0, 0, 50 * Time.deltaTime);
                }
            }
            else
            {
                if (ghost != null)
                    GhostManager.DestroyGhost(ghost);

                Destroy(GorillaTagger.Instance.GetComponent<SpinBot>());
            }
        }
    }
}
