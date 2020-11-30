using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public Animator transistionAnim;

    public string sceneName;

    public bool theEnd;

    void Start()
    {

        theEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (theEnd == true)
        {
            StartCoroutine(LoadScene());
        }
    }
    
    IEnumerator LoadScene()
    {
        transistionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
