using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarState : MonoBehaviour
{
    public static bool CarState1 = false;
    public static bool CarState2 = false;
    public static bool CarState3 = false;
    public static bool CarState4 = false;
    // Start is called before the first frame update
    void Start()
    {
        CarState1 = false;
        CarState2 = false;
        CarState3 = false;
        CarState4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CarStart1()
    {
        CarState1 = true;
    }
    public void CarStart2()
    {
        CarState2 = true;
    }
    public void CarStart3()
    {
        CarState3 = true;
    }
    public void CarStart4()
    {
        CarState4 = true;
    }
}
