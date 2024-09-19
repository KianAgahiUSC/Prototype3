using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Tracker : MonoBehaviour
{
    public Meters MTrack;
    public TextMeshProUGUI MTEX;
    public Player_AI PTrack;
    public TextMeshProUGUI PTEX;
    void Start()
    {
        
    }

    void Update()
    {
        MTEX.text = MTrack.Meters_Counter.ToString();
        PTEX.text = PTrack.DEBUG_ONLY_P_TYPE.ToString();
    }
}
