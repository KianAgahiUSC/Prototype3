using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_AI : MonoBehaviour
{
    public int Index;
    GameObject Plant;
    public GameObject Tall_Plant;
    public GameObject Wide_Plant;
    public int Dropped_State;
    Rigidbody2D Pot_Physics;
    void Start()
    {
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
    void Update()
    {
        switch (Dropped_State)
        {
            case 2:
                {
                    Pot_Physics.constraints = RigidbodyConstraints2D.FreezeAll;
                    Pot_Physics.isKinematic = false;
                    Plant.SetActive(true);
                    break;
                }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Dropped_State = 2;
    }
}
