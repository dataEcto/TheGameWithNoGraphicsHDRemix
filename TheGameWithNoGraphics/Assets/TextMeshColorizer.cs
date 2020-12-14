using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshColorizer : MonoBehaviour
{
    public TextMesh textComp;
    // Start is called before the first frame update
    void Start()
    {
        textComp = this.GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
