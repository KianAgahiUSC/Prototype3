using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Tracker : MonoBehaviour
{
    public Player_AI PlayerGET;
    public Meters MTrack;
    public TextMeshProUGUI MTEX;
    public Image Current_Graphic;
    public Image Next_Graphic;
    public Image After_Next_Graphic;
    public Sprite PTG0;
    public Vector3 PTG0_Scalar;
    public Sprite PTG1;
    public Vector3 PTG1_Scalar;
    public Sprite PTG2;
    public Vector3 PTG2_Scalar;
    public Sprite PTG3;
    public Vector3 PTG3_Scalar;
    public Sprite PTG4;
    public Vector3 PTG4_Scalar;
    public Sprite PTG5;
    public Vector3 PTG5_Scalar;
    public Sprite PTG6;
    public Vector3 PTG6_Scalar;
    public Sprite PTG7;
    public Vector3 PTG7_Scalar;
    Sprite CurrentSprite;
    Vector3 CurrentScale;

    void Start()
    {
        
    }
    void UPD_GRAPHIC(int Nexter, Image Target_Graphic)
    {
        int Tracker = PlayerGET.NextIndex;
        switch (Nexter)
        {
            case 0:
                {
                    Tracker = PlayerGET.NextIndex;
                    break;
                }
            case 1:
                {
                    Tracker = PlayerGET.NextIndexNextIndex;
                    break;
                }
            case 2:
                {
                    Tracker = PlayerGET.Pot_Index;
                    break;
                }
        }

        switch (Tracker)
        {
            case 0:
                {
                    CurrentSprite = PTG0;
                    CurrentScale = PTG0_Scalar;
                    break;
                }
            case 1:
                {
                    CurrentSprite = PTG1;
                    CurrentScale = PTG1_Scalar;
                    break;
                }
            case 2:
                {
                    CurrentSprite = PTG2;
                    CurrentScale = PTG2_Scalar;
                    break;
                }
            case 3:
                {
                    CurrentSprite = PTG3;
                    CurrentScale = PTG3_Scalar;
                    break;
                }
            case 4:
                {
                    CurrentSprite = PTG4;
                    CurrentScale = PTG4_Scalar;
                    break;
                }
            case 5:
                {
                    CurrentSprite = PTG5;
                    CurrentScale = PTG5_Scalar;
                    break;
                }
            case 6:
                {
                    CurrentSprite = PTG6;
                    CurrentScale = PTG6_Scalar;
                    break;
                }
            case 7:
                {
                    CurrentSprite = PTG7;
                    CurrentScale = PTG7_Scalar;
                    break;
                }
        }
        Target_Graphic.sprite = CurrentSprite;
        Target_Graphic.rectTransform.localScale = CurrentScale;
    }
    void Update()
    {
        UPD_GRAPHIC(0, Next_Graphic);
        UPD_GRAPHIC(1, After_Next_Graphic);
        UPD_GRAPHIC(2, Current_Graphic);
        MTEX.text = MTrack.Meters_Counter.ToString();
    }
}
