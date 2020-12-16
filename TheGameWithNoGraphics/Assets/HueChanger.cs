using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueChanger : MonoBehaviour
{
    public bool isMainWall;
    public float speed = 0.5f;
    public Renderer comp;
    [SerializeField] private int currHue;
    float startTime;

    float timeLeft;
    [SerializeField]Color targetColor;

    void Start()
    {   
        startTime = Time.time;
        comp = gameObject.GetComponent<Renderer>();
        if (isMainWall == true) {
            currHue = Random.Range(0, 360);
        }
    }

    void Update() {
        /*
        float t = (Time.time - startTime) * speed;
            if (currHue <= 360) {
               //comp.material.color = Color.HSVToRGB(currHue / 360, 1.0f, 1.0f); ;
               comp.material.SetColor("_Color", Color.HSVToRGB(currHue / 360, 1.0f, 1.0f));
               currHue += 1;
            } else {
                currHue = 0;
                comp.material.SetColor("_Color", Color.HSVToRGB(currHue / 360, 1.0f, 1.0f));
                currHue += 1;
            }
        */
        if (timeLeft <= Time.deltaTime) {
            // transition complete
            // assign the target color
            comp.material.color = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.0f;
        } else {
            // transition in progress
            // calculate interpolated color
            comp.material.color = Color.Lerp(comp.material.color, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }
}
