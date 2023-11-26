using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int acceleration  { get; set; } 
    public int currentSpeed {get ; set;} 
    public int breaking  { get; set; }
    public int maxSpeed  { get; set; }
    public int deliveriesMade { get; set; }
    public int tipsTotal { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        acceleration = 5;
        breaking = 7;
        currentSpeed = 0; 
        maxSpeed = 50;
        deliveriesMade = 0;
        tipsTotal = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
