using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistions : MonoBehaviour
{

    public Animator transistionAnim;

    public string sceneName;
   
   

    
    void Update()
    {
        
        Scene scene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadScene());
        }

        if (scene.name == "4 Ending" && Input.GetKeyUp(KeyCode.Escape))
        {
            QuitGame();
        }

    }

    IEnumerator LoadScene()
    {
        transistionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
    
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    
    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }
}
