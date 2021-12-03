using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject load;
    public Slider slider;
    public Text text;
    public AudioClip startButton;
    public AudioClip changeButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        load.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;
        while(operation.isDone != true)
        {
            slider.value = operation.progress;
            text.text = operation.progress*100 + "%";
            if(operation.progress >= 0.9f)
            {
                slider.value = 1;
                text.text = "按任意鍵繼續...";
                if(Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void StartButton()
    {
        GetComponent<AudioSource>().PlayOneShot(startButton);
    }
    public void ChangeButton()
    {
        GetComponent<AudioSource>().PlayOneShot(changeButton);
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}
