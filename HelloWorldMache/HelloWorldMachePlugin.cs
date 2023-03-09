using BepInEx;
using BepInEx.Unity.IL2CPP;
using Mache.UI;
using Mache;
using UnityEngine;

namespace HelloWorldMache
{
    [BepInDependency("com.willis.sotf.mache")]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("SonsOfTheForest.exe")]
    public class HelloWorldMachePlugin : BasePlugin
    {
        public const string ModId = "com.pankakes.sotf.helloworldmache";
        public const string ModName = "Hello World Mache";
        public const string Version = "0.0.1";

        internal static HelloWorldMachePlugin Instance { get; private set; }

        public override void Load()
        {
            Instance = this;
            AddComponent<HelloWorld>();
        }
    }

    public class HelloWorld : MonoBehaviour
    {
        private void Start() 
        {
            Mache.Mache.RegisterMod(() => new ModDetails
            {
                Id = HelloWorldMachePlugin.ModId,
                Version = HelloWorldMachePlugin.Version,
                Name = HelloWorldMachePlugin.ModName,
                Description = "This text will show up in the Mache Framework Menu.",
                OnFinishedCreating = CreateMenu,
            });
        }

        private void CreateMenu(GameObject parent)
        {
            MenuPanel.Builder()
                .AddComponent(new LabelComponent
                {
                    Text = "Hello World Mache Text will show up as a label.",
                    FontSize = 20
                })
                .BuildToTarget(parent);
        }

        private void Update() { }
    }
}
