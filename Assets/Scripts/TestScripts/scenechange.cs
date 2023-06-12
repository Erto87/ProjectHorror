using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene("JuhoTestScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("juhoscene");
            SceneManager.LoadScene("JuhoTestScene");
        }
    }
    public void Credits()
    {
        credits.SetActive(true);
    }
    public void ReturnMenu()
    {
        credits.SetActive(false);
    }
}
