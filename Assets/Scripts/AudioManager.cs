using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _bgmAudioSource;
    public bool isAudioEnabled = false;
     private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }
    private void Awake() 
    {   
       if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public void PlayBgm()
    {
        int randomAudio = Random.Range(0, _bgmAudioSource.Count);
        _bgmAudioSource[randomAudio].Play();
        UnloadBGM(randomAudio);
    }

    public void UnloadAllBGM()
    {
        _bgmAudioSource.Clear();
    }

    private void UnloadBGM(int index)
    {
        int indexRemove = 0;
        int loopTimes = _bgmAudioSource.Count;
        for (int i = 0; i < loopTimes; i++)
        {
            if (i == index)
            {
                indexRemove += 1;
            }
            if (i != index)
            {
                _bgmAudioSource.RemoveAt(indexRemove);
            }
        }
    }
}
