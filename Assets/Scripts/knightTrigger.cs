using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightTrigger : MonoBehaviour
{
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.gameObject.GetComponent<BoxCollider>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider){

        if (collider.gameObject.tag == "Player"){
            this.gameObject.transform.parent.gameObject.GetComponent<knightMovement>().beginMovement = true;
            Debug.Log("hit trigger");
        }

    }
}
