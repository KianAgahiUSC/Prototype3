using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonKill : MonoBehaviour
{
    public GameObject Parent;
    public Enemy_AI GOTHIT;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot")
        {
            GOTHIT.KILLED = true;
        }
    }
}
