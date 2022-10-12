using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderClimb : MonoBehaviour
{
    public bool climbing;
    public GameObject climber;
    // Start is called before the first frame update
    void Start()
    {
        climbing = false;
        climber = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(climbing && climber != null && climber.transform.parent == this.gameObject){
            if(Input.GetKey("w"))
            climber.transform.Translate(0,0,-.25f);
        }
    }

    public void OnCollisionEnter(Collision collision){
        climber = collision.gameObject;
        //collision.gameObject.transform.parent = this.gameObject.transform;
        //climber.transform.eulerAngles = new Vector3()
        //climber.GetComponent<Rigidbody>().isKinematic = true;
    }
}
