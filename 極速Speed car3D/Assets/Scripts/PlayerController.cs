using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool GameState = false;
    public float MaxSpeed = 25;
    public float Speed = 37.7f;
    public GameObject[] Steam;
    public GameObject CarSound;
    public GameObject CarCrach;
    public GameObject WaterFall;
    public GameObject FirstCamera;
    public GameObject Light;

    private bool FirstState = true;
    private float Key = 0;
    private Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {
        GameState = false;
        rd = GetComponent<Rigidbody>();
        FirstCamera.SetActive(false);
        FirstState = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameState == true)
        {
            
            if (rd.velocity.z <= MaxSpeed)
            { 
                rd.AddForce(transform.forward * Key); 
            }
            
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Key = Speed;
                Steam[0].SetActive(true);
                Steam[1].SetActive(true);
                CarSound.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Key = 0;
                Steam[0].SetActive(false);
                Steam[1].SetActive(false);
                CarSound.SetActive(false);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Key = -7;
            }
            
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -1, 0);
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 1, 0);
            }
            if(Vector3.Distance(WaterFall.transform.position,transform.position)<200)
            {
                WaterFall.GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                WaterFall.GetComponent<AudioSource>().enabled = false;
            }
            if (FirstState == true && Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                FirstCamera.SetActive(true);
                FirstState = false;
            }
            else if (FirstState == false && Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                FirstCamera.SetActive(false);
                FirstState = true;
            }
        }
        else
        {
            Steam[0].SetActive(false);
            Steam[1].SetActive(false);
            CarSound.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "AI")
        {
            CarCrach.GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Clock")
        {
            Destroy(other.gameObject);
            GameDirector.time += 30;
            GetComponent<AudioSource>().Play();
            Light.GetComponent<ParticleSystem>().Play();
        }
    }
}
