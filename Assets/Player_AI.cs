using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AI : MonoBehaviour
{
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
    void Start()
    {
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
    }
    void NormControl()
    {
        Delayed_Interrupt = false;
    }
    GameObject CPot;
    public bool Make_Pot;
    void Update()
    {
        //

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
                Movement_Interrupt = true;
            }
            Movement();
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
}
