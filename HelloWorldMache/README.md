# Hello World Mache Plugin
This repository is to help you get setup to run a Sons Of The Forest(SOTF) Mod in [Mache](https://github.com/willis81808/Mache).  


## Prerequisites
1. Download and Install [Visual Studio](https://visualstudio.microsoft.com/)
2. Download and Install [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager)
3. Purchase and Install SOTF on Steam

## Setting Up Thunderstore
Upon opening Thunderstore Mod Manager(TMM) you will have to select a game. Search and choose "Sons Of The Forest".  
<img src="drawable/TMM_SOFT.PNG" width="600">  

Hover over the title and select "Set as Default". This will allow it to load into SOTF each time the application is loaded.  
Next you will see the Profiles page. You can use the Default one or create your own. We will create a new Profile "Demo" for this.  
<img src="drawable/TMM_Profile.PNG" width="600">  

Make sure the profile you want is blue then click "Select Profile".  
This will open your TMM Game Mod Menu!  
First lets try to run the game vanilla. (Click "Vanilla" at the top right).  
<img src="drawable/TMM_Vanilla.PNG" width="600">  

If there is an issue running your game, click on Settings, verify that the following settings are appropriate for your computer:  
* Change Sons Of The Forest directory
* Change Steam directory  
<img src="drawable/TMM_Settings_Game.PNG" width="600">  


If you game did launch successfully, now we can add some mods!
Lets get Mache downloaded. (This should pull in the other depenency with it (BepInExPack_IL2CPP).  
<img src="drawable/TMM_Moche_Mod_Download.PNG" width="600">  



TMM is now ready for us to use!  
<img src="drawable/TMM_Downloaded_Mods.PNG" width="600">  

**Run SOTF with the Mods (Modded)** and once you load into a save press 'F1' to see the Mache menu then exit the game.  


## Creating, Building and Using The Visual Studio Project
Once Visual Studio (VS) is installed, open the application. We should go to a landing page.  
<img src="drawable/VS_Create_New_Project.PNG" width="600">  

Click Create a New Project.  
Search or scroll for "Class Library (.NET Framework)" and click Next.  
<img src="drawable/VS_Create_Class_Library.PNG" width="600">  

Provide a Name, Location and Framework for your project and click Create!  
<img src="drawable/VS_Project_Information.PNG" width="600">  

Rename your generated class file to be the name of your plugin.  
<img src="drawable/Rename_Class.PNG" width="300">  

Add your references; we will be using the TMM Data. 
On the Right side of your IDE, Right Click References and select Add Reference.  
<img src="drawable/Add_References.PNG" width="300">  

Select "Browse" on the left side, the click "Browse..." at the bottom.  
<img src="drawable/Browse_Browse.PNG" width="600">  

Traverse to your TMM Folder:  
`C:\Users\userId\AppData\Roaming\Thunderstore Mod Manager\DataFolder\SonsOfTheForest\profiles\Demo\BepInEx`   
<img src="drawable/WE_Mod_Files.PNG" width="600">  

Couple of notes here. First if you did not execute the game in the Modded Mode, the necessary files will not exist here. 
Second if you cannot traverse to your AppData folder, enable "Hidden Items" in your windows explorer. 

Here are a list of the DLLs you will need and there Directory with respsect to the "BepInEx" parent directory:  

| DLL Name | Path |
| -------- | ------- |
|BepInEx.Core|\core\BepInEx.Core.dll|
|BepInEx.Unity.IL2CPP|\core\BepInEx.Unity.IL2CPP.dll|
|Il2CppInterop.Runtime|\core\Il2CppInterop.Runtime.dll|
|Il2Cppmscorlib|\interop\Il2Cppmscorlib.dll|
|UnityEngine|\interop\UnityEngine.dll|
|UnityEngine.CoreModule|\interop\UnityEngine.CoreModule.dll|
|Mache|\plugins\willis81801-Mache\Mache.dll|
|UniverseLib.IL2CPP.Interop|\plugins\willis81801-Mache\UniverseLib.IL2CPP.Interop|

<img src="drawable/Browse_Import.PNG" width="600">  

Once you have selected all of these References, CLick Okay.  
<img src="drawable/References.PNG" width="300">  


Now we will write the plugin!
First is the MonoBehaviour
```
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
```

Next is the Base Plugin with the BepInEx Annotations. 
```
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
```

Both of these classes will go in your Namespace. 
And thats it! Now we have to build the solution.
At the top of your IDE, click Build -> Build Solution.  
<img src="drawable/Build_Solution.PNG" width="600">  

And your project should build successfully!  
<img src="drawable/Solution_Build_Successful.PNG" width="600">  




## Importing Your Mod Into Thunderstore Mod Manager
In TMM, click on Settings and find "Import local mod".  
<img src="drawable/TMM_Import_Mod.PNG" width="600">  

Navigate to your projects "obj\Debug" folder: `..\HelloWorldMache\HelloWorldMache\obj\Debug`.  
Select your DLL. Fill out the data, or not, and click Import at the bottom.  
<img src="drawable/TMM_Save_Mod.PNG" width="600">  

Next we will run SOTF Modded in TMM.  
<img src="drawable/ggs.PNG" width="600">  


## The End
And thats it. Hopefully you found this guide helpful.  
If you have any other questions reach out to the [SOTF Modding Discord Server](https://discord.gg/bwYmAqRPmd). 