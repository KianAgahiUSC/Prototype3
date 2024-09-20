using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pot_AI : MonoBehaviour
{
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
    void Start()
    {
        Pot = this.gameObject;
        All_Done_Deploying = false;
        Pot_Physics = GetComponent<Rigidbody2D>();
        switch (Index)
        {
            case 0:
                {
                    Plant = PT0;
                    break;
                }
            case 1:
                {
                    Plant = PT1;
                    break;
                }
            case 2:
                {
                    Plant = PT2;
                    break;
                }
            case 3:
                {
                    Plant = PT3;
                    break;
                }
            case 4:
                {
                    Plant = PT4;
                    break;
                }
            case 5:
                {
                    Plant = PT5;
                    break;
                }
            case 6:
                {
                    Plant = PT6;
                    break;
                }
            case 7:
                {
                    Plant = PT7;
                    break;
                }
        } 
    }
    void ResePlant()
    {
        Back_to_movement.Movement_Interrupt = false;
        Back_to_movement.Delayed_Interrupt = true;
    }
    void Update()
    {
        if(Offscreen_Kill == true)
        {
            ResePlant();
            Destroy(Pot, .1f);
        }
        switch (Dropped_State)
        {
            case 2:
                {
                    if (All_Done_Deploying == false)
                    {
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Dropped_State = 2;
    }
}
