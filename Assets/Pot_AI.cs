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
    public GameObject Tall_Plant;
    public GameObject Wide_Plant;
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
                    Plant = Tall_Plant;
                    Destroy(Wide_Plant, 0);
                    break;
                }
            case 1:
                {
                    Plant = Wide_Plant;
                    Destroy(Tall_Plant, 0);
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
