using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Image[] TimeNum;
    public Sprite[] Num;
    public static float time = 30;

    public GameObject Clock;
    public GameObject DirectionalLight;
    public GameObject Lose;
    public GameObject Go;
    public Image GoTime;
    public Sprite[] GoNum;
    private float WentTime = 3;

    public GameObject[] Car;
    // Start is called before the first frame update
    void Start()
    {
        time = 30;
        WentTime = 3;
        Clock.SetActive(false);
        Go.SetActive(true);
        if (CarState.CarState1 == true)
        {
            Car[0].SetActive(true);
            Car[1].SetActive(false);
            Car[2].SetActive(false);
            Car[3].SetActive(false);
        }
        else if (CarState.CarState2 == true)
        {
            Car[0].SetActive(false);
            Car[1].SetActive(true);
            Car[2].SetActive(false);
            Car[3].SetActive(false);
        }
        else if (CarState.CarState3 == true)
        {
            Car[0].SetActive(false);
            Car[1].SetActive(false);
            Car[2].SetActive(true);
            Car[3].SetActive(false);
        }
        else if (CarState.CarState4 == true)
        {
            Car[0].SetActive(false);
            Car[1].SetActive(false);
            Car[2].SetActive(false);
            Car[3].SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (PlayerController.GameState == false && time == 30)
        {
            Clock.SetActive(true);
            WentTime -= Time.fixedDeltaTime;
            GoTime.sprite = GoNum[(int)WentTime];
            if (WentTime < 0)
            {
               Destroy(Go);
               PlayerController.GameState = true;
            }
        }
        
        if (PlayerController.GameState == true)
        {
            time -= Time.fixedDeltaTime;
            if(time <= 0)
            {
                Lose.SetActive(true);
                PlayerController.GameState = false;
                DirectionalLight.GetComponent<AudioSource>().enabled = false;
            }
            if (time < 10)
            {
                TimeNum[0].sprite = Num[(int)time];
                TimeNum[1].enabled = false;
                TimeNum[2].enabled = false;
            }
            if(time >= 10 && time < 100)
            {
                TimeNum[0].sprite = Num[(int)time / 10];
                TimeNum[1].enabled = true;
                TimeNum[1].sprite = Num[(int)time % 10];
                TimeNum[2].enabled = false;
            }
            if(time >= 100 && time < 1000)
            {
                TimeNum[0].sprite = Num[(int)time / 100];
                TimeNum[1].sprite = Num[((int)time % 100) / 10];
                TimeNum[2].enabled = true;
                TimeNum[2].sprite = Num[((int)time % 100) % 10];
            }
        }
    }
}
