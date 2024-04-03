using Colossal.Menu;
using Colossal.Patches;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class TagAll : MonoBehaviour {
        private LineRenderer radiusLine;
        private Material lineMaterial;
        private GameObject[] objectsToDestroy;
        public void Update()
        {
            if (PluginConfig.tagall)
            {
                switch (Menu.Menu.MiscSettings[2].stringsliderind)
                {
                    case 1:
                        lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);
                        break;
                    case 2:
                        lineMaterial.color = new Color(1f, 0f, 0f, 0.5f);
                        break;
                    case 3:
                        lineMaterial.color = new Color(1f, 1f, 0f, 0.5f);
                        break;
                    case 4:
                        lineMaterial.color = new Color(0f, 1f, 0f, 0.5f);
                        break;
                    case 5:
                        lineMaterial.color = new Color(0f, 0f, 1f, 0.5f);
                        break;
                }

                GorillaTagger.Instance.tagCooldown = 0;
                GorillaLocomotion.Player.Instance.teleportThresholdNoVel = int.MaxValue;
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.isMyPlayer)
                    {
                        float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position);
                        if (distance < GorillaGameManager.instance.tagDistanceThreshold && vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            if (GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(GorillaTagger.Instance.myVRRig.Owner.ActorNumber))
                            {
                                if (radiusLine == null)
                                {
                                    lineMaterial = new Material(Shader.Find("Sprites/Default"));

                                    GameObject lineObject = new GameObject("RadiusLine");
                                    lineObject.transform.parent = vrrig.transform;
                                    radiusLine = lineObject.AddComponent<LineRenderer>();
                                    radiusLine.positionCount = 2;
                                    radiusLine.startWidth = 0.05f;
                                    radiusLine.endWidth = 0.05f;
                                    radiusLine.material = lineMaterial;
                                }
                                GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                radiusLine.SetPosition(0, vrrig.transform.position);
                                radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);
                                if (radiusLine.GetPosition(0) == null)
                                {
                                    if (radiusLine != null)
                                    {
                                        Destroy(radiusLine);
                                        radiusLine = null;
                                    }
                                }
                            }
                        }
                        else if (!vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            if (radiusLine == null)
                            {
                                lineMaterial = new Material(Shader.Find("Sprites/Default"));
                                lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);

                                GameObject lineObject = new GameObject("RadiusLine");
                                lineObject.transform.parent = vrrig.transform;
                                radiusLine = lineObject.AddComponent<LineRenderer>();
                                radiusLine.positionCount = 2;
                                radiusLine.startWidth = 0.05f;
                                radiusLine.endWidth = 0.05f;
                                radiusLine.material = lineMaterial;
                            }
                            GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                            radiusLine.SetPosition(0, vrrig.transform.position);
                            radiusLine.SetPosition(1, GorillaLocomotion.Player.Instance.bodyCollider.transform.position);
                            if (radiusLine.GetPosition(0) == null)
                            {
                                if (radiusLine != null)
                                {
                                    Destroy(radiusLine);
                                    radiusLine = null;
                                }
                            }
                            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                            if(DisableRig.disablerig)
                                DisableRig.disablerig = false;
                        }
                    }
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<TagAll>());
                if(!DisableRig.disablerig)
                    DisableRig.disablerig = true;
                if (radiusLine != null)
                {
                    Destroy(radiusLine.gameObject);
                    radiusLine = null;
                }
            }
        }
    }
}
