using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrack : MonoBehaviour
{
    public float destroytime = 5;
    public float speed = -70;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroytime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
