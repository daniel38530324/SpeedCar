using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Master : MonoBehaviour
{
    public GameObject MasterCamera;
    public GameObject Go;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        Go.SetActive(false);
        UI.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(MasterCamera.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Go.SetActive(true);
            UI.SetActive(true);
            MasterCamera.SetActive(false);
        }
    }
}
