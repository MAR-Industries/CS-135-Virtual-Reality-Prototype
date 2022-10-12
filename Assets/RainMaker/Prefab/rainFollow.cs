using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.RainMaker
{
public class rainFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player")
            this.gameObject.transform.parent.gameObject.GetComponent<RainScript>().FollowCamera = true;
            this.gameObject.transform.parent.gameObject.GetComponent<RainScript>().RainIntensity = 1f;
    }
}
}