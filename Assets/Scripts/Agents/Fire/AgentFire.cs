using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFire : MonoBehaviour
{

    RaycastHit raycastHit;
    [SerializeField] GameObject SolSilah;
    [SerializeField] GameObject SagSilah;

    private ParticleSystem sag;
    private ParticleSystem sol;
    private bool physicsRaycast;

    private void Start()
    {
        sag = SagSilah.GetComponent<ParticleSystem>();
        sol = SolSilah.GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        
    }

    private void HitControlAndFire()
    {
        physicsRaycast = Physics.Raycast(transform.position, transform.forward, out raycastHit, 1000f);
        
        Debug.DrawRay(transform.position, this.transform.position - this.transform.forward * 300, Color.red);
        if (physicsRaycast)
        {
            if (raycastHit.collider.gameObject.tag == "Player")
            {
                sag.Emit(1);
                sol.Emit(1);
            }
        }
    }

}
