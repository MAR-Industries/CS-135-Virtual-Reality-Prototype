using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleControl : MonoBehaviour
{
    public bool douse, light;
    public ParticleSystem  particleSys;
    // Start is called before the first frame update
    void Start()
    {
        douse = false; 
        light = false;
        particleSys = this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(douse){
            if (!particleSys.isPaused){
                particleSys.Stop();
                Debug.Log("pausing particle sys\n     - particleSys");
                //other stuff for dousing sound effect
                this.gameObject.transform.GetChild(2).GetComponent<Light>().enabled = false;
                this.gameObject.transform.GetChild(3).GetComponent<Light>().enabled = false;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            douse = false;
        }
        else if (light){
            if(!particleSys.isPlaying){
                particleSys.Play();
                //whatever else I come up with for this will go here, probably
                this.gameObject.transform.GetChild(2).GetComponent<Light>().enabled = true;
                this.gameObject.transform.GetChild(3).GetComponent<Light>().enabled = true;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            light = false;
        }
        
    }
}
