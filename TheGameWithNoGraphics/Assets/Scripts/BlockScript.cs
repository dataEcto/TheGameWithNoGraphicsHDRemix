using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BlockScript : MonoBehaviour
{
    // This script utilizes fungus to delete a blocking wall after the player explores the two rooms in a hub.
    //to do that, each room has a script that calls for the flowchart to set it to true. 
    //if both are true, then the wall begones.

    public Flowchart _flowchart;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (_flowchart.GetBooleanVariable("art") == true && _flowchart.GetBooleanVariable("code") == true)
        {
            _flowchart.ExecuteBlock("Hub 1 Block");
            
            if (_flowchart.GetBooleanVariable("rainbow") == true && _flowchart.GetBooleanVariable("pop") == true)
            {
                _flowchart.ExecuteBlock("Hub 2 Block");
                
                if (_flowchart.GetBooleanVariable("courage") == true && _flowchart.GetBooleanVariable("anxiety") == true)
                {
                    _flowchart.ExecuteBlock("Hub 3 Block");
                }
            }
        }
        
     
      
        
     


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.gameObject.tag == "art")
            {
                _flowchart.SetBooleanVariable("art",true);
                Debug.Log("Art set to true");
            }
            
            if (this.gameObject.tag == "code")
            {
                _flowchart.SetBooleanVariable("code",true);
                Debug.Log("Code set to true");
            }
            
            if (this.gameObject.tag == "rainbow")
            {
                _flowchart.SetBooleanVariable("rainbow",true);
                Debug.Log("Rainbow set to true");
            }
            
            if (this.gameObject.tag == "pop")
            {
                _flowchart.SetBooleanVariable("pop",true);
                Debug.Log("pop set to true");
            }
            
            if (this.gameObject.tag == "courage")
            {
                _flowchart.SetBooleanVariable("courage",true);
                Debug.Log("courage set to true");
            }
            
            if (this.gameObject.tag == "anxiety")
            {
                _flowchart.SetBooleanVariable("anxiety",true);
                Debug.Log("anxiety set to true");
            }

    
        }
    }
}
