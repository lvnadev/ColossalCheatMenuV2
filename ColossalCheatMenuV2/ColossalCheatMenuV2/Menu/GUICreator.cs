using Colossal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ColossalCheatMenuV2.Menu
{
    internal class GUICreator : MonoBehaviour
    {
        private static Material mat = new Material(Shader.Find("GUI/Text Shader"));
        public static (GameObject, Text) CreateTextGUI(string text, string name, Vector3 localpos, Transform transform, TextAnchor alignment)
        {
            GameObject HUDObj = new GameObject();

            HUDObj.name = name;

            Canvas canvas = HUDObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = Camera.main;

            HUDObj.AddComponent<CanvasScaler>();
            HUDObj.AddComponent<GraphicRaycaster>();

            RectTransform rectTransform = HUDObj.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(5, 5);
            HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);

            GameObject menuTextObj = new GameObject();
            menuTextObj.transform.SetParent(HUDObj.transform);
            Text MenuText = menuTextObj.AddComponent<Text>();
            MenuText.text = text;
            MenuText.fontSize = 10;
            MenuText.font = Plugin.gtagfont;
            MenuText.rectTransform.sizeDelta = new Vector2(260, 160);
            MenuText.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
            MenuText.rectTransform.localPosition = localpos;
            MenuText.material = mat;
            MenuText.alignment = alignment;

            //HUDObj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2.1f);
            //HUDObj.transform.rotation = transform.rotation;
            //HUDObj.transform.SetParent(transform);

            // Calculate the position relative to the main camera
            Vector3 cameraOffset = Camera.main.transform.rotation * localpos;
            HUDObj.transform.SetParent(Camera.main.transform);
            HUDObj.transform.position = Camera.main.transform.position + cameraOffset;
            HUDObj.transform.rotation = Camera.main.transform.rotation;

            return (HUDObj, MenuText);
        }
    }
}
