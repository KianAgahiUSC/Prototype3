using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantKiller : MonoBehaviour
{
    public PlantKiller RiskOBJ;
    public Player_AI Risker;
    public int Type;
    public GameObject Risk_Object;
    void Update()
    {
        if (Risk_Object != null)
        {
            if (Risker.At_Risk == true && Risk_Object != Risker.lastest)
            {
                Risker.At_Risk = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        switch (Type)
        {
            case 1:
                {
                    if (collision.tag == "Pot" && collision.gameObject == Risker.lastest)
                    {
                        Risk_Object = collision.gameObject;
                        Risker.At_Risk = true;
                    }
                    break;
                }
        }
     }
    void OnTriggerExit2D(Collider2D collision)
    {
        switch (Type)
        {
            case 1:
                {
                    if (collision.tag == "Pot" && collision.gameObject == Risker.lastest)
                    {
                        Risker.At_Risk = false;
                    }
                    break;
                }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        switch(Type)
        {
            case 0:
                {
                    if (collision.tag == "Pot")
                    {
                        collision.gameObject.GetComponent<Pot_AI>().Offscreen_Kill = true;
                        RiskOBJ.Risk_Object = null;
                    }
                    break;
                }
            case 2:
                {
                    if (collision.tag == "Pot")
                    {
                        collision.gameObject.GetComponent<Pot_AI>().OPTIM = true;
                    }
                    break;
                }
        }
    }
}
