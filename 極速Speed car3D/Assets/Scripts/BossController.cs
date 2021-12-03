using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject rock;
    public GameObject Point, Point1, Point2;
    public GameObject BossBullet;
    public GameObject Magic;
    public GameObject Blaster;
    public GameObject stone1 ,stone2, stone3;
    public GameObject hard1, hard2, hard3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 5f, 10f);
        InvokeRepeating("Rock", 0f, 3f);
        InvokeRepeating("Magi", 17f, 25f);
        InvokeRepeating("Stone", 6f, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void shoot()
    {
        
        Instantiate(BossBullet, Point.transform.position, Point.transform.rotation);
        Instantiate(BossBullet, Point1.transform.position, Point1.transform.rotation);
        Instantiate(BossBullet, Point2.transform.position, Point2.transform.rotation);
    }
    private void Rock()
    {
        Instantiate(rock,new Vector3(207.3f,29,319.3f),Quaternion.Euler(0,0,0));
    }
    void Magi()
    {
        Instantiate(Magic, new Vector3(252.1f, 40.3f, 136.3f), Quaternion.Euler(-15.962f, -14.92f, -0.069f));
        StartCoroutine(Laster());
    }
    IEnumerator Laster()
    {
        yield return new WaitForSeconds(2);
        Blaster.SetActive(true);
        yield return new WaitForSeconds(1f);
        Blaster.SetActive(false);
    }
    private void Stone()
    {
        Instantiate(stone1,hard1.transform.position,hard1.transform.rotation);
        Instantiate(stone2, hard2.transform.position, hard2.transform.rotation);
        Instantiate(stone3, hard3.transform.position, hard3.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            GetComponent<AudioSource>().Play();
    }

}
