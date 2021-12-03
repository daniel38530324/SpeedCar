using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_Player : MonoBehaviour
{
    public GameObject[] Steam;
    public GameObject Bullet;
    public GameObject Point;
    public GameObject Explosion;
    public GameObject ExplosionPoint;
    public GameObject Boss;
    public GameObject Ball;
    public GameObject CarCollet, CarHurt;

    private Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        Steam[0].SetActive(true);
        Steam[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rd.AddForce(transform.right * -37);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rd.AddForce(transform.right * 37);
        }

        if (Level4Director.CatchBullet > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Bullet, Point.transform.position, Point.transform.rotation);
                Point.GetComponent<AudioSource>().Play();
                Level4Director.CatchBullet -= 1;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crack")
        {
            Level4Director.Hp -= 1;
            CarHurt.GetComponent<AudioSource>().Play();
        }
        if(other.tag == "healpack")
        {
            Level4Director.Hp += 1;
            Destroy(other.gameObject);
            CarCollet.GetComponent<AudioSource>().Play();
        }
        if(other.tag == "CatchBullet")
        {
            Level4Director.CatchBullet += 3;
            Destroy(other.gameObject);
            CarCollet.GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Blaster")
        {
            Level4Director.Hp -= 3;
            CarHurt.GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {
            Ball.SetActive(true);
            StartCoroutine(bone());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Stone")
        {
            Level4Director.Hp -= 1;
            CarHurt.GetComponent<AudioSource>().Play();
        }
    }
    IEnumerator  bone()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Explosion, ExplosionPoint.transform.position, ExplosionPoint.transform.rotation);
        Destroy(Boss);
    }
}

