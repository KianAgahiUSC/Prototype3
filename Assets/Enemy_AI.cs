using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    Scroller CamScroll;
    public bool KILLED;
    public GameObject Platform;
    bool Make_Platform;
    void Start()
    {
        //70 meter hike
        CamScroll = GameObject.Find("Main Camera").GetComponent<Scroller>();
    }

    bool DemonShift;
    void Update()
    {
        if (DemonShift == false)
        {
            Movement();
        }
        if(DemonShift == true)
        {
            CamScroll.DemonInfluence = true;
        }
        if(KILLED == true)
        {
            if(Make_Platform == false)
            {
                Instantiate(Platform,transform.position,transform.rotation);
                Make_Platform = true;
            }
            DemonShift = false;
            CamScroll.DemonInfluence = false;
            CamScroll.GetComponent<Animator>().enabled = true;
            CamScroll.GetComponent<Animator>().Play("ShakeDeath", 0, 0);
            Destroy(this.gameObject);
        }
    }
    int DIR;
    void Movement()
    {
        float spd = .175f;
        float Ranger = 5;
        switch (DIR)
        {
            case 0:
                {
                    if (transform.position.x < Ranger)
                    {
                        transform.Translate(spd * Time.smoothDeltaTime * 30f, 0, 0);
                    }
                    else
                    {
                        DIR = 1;
                    }
                    break;
                }
            case 1:
                {
                    if (transform.position.x > -Ranger)
                    {
                        transform.Translate(-spd * Time.smoothDeltaTime * 30f, 0, 0);
                    }
                    else
                    {
                        DIR = 0;
                    }
                    break;
                }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        DemonShift = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        DemonShift = false;
        CamScroll.DemonInfluence = false;
    }
}
