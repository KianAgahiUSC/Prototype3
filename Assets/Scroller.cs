using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Meters MTrack;
    public GameObject MoverA;
    public bool Scroll_UP;
    public Player_AI PCode;
    public bool DemonInfluence;
    float DSpeed;
    public bool Final_Stretch;
    float Harder_Speed;
    public bool Penalty;
    bool Invoke_ONCE;
    float PenalitySPD;
    void Start()
    {
        
    }
    void Normal()
    {
        Penalty = false;
    }
    void Update()
    {
        if(Penalty == true)
        {
            PenalitySPD = .2f;
            if (Invoke_ONCE == false)
            {
                Invoke("Normal", .25f);
                Invoke_ONCE = true;
            }
        }
        else
        {
            PenalitySPD = 0;
            Invoke_ONCE = false;
        }


        if (Final_Stretch == true)
        {
            Harder_Speed = .0175f;
        }
        else
        {
            Harder_Speed = 0;
        }

        if (DemonInfluence == true)
        {
            DSpeed = .0375f;
        }
        else
        {
            DSpeed = 0;
        }

        if (Scroll_UP == true)
        {
            if (MTrack.Meters_Counter < 115)
            {
                if (PCode.EndGameState == 0)
                {
                    MoverA.transform.Translate(0, 0.7f * Time.smoothDeltaTime * 30f, 0);
                }
            }
            else
            {
                PCode.EndGameState = 1;
                //Player Wins
            }
        }
        else
        {
            if (PCode.GO_UP == true)
            {
                MoverA.transform.Translate(0, (.01f+ DSpeed+ Harder_Speed + PenalitySPD) * Time.smoothDeltaTime * 30f, 0);
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
