using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public bool Scroll_UP;
    public Player_AI PCode;
    void Start()
    {
        
    }

    void Update()
    {
        if(Scroll_UP == true)
        {
            transform.Translate(0, 0.7f*Time.smoothDeltaTime*30f, 0);
        }
        else
        {
            if (PCode.GO_UP == true)
            {
                transform.Translate(0, .01f * Time.smoothDeltaTime * 30f, 0);
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            Scroll_UP = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            Scroll_UP = false;
        }
    }
}
