using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private string startScene;
    [SerializeField] private string controlScene;

    public void OnClickStart()
    {
        SceneManager.LoadScene(startScene);
    }

    public void OnClickControl()
    {
        SceneManager.LoadScene(controlScene);
    }
}
