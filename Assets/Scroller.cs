using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public GameObject LastWarned;
    public GameObject CheckPointNOTIF;
    public TextMeshProUGUI TimerMan;
    public Animator WarningTime;
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
            CheckPointNOTIF.SetActive(true);
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

        if (MTrack.Meters_Counter >= 115 && PCode.StressCountDown > 0)
        {
            LastWarned.SetActive(false);
            CheckPointNOTIF.SetActive(false);
            PCode.EndGameState = 1;
            //Player Wins
        }
        if(PCode.StressCountDown < 0)
        {
            LastWarned.SetActive(false);
            CheckPointNOTIF.SetActive(false);
            PCode.EndGameState = -1;
        }
        if (MoverA.transform.position.y >= 108)
        {
            PCode.Final_Make_GO = true;
            WarningTime.enabled = true;
            LastWarned.SetActive(true);
            TimerMan.text = PCode.StressCountDown.ToString("0.00");
        }

            if (Scroll_UP == true)
        {
            if (PCode.EndGameState == 0)
            {
                if (MoverA.transform.position.y < 108)
                {
                    MoverA.transform.Translate(0, 0.7f * Time.smoothDeltaTime * 30f, 0);
                }
            }
        }
        else
        {
            if (PCode.GO_UP == true)
            {
                if (PCode.EndGameState == 0)
                {
                    if (MoverA.transform.position.y < 108)
                    {
                        MoverA.transform.Translate(0, (.01f + DSpeed + Harder_Speed + PenalitySPD) * Time.smoothDeltaTime * 30f, 0);
                    }
                }
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
