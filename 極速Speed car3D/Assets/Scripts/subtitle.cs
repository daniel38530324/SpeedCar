using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class subtitle : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if(transform.position.y >= 2596)
        {
            SceneManager.LoadScene("Start");
        }
    }
}
