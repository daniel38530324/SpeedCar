using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndImage : MonoBehaviour
{
    public Sprite[] Car;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeImage", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeImage()
    {
        GetComponent<Image>().sprite = Car[index];
        index++;
        index %= Car.Length;
    }
}
