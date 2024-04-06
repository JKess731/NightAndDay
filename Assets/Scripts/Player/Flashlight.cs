using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Camera _playerCam;
    [SerializeField] private GameObject _whiteLevel;
    [SerializeField] private GameObject _blackLevel;

    private bool _whiteActivated = true;
    private bool _blackActivated = false;

    private void Awake()
    {
        _blackLevel.SetActive(false);
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

                _playerCam.backgroundColor = Color.black;

                _whiteActivated = false;
                _blackActivated = true;
            }
            else
            {
                _whiteLevel.SetActive(true);
                _blackLevel.SetActive(false);

                _playerCam.backgroundColor = Color.white;

                _whiteActivated = true;
                _blackActivated = false;
            }
        }
    }
}
