using System.Collections;
using System.Collections.Generic;
using MoonSharp.Interpreter.Debugging;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    public bool startEnding = false;
    public GameObject player;
    public PlayerMove playerMoveScript;
    public float flySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (startEnding == true)
        {
            Debug.Log("begin ending");
            player.transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
            playerMoveScript.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            startEnding = true;
        }
       
    }
}
