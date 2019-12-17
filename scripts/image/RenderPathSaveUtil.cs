using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebycandle.Util.Graphic
{
    public class RenderPathSaveUtil:MonoBehaviour
    {
        #region VARS
        public static RenderPathSaveUtil instance;

        [Header("User Path Texture")]
        [SerializeField] private RenderTexture RenderTexture;

        [Header("Output File")]
        [SerializeField] private string FilePath = "C:/Users/ty/Desktop/UserPath.png";
        #endregion

        #region MONO-BEHAVIOUR
        void Awake()
        {
            instance = this;
        }
        #endregion

        #region UTIL-PUBLIC
        public void SaveTexture()
        {
            byte[] bytes = toTexture2D(RenderTexture).EncodeToPNG();

            System.IO.File.WriteAllBytes(FilePath, bytes);
        }
        #endregion

        #region UTIL-PRIVATE
        private Texture2D toTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height,/* 1920, 1080,*/ TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();

            return tex;
        }
        #endregion
    }
}
