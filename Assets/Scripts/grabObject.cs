using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabObject : MonoBehaviour
{
    public bool canBeGrabbed, beingGrabbed, positiveDirection;
    public Collider otherCollider;
    public Vector3 lookAtVec;
    public GameObject tipChild;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        canBeGrabbed = false;
        beingGrabbed = false;
        positiveDirection = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canBeGrabbed){

            if(Input.GetKeyDown("e") && !beingGrabbed){
                beingGrabbed = true;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                {
                    tipChild.transform.position = hit.point;
                }
                    

                //this'll be where all the torch grabbing magic happens
                this.gameObject.transform.parent = Camera.main.transform;
            }
            else if (Input.GetKeyDown("e") && beingGrabbed){
                this.gameObject.transform.parent = null;
            }

        }

    }

    public void OnTriggerEnter(Collider collider){

        if (collider.gameObject.tag == "LookCollider"){
            if(collider.gameObject.transform.parent.transform.position.x > this.gameObject.transform.position.x)
            positiveDirection = true;
            else positiveDirection = false;
            canBeGrabbed = true;
            otherCollider = collider;
            tipChild = otherCollider.gameObject.transform.GetChild(0).gameObject;
        }

    }
    public void OnTriggerExit(Collider collider){

        if (collider.gameObject.tag == "LookCollider"){
            canBeGrabbed = false;
            beingGrabbed = false;
            this.gameObject.transform.parent = null;
        }

    }
}
