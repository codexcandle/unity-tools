/*
	SOURCE: 
		UNITY - 
		https://unity3d.com/learn/tutorials/topics/animation/using-timeline-custom-scripts
	FUNCTION:  
		Dynamically trigger "timelines" (via PlayableDirector)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController:MonoBehaviour
{
    public List<PlayableDirector> playableDirectors;
    public List<TimelineAsset> timelines;

    public void Play()
    {
        foreach (PlayableDirector playableDirector in playableDirectors) 
        {
            playableDirector.Play ();
        }
    }

    public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedAsset;

        if (timelines.Count <= index) 
        {
            selectedAsset = timelines [timelines.Count - 1];
        } 
        else 
        {
            selectedAsset = timelines [index];
        }

        // TODO - confirm if below should ALWAYS be 0?
        playableDirectors[0].Play (selectedAsset);
    }
}