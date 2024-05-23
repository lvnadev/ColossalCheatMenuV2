using Colossal.Menu;
using Colossal.Patches;
using Photon.Pun;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class TagAura : MonoBehaviour
    {
        private LineRenderer radiusLine;
        private Material lineMaterial;

        private void Update()
        {
            if (PluginConfig.tagaura && PhotonNetwork.InRoom)
            {
                if (GorillaTagger.Instance == null || GorillaTagger.Instance.offlineVRRig == null || GorillaGameManager.instance == null || GorillaParent.instance == null || GorillaParent.instance.vrrigs == null)
                    return;

                float ammount = GetAmmountValue(PluginConfig.TagAuraAmmount);

                if (ammount > 0)
                {
                    bool isInfected = GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.ToLower().Contains("fected");
                    if (isInfected)
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (vrrig == null || vrrig.mainSkin == null || vrrig.isMyPlayer)
                                continue;

                            if (!vrrig.mainSkin.material.name.Contains("fected"))
                            {
                                float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position);
                                if (distance <= GorillaGameManager.instance.tagDistanceThreshold / ammount)
                                {
                                    DrawRadiusLine(vrrig);
                                    UpdatePlayerPosition(vrrig);
                                    DisableRig.disablerig = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DisableRig.disablerig = true;
                DestroyRadiusLine();
                DestroyComponent();
            }
        }

        private float GetAmmountValue(int ammountIndex)
        {
            switch (ammountIndex)
            {
                case 0:
                    return 4.5f;
                case 1:
                    return 4f;
                case 2:
                    return 3.5f;
                case 3:
                    return 3f;
                case 4:
                    return 2.5f;
                case 5:
                    return 2f;
                case 6:
                    return 1f;
                default:
                    return 0f;
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

                radiusLine.SetPosition(0, vrrig.transform.position);
                radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);

                if (radiusLine.GetPosition(0) == null)
                {
                    DestroyRadiusLine();
                }
            }
        }

        private void UpdatePlayerPosition(VRRig vrrig)
        {
            GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
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

        private void DestroyComponent()
        {
            if (holder != null)
                Destroy(holder.GetComponent<TagAura>());
        }
    }
}