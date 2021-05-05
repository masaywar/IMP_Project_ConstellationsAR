using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioPlayer;
    
    [SerializeField]
    private Dictionary<string, AudioClip> _audioClipsDict;


    public Dictionary<string, AudioClip> audioClipsDict
    {
        get
        {
            if (_audioClipsDict == null)
                _audioClipsDict = new Dictionary<string, AudioClip>();

            return _audioClipsDict;
        }
    }

    private void Awake()
    {
        Resources.LoadAll<AudioClip>("Audio").ForEach(clip => audioClipsDict.Add(clip.name, clip));
        audioPlayer = gameObject.AddComponent<AudioSource>();

        OnPlayAudio("the night sky");
    }
    

    public void OnPlayAudio(string name)
    {
        if (!audioClipsDict.TryGetValue(name, out var clip))
            return;

        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    public AudioClip GetPlayingAudio()
    {
        if (audioPlayer.isPlaying)
            return audioPlayer.clip;

        return null;
    }

    public void SetVolumne(float value)
    {
        audioPlayer.volume = value;
    }
}
