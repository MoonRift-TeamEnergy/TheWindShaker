using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel(int _scene)
    {
        PlayerPrefs.SetInt("LoadScene", _scene);
        SceneManager.LoadScene(1);
       
    }
}
