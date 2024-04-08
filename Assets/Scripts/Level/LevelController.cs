using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> DisabledInputs;

    public bool flashlightDisabled = true;
    
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
