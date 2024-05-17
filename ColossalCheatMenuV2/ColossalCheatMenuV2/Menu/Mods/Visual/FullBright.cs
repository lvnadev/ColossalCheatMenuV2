using Colossal.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class FullBright : MonoBehaviour
    {
        private bool fuckmylife = false;
        public void Update()
        {
            if (PluginConfig.fullbright)
            {
                if(LightmapSettings.lightmaps != null)
                    LightmapSettings.lightmaps = null;
                if (fuckmylife)
                    fuckmylife = false;
            }
            else
            {
                if(!fuckmylife)
                {
                    SceneManager.LoadScene("Basement", LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync("Basement");

                    fuckmylife = true;
                }

                Destroy(holder.GetComponent<firstperson>());
            }
        }
    }
}
