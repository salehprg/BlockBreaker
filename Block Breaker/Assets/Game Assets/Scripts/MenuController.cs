using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public void ExitApp()
    {
        Application.Quit();
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
