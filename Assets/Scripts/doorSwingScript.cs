using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSwingScript : MonoBehaviour
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
                    

                //lookAtVec = otherCollider.gameObject.GetComponent<Collider>().ClosestPointOnBounds(this.gameObject.transform.position);

                //lookAtVec = new Vector3(otherCollider.gameObject.transform.GetChild(0).transform.position.x, this.gameObject.transform.position.y, 
                //                otherCollider.gameObject.transform.GetChild(0).transform.position.z);
                //lookAtVec = new Vector3(lookAtVec[0], this.gameObject.transform.position.y, 
                //            lookAtVec[2]);

                //tipChild.transform.position = lookAtVec;
            }
                else if (Input.GetKeyDown("e") && beingGrabbed) beingGrabbed = false;

        }

        if(beingGrabbed){ //updates for door rotation when being grabbed; dependent on player position, should be following player's line of sight

            this.gameObject.transform.parent.gameObject.transform.LookAt(new Vector3(tipChild.transform.position.x, this.gameObject.transform.position.y, tipChild.transform.position.z));

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
        }

    }
}
