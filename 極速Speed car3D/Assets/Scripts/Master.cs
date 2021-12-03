using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    public static bool Level4State = false;

    public GameObject UI;
    public GameObject BossCamera;
    public GameObject CarCamera;
    public GameObject Boss,Boss2;
    public GameObject Car;
    public GameObject Rock;
    public GameObject Terrain;
    public GameObject Rock1;
    public GameObject Lose;

    private bool BossState = true;
    private bool UIState = true;
    // Start is called before the first frame update
    void Start()
    {
        Level4State = false;
        BossState = true;
        UIState = true;
        Rock1.SetActive(false);
        Lose.SetActive(false);
        Invoke("CarSound",7);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Level4State == false)
        {
            UI.SetActive(false);
            Rock.GetComponent<ConstantForce>().enabled = false;
        }
        else if(Level4State == true)
        {
            if(UIState == true)
            {
                UI.SetActive(true);
                UIState = false;
            }
            if (BossState == true)
            {
                Boss.GetComponent<BossController>().enabled = true;
            }
               
            if (Rock.transform.position.z > -178)
            {
                Rock.GetComponent<ConstantForce>().enabled = true;
            }
            else if(Rock.transform.position.z < -178)
            {
                Rock.SetActive(false);
            }
        }

        if(Car.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Car2"))
        {
            Car.GetComponent<Animator>().enabled = false;
            Level4State = true;
        }
        if (Car.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Car4"))
        {
            SceneManager.LoadScene("Win");
        }
        if (Level4Director.BossHp <= 0)
        {
            Destroy(UI);
            Rock1.SetActive(true);
            BossCamera.GetComponent<Animator>().SetTrigger("EndTrigger");
            Terrain.GetComponent<Animator>().SetTrigger("TerrainTrigger");
            Destroy(Boss);
            if (BossState == true)
            {
                Boss2.SetActive(true);
                BossState = false;
            }
            Car.GetComponent<Animator>().enabled = true;
            Car.GetComponent<Animator>().SetTrigger("EndTrigger");
            CarCamera.SetActive(false);
            Level4Director.CameraState = true;
        }
        if(Level4Director.Hp <= 0)
        {
            Lose.SetActive(true);
            Level4State = false;
            Terrain.GetComponent<Animator>().SetTrigger("TerrainTrigger");
            Destroy(Boss);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("Level4");
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Start");
    }
    private void CarSound()
    {
        Car.GetComponent<AudioSource>().Play();
    }
}
