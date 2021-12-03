using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMyself : MonoBehaviour
{
    public float RotateX,RotateY,RotateZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerController.GameState == true)
        {
            transform.Rotate(RotateX * Time.fixedDeltaTime, RotateY * Time.fixedDeltaTime, RotateZ * Time.fixedDeltaTime);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }
}
