using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource dayMusicSource;
    [SerializeField] private AudioSource nightMusicSource;
    [SerializeField] public AudioSource sfxSource;

    private Flashlight flashlight;

    public AudioClip daytimeMusic;
    public AudioClip nighttimeMusic;
    public AudioClip jump;
    public AudioClip switchDay;
    public AudioClip switchNight;

    public bool isDay = true;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.FindAnyObjectByType<Flashlight>();

        dayMusicSource.clip = daytimeMusic;
        nightMusicSource.clip = nighttimeMusic;

        dayMusicSource.Play();
        nightMusicSource.Play();
        nightMusicSource.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        CheckNightOrDay();
    }

    void CheckNightOrDay()
    {

        if (isDay)
        {
            if (nightMusicSource.isPlaying)
            {
                nightMusicSource.Pause();
            }

            dayMusicSource.UnPause();
        }
        else
        {
            if (dayMusicSource.isPlaying)
            {
                dayMusicSource.Pause();
            }

            nightMusicSource.UnPause();
        }
    }
}
