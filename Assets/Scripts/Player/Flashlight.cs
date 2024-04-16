using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Camera _playerCam;
    [SerializeField] private GameObject _whiteLevel;
    [SerializeField] private GameObject _blackLevel;
    [SerializeField] private GameObject _audioManagerObj;

    private AudioManager _audio;

    private bool _whiteActivated = true;
    private bool _blackActivated = false;

    private void Awake()
    {
        _blackLevel.SetActive(false);
        _playerCam.backgroundColor = Color.black;
    }

    private void Start()
    {
        _audio = _audioManagerObj.GetComponent<AudioManager>();
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_whiteActivated)
            {
                _whiteLevel.SetActive(false);
                _blackLevel.SetActive(true);

                _whiteActivated = false;
                _blackActivated = true;
                _audio.isDay = true;
                _audio.sfxSource.clip = _audio.switchDay;
                _audio.sfxSource.Play();
            }
            else
            {
                _whiteLevel.SetActive(true);
                _blackLevel.SetActive(false);

                _whiteActivated = true;
                _blackActivated = false;
                _audio.isDay = false;
                _audio.sfxSource.clip = _audio.switchNight;
                _audio.sfxSource.Play();
            }
        }
    }
}
