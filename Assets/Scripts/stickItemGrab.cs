using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickItemGrab : MonoBehaviour
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
                this.gameObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
                this.gameObject.transform.eulerAngles = new Vector3(0,0,-90);
                this.gameObject.transform.parent = Camera.main.transform;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                this.gameObject.transform.localPosition = new Vector3(.9f, .3f, .73f);
                this.gameObject.transform.localEulerAngles = new Vector3(11.8f,-68.5f,-172.8f);
            }

        }

        if(beingGrabbed){ //updates for door rotation when being grabbed; dependent on player position, should be following player's line of sight

            if (Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.Mouse0)){
                //moving item parallel to camera view
            } 
            else if (Input.GetKey(KeyCode.Tab) && Input.GetKeyDown(KeyCode.Mouse1)){
                beingGrabbed = false;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
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
        }

    }
}
