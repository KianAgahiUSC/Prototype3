using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_AI : MonoBehaviour
{
    GameObject Phantom;
    public GameObject Phantom0;
    public GameObject Phantom1;
    public GameObject Phantom2;
    public GameObject Phantom3;
    public GameObject Phantom4;
    public GameObject Phantom5;
    public GameObject Phantom6;
    public GameObject Phantom7;
    Scroller CamScroll;
    public Collider2D HitBox;
    public SpriteRenderer MainGraphic;
    public Sprite PTG0;
    public Sprite PTG1;
    public Sprite PTG2;
    public Sprite PTG3;
    public Sprite PTG4;
    public Sprite PTG5;
    public Sprite PTG6;
    public Sprite PTG7;
    GameObject Pot;
    public bool Offscreen_Kill;
    public Player_AI Back_to_movement;
    public int Index;
    GameObject Plant;
    public GameObject PT0;
    public GameObject PT1;
    public GameObject PT2;
    public GameObject PT3;
    public GameObject PT4;
    public GameObject PT5;
    public GameObject PT6;
    public GameObject PT7;
    public int Dropped_State;
    Rigidbody2D Pot_Physics;
    bool All_Done_Deploying;

    public AudioSource creakSound;
    public AudioSource leafSound;

    void Start()
    {
        CamScroll = GameObject.Find("Main Camera").GetComponent<Scroller>();
        HitBox.enabled = false;
        Pot = this.gameObject;
        All_Done_Deploying = false;
        Pot_Physics = GetComponent<Rigidbody2D>();
        Pot_Physics.gravityScale = 0;
        switch (Index)
        {
            case 0:
                {
                    Plant = PT0;
                    MainGraphic.sprite = PTG0;
                    Phantom = Phantom0;
                    break;
                }
            case 1:
                {
                    Plant = PT1;
                    MainGraphic.sprite = PTG1;
                    Phantom = Phantom1;
                    break;
                }
            case 2:
                {
                    Plant = PT2;
                    MainGraphic.sprite = PTG2;
                    Phantom = Phantom2;
                    break;
                }
            case 3:
                {
                    Plant = PT3;
                    MainGraphic.sprite = PTG3;
                    Phantom = Phantom3;
                    break;
                }
            case 4:
                {
                    Plant = PT4;
                    MainGraphic.sprite = PTG4;
                    Phantom = Phantom4;
                    break;
                }
            case 5:
                {
                    Plant = PT5;
                    MainGraphic.sprite = PTG5;
                    Phantom = Phantom5;
                    break;
                }
            case 6:
                {
                    Plant = PT6;
                    MainGraphic.sprite = PTG6;
                    Phantom = Phantom6;
                    break;
                }
            case 7:
                {
                    Plant = PT7;
                    MainGraphic.sprite = PTG7;
                    Phantom = Phantom7;
                    break;
                }
        } 
    }
    bool OnceKill;
    bool OnceCall;
    void ResePlant()
    {
        if (OnceCall == false)
        {
            Back_to_movement.Once_Placed = true;
            Back_to_movement.Make_Pot = false;
            Back_to_movement.CanSpawnMore = false;
            Back_to_movement.Movement_Interrupt = false;
            Back_to_movement.Delayed_Interrupt = true;
            OnceCall = true;
        }
    }
    public bool OPTIM;
    bool Goner;
    public GameObject HolderPlace;
    bool Bad_Player;
    void Update()
    {
        if (OPTIM == true)
        {
            if (Goner == false)
            {
                Destroy(Pot, .1f);
                Goner = true;
            }
        }
            if (Offscreen_Kill == true && OnceKill == false)
        {
            if(All_Done_Deploying == false)
            {
                if (Bad_Player == false)
                {
                    CamScroll.Penalty = true;
                    CamScroll.GetComponent<Animator>().enabled = true;
                    CamScroll.GetComponent<Animator>().Play("ShakeDeath", 0, 0);
                    Bad_Player = true;
                }
            }
            ResePlant();
            OnceKill = true;
        }
        if (OnceKill == false)
        {
            switch (Dropped_State)
            {
                case 0:
                    {
                        Pot.transform.position = HolderPlace.transform.position;
                        Pot_Physics.gravityScale = 0;
                        Phantom.SetActive(true);
                        break;
                    }
                case 1:
                    {
                        Phantom.SetActive(false);
                        HitBox.enabled = true;
                        Pot_Physics.gravityScale = 10;
                        break;
                    }
                case 2:
                    {
                        Phantom.SetActive(false);
                        if (All_Done_Deploying == false)
                        {
                            ImpactSound();
                            Back_to_movement.lastest = Pot;
                            HitBox.enabled = true;
                            ResePlant();
                            Pot_Physics.constraints = RigidbodyConstraints2D.FreezeAll;
                            Pot_Physics.isKinematic = false;
                            Plant.SetActive(true);
                            All_Done_Deploying = true;
                        }
                        break;
                    }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Dropped_State != 0)
        {
            Dropped_State = 2;
        }
    }
    bool OnceSND;
    void ImpactSound()
    {
        if (OnceSND == false)
        { 
       //     creakSound.Play();
            leafSound.Play();
            OnceSND = true;
        }
    }
}
