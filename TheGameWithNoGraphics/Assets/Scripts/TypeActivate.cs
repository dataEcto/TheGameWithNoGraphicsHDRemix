using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeActivate : MonoBehaviour
{
    public GameObject typingTextObject;

    void Start() {
        //typingTextObject = typingTextObject.GetComponent<GameObject>();
        typingTextObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //Debug.Log("Trigger hit!");
            typingTextObject.SetActive(true);
        }
    }
 
}
