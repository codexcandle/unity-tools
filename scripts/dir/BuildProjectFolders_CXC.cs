/*
MODIFIER:
Codebycandle
https://codebycandle.com

ORIGINAL AUTHOR:
Tommy Vogt (aka Kid_Niki)
https://forum.unity.com/threads/project-folder-auto-creation-script-c.268367/

PURPOSE:
Creates default folders for "Codebycandle" Unity projects.
// e.g.
// root / base folders
// root / base folders / graphics folders
// root / base folders / scripts folders

HOW:
1.  Inside Unity project's "Assets" folder, create a "Editor" folder.
2.  Place this script inside new folder above.
3.  In Unity, go to EDIT > [COMMAND PROMPT TEXT] (e.g. "Create Project Folders")
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Codeybycandle.Util.Dir
{
    public class BuildProjectFolders_CXC:ScriptableWizard
    {
        #region VAR
        [SerializeField] private bool MakeRootFolder        = true;
        [SerializeField] private bool MakeGraphicFolders    = true;
        [SerializeField] private bool MakeScriptFolders     = true;

        [SerializeField] private string RootFolder          = "_cxc";

        [SerializeField] private List<string> BaseFolders   = new List<string>()
            {"Audio", "Graphics", "Prefabs", "Scenes", "Scripts"};

        [SerializeField] private List<string> GraphicFolders = new List<string>()
            {"Materials", "Meshes", "Shaders", "Sprites", "Textures"};

        [SerializeField] private List<string> ScriptFolders = new List<string>()
            {"Control", "Model", "Util", "View"};

        private const string COMMAND_TEXT                   = "Create Project Folders";
        private const string FOLDER_ASSETS                  = "Assets";
        private const string FOLDER_GRAPHICS                = "Graphics";
        private const string FOLDER_SCRIPTS                 = "Scripts";
        #endregion

        [MenuItem("Edit/Create Project Folders...")]
        private static void CreateWizard()
        {
            ScriptableWizard.DisplayWizard(COMMAND_TEXT, typeof(BuildProjectFolders_CXC), "Create");
        }

        #region MONO-BEHAV
        private void OnWizardCreate()
        {
            // make folders /////////////////////////////////
            // ... root
            if(MakeRootFolder)
            {
                AssetDatabase.CreateFolder(FOLDER_ASSETS, RootFolder);
            }

            string basePath = string.Empty;

            // ... "base" set
            foreach(string folder in BaseFolders)
            {
                basePath = getBasePath();
                makeFolder(basePath, folder);
            }

            // ... "graphics" set
            foreach(string folder in GraphicFolders)
            {
                basePath = MakeGraphicFolders ? getBasePath(FOLDER_GRAPHICS) : getBasePath();
                makeFolder(basePath, folder);
            }

            // ..."scripts" set
            foreach(string folder in ScriptFolders)
            {
                basePath = MakeScriptFolders ? getBasePath(FOLDER_SCRIPTS) : getBasePath();
                makeFolder(basePath, folder);
            }
            /////////////////////////////////////////////////

            // refresh
            AssetDatabase.Refresh();
        }
        #endregion

        #region UTIL
        private void makeFolder(string basePath, string folder)
        {
            AssetDatabase.CreateFolder(basePath, folder);
        }

        private string getBasePath(string childFolderName = "")
        {
            // add root folder?
            string path = MakeRootFolder ? (FOLDER_ASSETS + "/" + RootFolder) : FOLDER_ASSETS;

            // add child folder?
            if(childFolderName != "")
            {
                path += "/" + childFolderName;
            }

            return path;
        }
        #endregion
    }
}