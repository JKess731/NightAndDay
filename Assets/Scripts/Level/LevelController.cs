using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> DisabledInputs;

    public bool flashlightDisabled = true;
    private GameObject player;

    private Vector2 startPos;

    private void Awake()
    {
        player = GameObject.FindWithTag("player");
        startPos = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = startPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in DisabledInputs)
        {
            if (flashlightDisabled == true && obj.GetComponent<Flashlight>())
            {
                obj.GetComponent<Flashlight>().enabled = false;
                flashlightDisabled = true;
            }
        }
    }
}
