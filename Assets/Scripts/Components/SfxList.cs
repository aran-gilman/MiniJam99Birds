using System.Collections.Generic;
using UnityEngine;

public class SfxList : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();

    public AudioClip SelectClip()
    {
        if (clips.Count == 0)
        {
            Debug.LogWarning("No audio clips assigned to SfxList on " + name);
            return null;
        }
        return clips[Random.Range(0, clips.Count)];
    }
}
