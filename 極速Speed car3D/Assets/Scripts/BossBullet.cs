using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject BossCrack;
    public GameObject Goal, Goal1, Goal2;
    public float speed = 70;

    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(1, 4);
        if(num == 1 )
            distance = (transform.position - Goal.transform.position).normalized;
        else if(num == 2)
            distance = (transform.position - Goal1.transform.position).normalized;
        else if(num == 3)
            distance = (transform.position - Goal2.transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(distance*speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Terrain")
        {
            Instantiate(BossCrack, new Vector3(transform.position.x,0.22f,transform.position.z), Quaternion.Euler(0,0,0));
            Destroy(gameObject);
        }
    }
    
}
