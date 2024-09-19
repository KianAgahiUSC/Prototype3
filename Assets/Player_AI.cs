using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AI : MonoBehaviour
{
    public GameObject Pot_Spawn;
    public int Pot_Index;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pot_Make();
        }
    }
    void Pot_Make()
    {
        GameObject NPot = Instantiate(Pot_Spawn,transform.position,Quaternion.identity);
        Pot_Index = Random.Range(0, 2);
        NPot.GetComponent<Pot_AI>().Index = Pot_Index;
    }
}
