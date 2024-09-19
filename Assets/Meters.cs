using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meters : MonoBehaviour
{
    public float Meters_Counter;
    bool Add_Meters;
    void Start()
    {
        
    }
    void Meter_Calculate()
    {
        Meters_Counter = transform.position.y + 4.17f;
    }
    void Update()
    {
        Meter_Calculate();
        if (Add_Meters == true)
        {
            transform.Translate(0, 0.7f * Time.smoothDeltaTime * 30f, 0);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            Add_Meters = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            Add_Meters = false;
        }
    }
}
