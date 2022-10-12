using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDetectorDetectionScript : MonoBehaviour
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
        Debug.Log(collider.gameObject.tag);
        if(collider.gameObject.tag == "water"){
            //stuff for dousing flames
            this.gameObject.transform.parent.GetComponent<particleControl>().douse = true;
            Debug.Log("Setting douse true \n    - sphere");
        }
        else if (collider.gameObject.tag == "fire"){
            //stuff for checking unlit flame and reigniting it
            this.gameObject.transform.parent.GetComponent<particleControl>().light = true;
        }
    }
}
