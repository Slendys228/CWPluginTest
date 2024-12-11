using HarmonyLib;
using Unity.Mathematics;
using UnityEngine;
using Zorro.Settings;
namespace CWPluginTest
{
    [ContentWarningPlugin("CWPluginTest", "1.0", false)]
    public class PluginTy
    {
        static PluginTy()
        {
            Debug.Log("Hello from CWPluginTest! This is called on plugin load");
        }
    }

    [HarmonyPatch(typeof(GameAPI))]
    [HarmonyPatch("Awake")]
    public class StartMod
    {
        static bool Prefix()
        {
            if (!GameObject.Find("DontMeFuck"))
            {
                GameObject go = new GameObject("DontMeFuck");
                go.AddComponent<TryToFuckMe>();
                GameObject.DontDestroyOnLoad(go);
            }
            else
            {
                Debug.LogError("Same GO find on scene.");
            }
            return true;
        }
    }
    public class TryToFuckMe : MonoBehaviour
    {
        static float buttonWidth = 200;
        static float buttonHeight = 200;
        float xPos = (Screen.width - buttonWidth) / 2;
        float yPos = (Screen.height - buttonHeight) / 2;
        public void Start()
        {
            Debug.LogWarning("Start Component");
        }
        public void OnGUI()
        {
            if (GUI.Button(new Rect(xPos, yPos, buttonWidth, buttonHeight), "Example Button"))
            {
                Debug.Log("Example Log");
            }
        }
    }
    [ContentWarningSetting]
    public class ExampleSetting : FloatSetting, IExposedSetting
    {
        public override void ApplyValue() => Debug.Log($"omg, mod setting changed to {Value}");
        protected override float GetDefaultValue() => 100;
        protected override float2 GetMinMaxValue() => new(0, 100);
        // Prefer using the Mods category
        public SettingCategory GetSettingCategory() => SettingCategory.Mods;
        public string GetDisplayName() => "Example mod setting";
    }
}
