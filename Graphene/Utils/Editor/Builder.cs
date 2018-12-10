using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Graphene.Utils
{
    public class Builder
    {
        private static string[] _scenes;
        private static string _buildDir = "Build/";

        [MenuItem("Automation/Build Desktop")]
        static void InternalBuildDesktop()
        {
            BuildWindows();
            BuildMacOS();
            BuildLinux();
        }

        [MenuItem("Automation/Build Mobile")]
        static void InternalBuildMobile()
        {
            BuildiOS();
            BuildAndroid();
        }

        private static void CheckFolders(string platform)
        {
            if (!Directory.Exists(_buildDir))
            {
                Directory.CreateDirectory(_buildDir);
            }
            if (Directory.Exists(_buildDir + platform))
                Directory.Delete(_buildDir + platform, true);

            _scenes = EditorBuildSettings.scenes.Select(x => x.path).ToArray();
        }

        [MenuItem("Automation/Build Mac")]
        public static void BuildMacOS()
        {
            CheckFolders("Mac");
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "Mac/" + Application.productName + ".app";
                buildPlayerOptions.target = BuildTarget.StandaloneOSX;
                buildPlayerOptions.options = BuildOptions.None;
                BuildPipeline.BuildPlayer(buildPlayerOptions);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }

        [MenuItem("Automation/Build Linux")]
        public static void BuildLinux()
        {
            CheckFolders("Linux");
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "Linux/" + Application.productName;
                buildPlayerOptions.target = BuildTarget.StandaloneLinuxUniversal;
                buildPlayerOptions.options = BuildOptions.None;
                BuildPipeline.BuildPlayer(buildPlayerOptions);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }

        [MenuItem("Automation/Build Windows")]
        public static void BuildWindows()
        {
            CheckFolders("Win");
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "Win/" + Application.productName + ".exe";
                buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
                buildPlayerOptions.options = BuildOptions.None;
                BuildPipeline.BuildPlayer(buildPlayerOptions);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }

        [MenuItem("Automation/Build HTML")]
        public static void BuildHtml()
        {
            CheckFolders("HTML");
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "HTML/" + Application.productName;
                buildPlayerOptions.target = BuildTarget.WebGL;
                buildPlayerOptions.options = BuildOptions.None;
                BuildPipeline.BuildPlayer(buildPlayerOptions);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }

        [MenuItem("Automation/Build Android")]
        public static void BuildAndroid()
        {
            PlayerSettings.Android.keystorePass = "Badjano2018";
            PlayerSettings.Android.keyaliasPass = "Badjano2018";
            CheckFolders("Android");
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "Android/" + Application.productName + ".apk";
                buildPlayerOptions.target = BuildTarget.Android;
                buildPlayerOptions.options = BuildOptions.None;
                BuildPipeline.BuildPlayer(buildPlayerOptions);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }

        [MenuItem("Automation/Build iOS")]
        public static void BuildiOS()
        {
            CheckFolders("iOS");
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "iOS/" + Application.productName;
                buildPlayerOptions.target = BuildTarget.iOS;
                buildPlayerOptions.options = BuildOptions.None;
                BuildPipeline.BuildPlayer(buildPlayerOptions);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                throw;
            }
        }
    }
}