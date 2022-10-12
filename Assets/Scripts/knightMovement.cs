using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightMovement : MonoBehaviour
{

    public bool beginMovement, oneTimeActivation;
    public AnimationClip clip;

    public GameObject[] movementMarkers;

    // Start is called before the first frame update
    void Start()
    {
           beginMovement = false;
           oneTimeActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginMovement && !oneTimeActivation){
            oneTimeActivation = true;

            StartCoroutine(beginMovementCoroutine());
        }
    }

    IEnumerator beginMovementCoroutine(){

        this.gameObject.GetComponent<Animation>().clip = clip;
        foreach (AnimationState state in this.gameObject.GetComponent<Animation>())
        {
            state.speed = 1.025f;
        }
        this.gameObject.GetComponent<Animation>().clip.wrapMode = WrapMode.Loop;
        this.gameObject.GetComponent<Animation>().Play();

        int steps;
        Vector2 dir;
        float dot;
        //scripted beginning movement
        foreach (GameObject destination in movementMarkers){
             steps = -1;
                while(this.gameObject.transform.position != destination.transform.position){
                    if (steps <=22){                    
                    this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 5f);
                    yield return new WaitForSeconds(.03f);
                    }
                    else if(steps <= 24) {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 10f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps <=32){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 20f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=42){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 1.25f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=54){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 5f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=57){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 10f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=63){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 20f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=77){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 1.25f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=85){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 5f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=90){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 10f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=99){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 20f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=103){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 1.25f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=117){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 5f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=121){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 10f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else if (steps<=129){
                        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, Time.deltaTime * 20f);
                        yield return new WaitForSeconds(.03f);
                    }
                    else 
                        steps = -1;
                    steps++;


                    //rotation towards the destination
                    /*dir = new Vector2(destination.transform.position.x - this.gameObject.transform.position.x, destination.transform.position.z - this.gameObject.transform.position.z).normalized;
                    dot = Vector3.Dot(dir, new Vector2(this.gameObject.transform.forward.x, this.gameObject.transform.forward.z));
                    if(dot != 1){
                        Debug.Log("rotating");
                        Vector3.RotateTowards(this.gameObject.transform.forward, new Vector3(dir.x, this.gameObject.transform.position.y, dir.y), 15f, 100);
                    }
                    */
                    if (Vector3.Distance(this.gameObject.transform.position, destination.transform.position) >=3)
                    this.gameObject.transform.LookAt(new Vector3(destination.transform.position.x, this.gameObject.transform.position.y, destination.transform.position.z));
                }
        }
        yield break;

    }


}
