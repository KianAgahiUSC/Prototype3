using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AI : MonoBehaviour
{
    public Player_AI My_Code;
    public GameObject Pot_Spawn;
    public int Pot_Index;
    int DIR;
    public bool Movement_Interrupt;
    public bool Delayed_Interrupt;
    bool OnceInvokeDelayer;
    void Start()
    {
        My_Code = GetComponent<Player_AI>();
    }
    void NormControl()
    {
        Delayed_Interrupt = false;
    }
    void Update()
    {
        //Remove this before submission
        if (Input.GetKeyDown(KeyCode.A))
        {
            DEBUG_ONLY_P_TYPE += 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DEBUG_ONLY_P_TYPE -= 1;
        }
        if(DEBUG_ONLY_P_TYPE > 1)
        {
            DEBUG_ONLY_P_TYPE = 0;
        }
        if (DEBUG_ONLY_P_TYPE < 0)
        {
            DEBUG_ONLY_P_TYPE = 1;
        }
        //

        if (Delayed_Interrupt == true)
        {
            if (OnceInvokeDelayer == false)
            {
                Invoke("NormControl", .5f);
                OnceInvokeDelayer = true;
            }
        }
        else
        {
            OnceInvokeDelayer = false;
        }

        if (Movement_Interrupt == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Delayed_Interrupt == false)
            {
                Pot_Make();
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
    public int DEBUG_ONLY_P_TYPE;
    void Pot_Make()
    {
        GameObject NPot = Instantiate(Pot_Spawn,transform.position,Quaternion.identity);
        NPot.GetComponent<Pot_AI>().Back_to_movement = My_Code;
        Pot_Index = DEBUG_ONLY_P_TYPE;
        NPot.GetComponent<Pot_AI>().Index = Pot_Index;
    }
}
