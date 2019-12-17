using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * util class to load images 
 * (w/ variable target: rawImage, image, or gameObject material)
 */
namespace Codebycandle.Utils
{
    public class ImageLoader:MonoBehaviour
    {
        #region PROPERTIES
        private static ImageLoader _instance;
        public static ImageLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Object.FindObjectOfType<ImageLoader>();
                }

                return _instance;
            }
        }
        #endregion

        #region METHODS (public)
        public void LoadImage(RawImage img, string url)
        {
            StartCoroutine(DownloadImage(url, img));
        }

        // TODO - get this working as seems to show "black screen" now? (not image!)
        public void LoadImage(Image img, string url, bool isExternal)
        {
            if (isExternal)
            {
                // url += ".png";

                StartCoroutine(DownloadImage(url, img));
            }
            else
            {
                img.sprite = Resources.Load(url, typeof(Sprite)) as Sprite;
            }
        }

        public void LoadImage(GameObject go, string url)
        {
            StartCoroutine(DownloadImage(url, go));
        }
        #endregion

        #region METHODS (private)
        IEnumerator DownloadImage(string url, RawImage target)
        {
            Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            using(WWW www = new WWW(url))
            {
                yield return www;

                if(www.texture != null)
                {
                    www.LoadImageIntoTexture(tex);

                    target.texture = tex;
                }
            }
        }

        IEnumerator DownloadImage(string url, Image target)
        {
            Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            using(WWW www = new WWW(url))
            {
                yield return www;

                if(www.texture != null)
                {
                    www.LoadImageIntoTexture(tex);

                    Sprite sprite = Sprite.Create(tex,
                                               new Rect(0, 0, tex.width, tex.height),
                                               new Vector2(0.5f, 0.5f));

                    target.sprite = sprite;

                    // Debug.Log("<color=red>Setting</color> sprite!");
                }
            }
        }

        IEnumerator DownloadImage(string url, GameObject target)
        {
            Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            using(WWW www = new WWW(url))
            {
                yield return www;

                if(www.texture != null)
                {
                    www.LoadImageIntoTexture(tex);

                    target.GetComponent<Renderer>().material.mainTexture = tex;
                }
            }
        }
        #endregion
    }
}