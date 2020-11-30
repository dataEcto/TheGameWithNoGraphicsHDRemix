using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    public EndScene theEndingScript;
    // Start is called before the first frame update
    void Start()
    {
        //theEndingScript = GetComponent<EndScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            theEndingScript.theEnd = true;
        }
        Debug.Log("Collide");
    }
}
