using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer PlantCHECK;
    public GameObject GLOWGO;
    Scroller CamScroll;
    public Meters PlayerME;
    Collider2D Box;
    void Start()
    {
        CamScroll = GameObject.Find("Main Camera").GetComponent<Scroller>();
        Box = GetComponent<Collider2D>();
    }
    bool MadeIT;
    void Update()
    {
        if(PlayerME.Meters_Counter > 40)
        {
            if (MadeIT == false)
            {
                GLOWGO.SetActive(true);
                PlantCHECK.color = new Vector4(1, 1, 1, 1);
                Box.isTrigger = false;
                CamScroll.GetComponent<Animator>().enabled = true;
                CamScroll.GetComponent<Animator>().Play("ShakeDeath", 0, 0);
                CamScroll.Final_Stretch = true;
                MadeIT = true;
            }
        }
    }
}
