using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantKiller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pot")
        {
            collision.gameObject.GetComponent<Pot_AI>().Offscreen_Kill = true;
        }
    }
}
