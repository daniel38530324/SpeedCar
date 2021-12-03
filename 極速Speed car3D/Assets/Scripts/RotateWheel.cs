using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    public int x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(x * Time.fixedDeltaTime, y * Time.fixedDeltaTime, z * Time.fixedDeltaTime);
    }
}
