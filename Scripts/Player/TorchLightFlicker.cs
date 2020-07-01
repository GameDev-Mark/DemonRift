using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightFlicker : MonoBehaviour
{
    //Variables
    public new Light light;   //  light attatched
    public float minIntensity;   // min intensity
    public float maxIntensity;  // max intensity
    public int smoothing;  // smoothing handling

    Queue<float> smoothQueue;  
    float lastSum = 0;  


    // resets randomness of lights
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }


    // unitys start function
    void Start()
    {
        //minIntensity = 1f;
        //maxIntensity = 6f;
        //smoothing = 45;

        smoothQueue = new Queue<float>(smoothing);
        if(light == null)
        {
            light = GetComponent<Light>();
        }    
    }

    
    // unitys update function
    void Update()
    {
        if (light == null)
        return;

        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        light.intensity = lastSum / (float)smoothQueue.Count; 
    }
}
