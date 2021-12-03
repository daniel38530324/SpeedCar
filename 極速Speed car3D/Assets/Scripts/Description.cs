using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public GameObject description;
    public GameObject plot1, plot2;
    public AudioClip changeButton,startButton;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetDescription()
    {
        description.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(startButton);
    }
    public void CloseDescription()
    {
        description.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(changeButton);
    }
    public void ShowPlot1()
    {
        plot1.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(changeButton);
    }
    public void ShowPlot2()
    {
        plot2.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(changeButton);
    }
    public void ClosePlot2()
    {
        plot2.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(changeButton);
    }
    public void CloseEveryPlot()
    {
        plot1.SetActive(false);
        plot2.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(changeButton);
    }
}
