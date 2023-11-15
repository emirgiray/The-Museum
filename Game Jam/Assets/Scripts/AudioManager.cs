using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource, _effectSource;

    private AlternateController _Acontrol;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound (AudioClip clip)
    {
        if(_Acontrol.isMoving == true)
        {
            _effectSource.PlayOneShot(clip);
        }
        
    }
}
