using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public float px = 0, py = 0, pz = 0;
    public float rx = 0, ry = 0, rz = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(px, py, pz);
            other.gameObject.transform.rotation = Quaternion.Euler(rx, ry, rz);
        }
    }
}
