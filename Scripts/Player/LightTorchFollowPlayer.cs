using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTorchFollowPlayer : MonoBehaviour
{

    //Variables
    public GameObject player;
    public Vector3 yHeight;


    // Start is called before the first frame update
    void Start()
    {
        yHeight = transform.position - player.transform.position;
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + yHeight;
    }
}
