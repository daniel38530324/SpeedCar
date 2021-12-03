using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4Director : MonoBehaviour
{
    public static int Hp = 10, BossHp = 10, CatchBullet = 0;
    public static bool CameraState = true; 

    public Image hp, bosshp;
    public Sprite[] texture1, texture2;
    public GameObject Healpack;
    public GameObject bullet;
    public GameObject CarCamera;

    public Text total;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 10;
        BossHp = 10;
        CatchBullet = 0;
        InvokeRepeating("Heal", 10, 10);
        InvokeRepeating("Catch", 13, 13);
        CameraState = true;
        CarCamera.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Playerhp();

        if (CameraState == true && Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            CarCamera.SetActive(true);
            CameraState = false;
        }
        else if (CameraState == false && Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            CarCamera.SetActive(false);
            CameraState = true;
        }
    }
    void Playerhp()
    {
        if (Hp > 10)
            Hp = 10;
        if (Hp == 10)
            hp.sprite = texture1[9];
        if (Hp == 9)
            hp.sprite = texture1[8];
        if (Hp == 8)
            hp.sprite = texture1[7];
        if (Hp == 7)
            hp.sprite = texture1[6];
        if (Hp == 6)
            hp.sprite = texture1[5];
        if (Hp == 5)
            hp.sprite = texture1[4];
        if (Hp == 4)
            hp.sprite = texture1[3];
        if (Hp == 3)
            hp.sprite = texture1[2];
        if (Hp == 2)
            hp.sprite = texture1[1];
        if (Hp == 1)
            hp.sprite = texture1[0];
        if (Hp == 0)
            hp.enabled = false;

        if (BossHp == 10)
            bosshp.sprite = texture2[9];
        if (BossHp == 9)
        {
            bosshp.sprite = texture2[8];
        }
        if (BossHp == 8)
        {
            bosshp.sprite = texture2[7];
        }
        if (BossHp == 7)
        {
            bosshp.sprite = texture2[6];
        }
        if (BossHp == 6)
        {
            bosshp.sprite = texture2[5];
        }
        if (BossHp == 5)
        {
            bosshp.sprite = texture2[4];
        }
        if (BossHp == 4)
        {
            bosshp.sprite = texture2[3];
        }
        if (BossHp == 3)
        {
            bosshp.sprite = texture2[2];
        }
        if (BossHp == 2)
        {
            bosshp.sprite = texture2[1];
        }
        if (BossHp == 1)
        {
            bosshp.sprite = texture2[0];
        }
        if (BossHp == 0)
            bosshp.enabled = false;
         
        total.text = $"X {CatchBullet}";

    }
    void Heal()
    {
        int x = Random.Range(245,265);
        Instantiate(Healpack, new Vector3(x, 1.34f, 319.3f), Quaternion.Euler(0, 0, 0));
    }
    void Catch()
    {
        int y = Random.Range(245, 265);
        Instantiate(bullet, new Vector3(y, 1.34f, 319.3f), Quaternion.Euler(0, 0, 0));
    }

}
