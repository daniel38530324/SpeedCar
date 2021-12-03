using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseCar : MonoBehaviour
{
    public GameObject[] Car;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CarShow()
    {
        Car[index].SetActive(true);
        for(int i = 0; i < Car.Length; i++)
        {
            if(i != index)
            {
                Car[i].SetActive(false);
            }
        }
    }
    public void RightArrow()
    {
        index++;
        index %= Car.Length;
        CarShow();
    }
    public void LefttArrow()
    {
        index--;
        if(index == -1)
        {
            index = Car.Length - 1;
        }
        CarShow();
    }
}
