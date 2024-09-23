using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToTitle : MonoBehaviour
{
    
    void Start()
    {
        Invoke("LD", 5);
    }
    void LD()
    {
        SceneManager.LoadSceneAsync("Title");
    }
}
