using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBranch : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, 0);
    }
}
