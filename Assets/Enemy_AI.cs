using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject Got_Down;
    public ParticleSystem LoopDown;
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
        var maina = LoopDown.emission;
        if (DemonShift == false)
        {
            maina.rateOverTime = 0;
            Movement();
        }
        if(DemonShift == true)
        {
            maina.rateOverTime = 5;
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
        Got_Down.SetActive(true);
        DemonShift = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Got_Down.SetActive(false);
        DemonShift = false;
        CamScroll.DemonInfluence = false;
    }
}
