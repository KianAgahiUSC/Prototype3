using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AI : MonoBehaviour
{
    public float StressCountDown;
    public bool At_Risk;
    public int EndGameState;
    public GameObject lastest;
    public bool CanSpawnMore;
    public GameObject HolderMine;
    public int NextIndex;
    public int NextIndexNextIndex;
    public bool GO_UP;
    public Player_AI My_Code;
    public GameObject Pot_Spawn;
    public int Pot_Index;
    int DIR;
    public bool Movement_Interrupt;
    public bool Delayed_Interrupt;
    public bool Once_Placed;
    bool OnceInvokeDelayer;
    Scroller CamScroll;
    public AudioSource bloop;

    void Start()
    {
        StressCountDown = 5;
        CamScroll = GameObject.Find("Main Camera").GetComponent<Scroller>();
        GO_UP = false;
        My_Code = GetComponent<Player_AI>();
        NextIndex = Random.Range(0, 8);
        NextIndexNextIndex = Random.Range(0, 8);
    }
    void UPD_Index()
    {
        Pot_Index = NextIndex;
        NextIndex = NextIndexNextIndex;
        NextIndexNextIndex = Random.Range(0, 8);
        if(CamScroll.Final_Stretch == true)
        {
            if (NextIndexNextIndex == 1)
            {
                NextIndexNextIndex = 7;
            }
            if (NextIndexNextIndex == 3)
            {
                NextIndexNextIndex = 6;
            }
            if (NextIndexNextIndex == 4)
            {
                NextIndexNextIndex = 7;
            }
        }
    }
    void NormControl()
    {
        Delayed_Interrupt = false;
    }
    GameObject CPot;
    public bool Make_Pot;
    public bool Final_Make_GO;
    bool OnceInvoke;
    void Update()
    {
        //
        if (Final_Make_GO == true && EndGameState == 0)
        {
            StressCountDown -= Time.deltaTime;
        }
        if (Delayed_Interrupt == true)
        {
            if (OnceInvokeDelayer == false)
            {
                Invoke("NormControl", .25f);
                OnceInvokeDelayer = true;
            }
        }
        else
        {
            OnceInvokeDelayer = false;
        }

        if(Once_Placed == true && lastest == null)
        {
            EndGameState = -1;
            //Lose, lastest pot went offscreen
        }

        if (EndGameState == 0)
        {
            if (Movement_Interrupt == false)
            {
                if (Make_Pot == false)
                {
                    Pot_Make();
                    Make_Pot = true;
                }

                if (Input.GetKeyDown(KeyCode.Space) && Delayed_Interrupt == false)
                {
                    GO_UP = true;
                    Pot_Drop();
                    Play_Bloop();
                    Movement_Interrupt = true;
                }
                Movement();
            }
        }
    }
    void Movement()
    {
        float spd = .25f;
        float Ranger = 5;
        switch(DIR)
        {
            case 0: 
                {
                    if (transform.position.x < Ranger)
                    {
                        transform.Translate(spd*Time.smoothDeltaTime*30f, 0, 0);
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
    void Pot_Make()
    { 
        if (CanSpawnMore == false)
        {
            GameObject NPot = Instantiate(Pot_Spawn, transform.position, Quaternion.identity);
            CPot = NPot;
            CPot.GetComponent<Pot_AI>().HolderPlace = HolderMine;
            CPot.GetComponent<Pot_AI>().Back_to_movement = My_Code;
            if (Once_Placed == false)
            {
                Pot_Index = 1;
            }
            else
            {
                UPD_Index();
            }
            CPot.GetComponent<Pot_AI>().Index = Pot_Index;
            CanSpawnMore = true;
        }
    }
    void Pot_Drop()
    {
        CPot.GetComponent<Pot_AI>().Dropped_State = 1;
        CPot = null;
    }

    void Play_Bloop()
    {
        bloop.Play();
    }
}
