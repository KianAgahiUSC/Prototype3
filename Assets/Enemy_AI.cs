using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float FlipModel;
    public GameObject Model;
    public GameObject Got_Down;
    public ParticleSystem LoopDown;
    Scroller CamScroll;
    public bool KILLED;
    public GameObject Platform;
    bool Make_Platform;

    public AudioSource evilLaugh;
    public AudioSource flapping;

    bool isFlapping;

    void Start()
    {
        //70 meter hike
        FlipModel = 1;
        isFlapping = false;
        CamScroll = GameObject.Find("Main Camera").GetComponent<Scroller>();
    }

    bool DemonShift;
    void Update()
    {
        if (!isFlapping)
        {
            if (this.transform.position.y < 3.5)
            {
                flapping.Play();
                isFlapping=true;
            }
        }

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
            //when you place a pot on it
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
        Model.transform.localScale = new Vector3(0.6939798f* FlipModel, 0.6939798f, 0.6939798f);
        switch (DIR)
        {
            case 0:
                {
                    if (transform.position.x < Ranger)
                    {
                        FlipModel = 1;
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
                        FlipModel = -1;
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
        evilLaugh.Play();

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Got_Down.SetActive(false);
        DemonShift = false;
        CamScroll.DemonInfluence = false;
    }
}
