using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textFacePlayer : MonoBehaviour
{
    public GameObject player;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            transform.LookAt(target);
        }
    }
}
