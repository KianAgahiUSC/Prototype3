using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AI : MonoBehaviour
{
    public int NextIndex;
    public int NextIndexAfter;
    public List<int> PotMaker;
    public bool GO_UP;
    public Player_AI My_Code;
    public GameObject Pot_Spawn;
    public int Pot_Index;
    int DIR;
    public bool Movement_Interrupt;
    public bool Delayed_Interrupt;
    bool Once_Placed;
    bool OnceInvokeDelayer;
    void Start()
    {
        GO_UP = false;
        My_Code = GetComponent<Player_AI>();
    }
    void UPD_Index()
    {
        
    }
    void NormControl()
    {
        Delayed_Interrupt = false;
    }
    void Update()
    {
        if(DEBUG_ONLY_P_TYPE > PotMaker.Count-1  )
        {
            DEBUG_ONLY_P_TYPE = 0;
        }
        if (DEBUG_ONLY_P_TYPE < 0)
        {
            DEBUG_ONLY_P_TYPE = PotMaker.Count-1;
        }
        //

        if (Delayed_Interrupt == true)
        {
            Once_Placed = true;
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
            if (Input.GetKeyDown(KeyCode.Space) && Delayed_Interrupt == false)
            {
                GO_UP = true;
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
        if (Once_Placed == true)
        {
            DEBUG_ONLY_P_TYPE = Random.Range(0, 8);
        }
        else
        {
            DEBUG_ONLY_P_TYPE = 1;
        }
        NPot.GetComponent<Pot_AI>().Back_to_movement = My_Code;
        Pot_Index = DEBUG_ONLY_P_TYPE;
        NPot.GetComponent<Pot_AI>().Index = Pot_Index;
        DEBUG_ONLY_P_TYPE += 1;
    }
}
