using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;
    public GameObject DirectionalLight;
   
    private int PlayerRound = 0;
    private int AIRound = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRound = 0;
        AIRound = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerRound == 10)
        {
            Win.SetActive(true);
            PlayerController.GameState = false;
            DirectionalLight.GetComponent<AudioSource>().enabled = false;
        }
        else if (AIRound == 25)
        {
            Lose.SetActive(true);
            PlayerController.GameState = false;
            DirectionalLight.GetComponent<AudioSource>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PlayerRound += 1;
        
        if (other.gameObject.tag == "AI")
            AIRound += 1;
    }
}
