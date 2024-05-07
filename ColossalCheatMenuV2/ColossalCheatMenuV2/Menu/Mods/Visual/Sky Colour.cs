using Colossal.Menu;
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
    public class SkyColour : MonoBehaviour
    {
        private new GameObject gameObject;
        private GameObject gameObject2;

        private Material original;
        private Material original2;

        public void Start()
        {
            gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky/newsky (1)");
            gameObject2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky");

            original = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky/newsky (1)").GetComponent<Renderer>().material;
            original2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>().material;
        }
        public void Update()
        {
            switch (PluginConfig.skycolour)
            {
                case 0:
                    if (gameObject.GetComponent<MeshRenderer>().material != original)
                        gameObject.GetComponent<MeshRenderer>().material = original;
                    if (gameObject2.GetComponent<MeshRenderer>().material != original2)
                        gameObject2.GetComponent<MeshRenderer>().material = original2;
                    break;
                case 1:
                    if (gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject.GetComponent<MeshRenderer>().material.color != Color.magenta)
                    {
                        gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.color != Color.magenta)
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.color = Color.magenta;
                        return;
                    }
                    break;
                case 2:
                    if (gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject.GetComponent<MeshRenderer>().material.color != Color.red)
                    {
                        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.color != Color.red)
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.color = Color.red;
                        return;
                    }
                    break;
                case 3:
                    if (gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject.GetComponent<MeshRenderer>().material.color != Color.cyan)
                    {
                        gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.color != Color.cyan)
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        return;
                    }
                    break;
                case 4:
                    if (gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    if (gameObject.GetComponent<MeshRenderer>().material.color != Color.green)
                    {
                        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    if (gameObject2.GetComponent<MeshRenderer>().material.color != Color.green)
                    {
                        gameObject2.GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    break;
                default:
                    return;
            }
        }
    }
}
