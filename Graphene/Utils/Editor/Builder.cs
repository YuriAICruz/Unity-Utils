using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Graphene.Utils.Editor
{
    public class Builder
    {
        private static string[] _scenes;
        private static string _buildDir = "Builds/";

        [MenuItem("Automation/Build StandAlone")]
        static void InternalBuildIOS()
        {
            if (!Directory.Exists(_buildDir))
            {
                Directory.CreateDirectory(_buildDir);
                if (Directory.Exists(_buildDir + "Windows"))
                    Directory.Delete(_buildDir + "Windows");
                if (Directory.Exists(_buildDir + "MacOS"))
                    Directory.Delete(_buildDir + "MacOS");
                if (Directory.Exists(_buildDir + "Linux"))
                    Directory.Delete(_buildDir + "Linux");
            }

            _scenes = EditorBuildSettings.scenes.Select(x => x.path).ToArray();

            BuildWindows();
            BuildMacOS();
            BuildLinux();
        }

        public static void BuildMacOS()
        {
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "MacOS/" + Application.productName + ".app";
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

        public static void BuildLinux()
        {
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

        public static void BuildWindows()
        {
            try
            {
                BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                buildPlayerOptions.scenes = _scenes;
                buildPlayerOptions.locationPathName = _buildDir + "Windows/" + Application.productName + ".exe";
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
    }
}