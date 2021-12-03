using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAccounts : MonoBehaviour
{
    public GameObject[] LevelCar;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<Text>().text = GameDirector.time.ToString("F1");
        if(CarState.CarState1 == true)
        {
            LevelCar[0].SetActive(true);
            LevelCar[1].SetActive(false);
            LevelCar[2].SetActive(false);
            LevelCar[3].SetActive(false);
        }
        else if(CarState.CarState2 == true)
        {
            LevelCar[0].SetActive(false);
            LevelCar[1].SetActive(true);
            LevelCar[2].SetActive(false);
            LevelCar[3].SetActive(false);
        }
        else if (CarState.CarState3 == true)
        {
            LevelCar[0].SetActive(false);
            LevelCar[1].SetActive(false);
            LevelCar[2].SetActive(true);
            LevelCar[3].SetActive(false);
        }
        else if (CarState.CarState4 == true)
        {
            LevelCar[0].SetActive(false);
            LevelCar[1].SetActive(false);
            LevelCar[2].SetActive(false);
            LevelCar[3].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
