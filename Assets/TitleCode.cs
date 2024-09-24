using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleCode : MonoBehaviour
{
    public GameObject MusicMan;
    public GameObject SpaceUI;
    public GameObject FDSP;
    void Start()
    {
        Cursor.visible = false;
    }
    void LD()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    bool GO_GAME;
    bool Load_Once;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FDSP.SetActive(true);
            SpaceUI.SetActive(false);
            MusicMan.SetActive(false);
            GO_GAME = true;
        }
        if(GO_GAME == true)
        {
            if(Load_Once == false)
            {
                Invoke("LD", .5f);
                Load_Once = true;
            }
        }
    }
}
