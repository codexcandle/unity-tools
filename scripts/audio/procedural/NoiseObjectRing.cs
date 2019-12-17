using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Codebycandle.Util.Tform;

namespace Codebycandle.Util.Snd
{
    public class NoiseObjectRing:MonoBehaviour
    {
        private const string SOUND_EVENT_NAME_PREFIX = "AudioRing";

        [SerializeField] private GameObject noiseObjectPrefab;
        [SerializeField] private float animDelaySecs = 2f;
        [SerializeField] private bool isRandom;
        [SerializeField] private bool autoStart;

        private List<GameObject> points;
        private int activeIndex = -1;

        public void ActivateNextPoint()
        {
            MakeItemActive(true, activeIndex + 1, true);
        }

        public void ActivateRandomPoint()
        {
            int randIndex = Random.Range(0, points.Count);

            MakeItemActive(true, randIndex);
        }

        public void ActivatePoint(int index)
        {
            MakeItemActive(true, index);
        }

        public void Init()
        {
            /* 
             * TODO - make this dynamic, 
             * with default sound playing 
             * if active index > # of sounds!
             */
            int pointCount = 8;

            points = SpawnPositionHelper.SpawnElipsoid(noiseObjectPrefab, 
                pointCount, Vector3.zero, gameObject.transform, false);

            StartCoroutine(LoopAudioPoints(animDelaySecs));
        }

        void Start()
        {
            if (autoStart) Init();
        }

        private void MakeItemActive(bool active, int index, bool resetIndexIfExceeds = false)
        {
            // sanitize
            if(points == null || index < 0)
            {
                return;
            }

            // handle if requested index is greater than total
            if(index >= points.Count)
            {
                if(resetIndexIfExceeds)
                {
                    index = 0;
                }
                else
                {
                    return;
                }
            }

            // if exists, reset previously-active point
            if(active == true && activeIndex > -1)
            {
                points[activeIndex].GetComponent<NoiseObject>().Activate(false);
            }

            // set audio clip
            NoiseObject p = points[index].GetComponent<NoiseObject>();

            // make item active
            p.Activate(active, active ? (SOUND_EVENT_NAME_PREFIX + (index + 1)) : string.Empty);

            // update val
            activeIndex = index;
        }

        IEnumerator LoopAudioPoints(float delaySecs)
        {
            while (true)
            {
                if (isRandom)
                    ActivateRandomPoint();
                else
                    ActivateNextPoint();

                yield return new WaitForSeconds(delaySecs);
            }
        }
    }
}