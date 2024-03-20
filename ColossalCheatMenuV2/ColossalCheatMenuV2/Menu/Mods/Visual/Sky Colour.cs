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

        public void Start()
        {
            this.gameObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky/newsky (1)");
            this.gameObject2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky");
        }
        public void Update()
        {
            if (Menu.Menu.Visual[3].stringsliderind != 0)
            {
                switch (Menu.Menu.Visual[3].stringsliderind)
                {
                    case 1:
                        if (this.gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject.GetComponent<MeshRenderer>().material.color != Color.magenta)
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.color != Color.magenta)
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.color = Color.magenta;
                            return;
                        }
                        break;
                    case 2:
                        if (this.gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject.GetComponent<MeshRenderer>().material.color != Color.red)
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.color != Color.red)
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.color = Color.red;
                            return;
                        }
                        break;
                    case 3:
                        if (this.gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject.GetComponent<MeshRenderer>().material.color != Color.cyan)
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.color != Color.cyan)
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.color = Color.cyan;
                            return;
                        }
                        break;
                    case 4:
                        if (this.gameObject.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.shader != Shader.Find("GorillaTag/UberShader"))
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (this.gameObject.GetComponent<MeshRenderer>().material.color != Color.green)
                        {
                            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                        }
                        if (this.gameObject2.GetComponent<MeshRenderer>().material.color != Color.green)
                        {
                            this.gameObject2.GetComponent<MeshRenderer>().material.color = Color.green;
                        }
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
