using Colossal.Menu;
using Colossal.Patches;
using Photon.Pun;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class TagAll : MonoBehaviour
    {
        private LineRenderer radiusLine;
        private Material lineMaterial;

        private void Update()
        {
            if (PluginConfig.tagall && PhotonNetwork.InRoom)
            {
                if (GorillaTagger.Instance == null || GorillaTagger.Instance.offlineVRRig == null || GorillaLocomotion.Player.Instance == null || GorillaParent.instance == null || GorillaParent.instance.vrrigs == null)
                    return;

                HandleTaggingCooldown();
                HandleTagging();
            }
            else
            {
                DisableTagging();
                DestroyComponents();
            }
        }

        private void HandleTaggingCooldown()
        {
            GorillaTagger.Instance.tagCooldown = 0;
            GorillaLocomotion.Player.Instance.teleportThresholdNoVel = int.MaxValue;
        }

        private void HandleTagging()
        {
            bool isInfected = GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.ToLower().Contains("fected");

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig == null || vrrig.mainSkin == null)
                    continue;

                bool isTargetInfected = vrrig.mainSkin.material.name.ToLower().Contains("fected");

                if (isInfected != isTargetInfected)
                {
                    DisableRig.disablerig = false;
                    UpdatePlayerPosition(vrrig);
                    DrawRadiusLine(vrrig);
                }
            }
        }

        private void UpdatePlayerPosition(VRRig vrrig)
        {
            if (GorillaTagger.Instance.offlineVRRig != null && GorillaTagger.Instance.offlineVRRig.rightHandTransform != null)
            {
                GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = vrrig.transform.position;
                GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position + new Vector3(0f, -2.5f, 0f);
            }
        }

        private void DrawRadiusLine(VRRig vrrig)
        {
            if (!PluginConfig.fullghostmode)
            {
                if (radiusLine == null)
                {
                    InitializeRadiusLine(vrrig);
                }

                if (GorillaLocomotion.Player.Instance.rightControllerTransform != null)
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;

                if (radiusLine != null)
                {
                    radiusLine.SetPosition(0, vrrig.transform.position);
                    radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);

                    if (radiusLine.GetPosition(0) == null)
                    {
                        DestroyRadiusLine();
                    }
                }
            }
        }

        private void InitializeRadiusLine(VRRig vrrig)
        {
            if (vrrig == null || vrrig.gameObject == null)
                return;

            if (lineMaterial == null)
                lineMaterial = new Material(Shader.Find("Sprites/Default"));

            GameObject lineObject = new GameObject("RadiusLine");
            lineObject.transform.parent = vrrig.transform;
            radiusLine = lineObject.AddComponent<LineRenderer>();
            radiusLine.positionCount = 2;
            radiusLine.startWidth = 0.05f;
            radiusLine.endWidth = 0.05f;
            radiusLine.material = lineMaterial;
        }

        private void DisableTagging()
        {
            DisableRig.disablerig = true;
        }

        private void DestroyRadiusLine()
        {
            if (radiusLine != null)
            {
                Destroy(radiusLine.gameObject);
                radiusLine = null;
            }

            if (lineMaterial != null)
            {
                Material.Destroy(lineMaterial);
                lineMaterial = null;
            }
        }

        private void DestroyComponents()
        {
            if (holder != null)
                Destroy(holder.GetComponent<TagAll>());
        }
    }
}