using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAnimation : MonoBehaviour
{
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
            GetComponent<Animator>().SetTrigger("Down Trigger");
            StartCoroutine(PlayAudio());
        }
    }
    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(0.4f);
        GetComponent<AudioSource>().Play();
    }
}
