using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartCaller : MonoBehaviour
{
    public Flowchart flowchartObject;
    public string BlockToExecute;
    
    void Start()
    {
        BlockToExecute = this.gameObject.name;
    }

    public void DoInteraction()
    {
        flowchartObject.ExecuteBlock(BlockToExecute);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoInteraction();
        }
    }
}
