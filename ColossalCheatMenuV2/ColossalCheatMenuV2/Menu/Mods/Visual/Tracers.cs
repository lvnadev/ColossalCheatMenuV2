using Colossal.Menu;
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
    public class Tracers : MonoBehaviour
    {
        private Color espcolor;
        public void Update()
        {
            if (PluginConfig.tracers)
            {
                switch (PluginConfig.ESPColour)
                {
                    case 0:
                        espcolor = new Color(0.6f, 0f, 0.8f, 0.4f);
                        break;
                    case 1:
                        espcolor = new Color(1f, 0f, 0f, 0.4f);
                        break;
                    case 2:
                        espcolor = new Color(1f, 1f, 0f, 0.4f);
                        break;
                    case 3:
                        espcolor = new Color(0f, 1f, 0f, 0.4f);
                        break;
                    case 4:
                        espcolor = new Color(0f, 0f, 1f, 0.4f);
                        break;
                    default:
                        espcolor = new Color(0.6f, 0f, 0.8f, 0.4f);
                        break;
                }

                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject gameObject = new GameObject("Line");
                        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

                        Color color;
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            color = new Color(1f, 0f, 0f, 0.4f);
                            lineRenderer.startColor = color;
                            lineRenderer.endColor = color;
                        }
                        else
                        {
                            lineRenderer.startColor = espcolor;
                            lineRenderer.endColor = espcolor;
                        }

                        lineRenderer.startWidth = 0.05f;
                        lineRenderer.endWidth = 0.05f;
                        lineRenderer.positionCount = 2;
                        lineRenderer.useWorldSpace = true;
                        lineRenderer.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                        lineRenderer.SetPosition(1, vrrig.transform.position);
                        lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                        GameObject.Destroy(gameObject, Time.deltaTime);
                    }
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<Tracers>());
            }
        }
    }
}
