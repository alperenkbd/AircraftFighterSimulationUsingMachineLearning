using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FireSystem : MonoBehaviour
{

    public static AudioClip FireSound;

    [SerializeField] GameObject Bullet;
    [SerializeField] Material LineRenMat;
    [SerializeField] GameObject SolSilah;
    [SerializeField] GameObject SagSilah;

    private ParticleSystem sag;
    private ParticleSystem sol;
    private LineRenderer SphereLineRenderer;
    private GameObject sphere;
    private List<Transform> sphereTr;
    

    RaycastHit hit;

    private void Start()
    {
        
        sag = SagSilah.GetComponent<ParticleSystem>();
        sol = SolSilah.GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        //AlternativeFire();
        Ray();
    }

    

    /*private void AlternativeFire()
    {
 

        if (Input.GetKey(KeyCode.Mouse0)){

            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Rigidbody BulletRb = sphere.AddComponent<Rigidbody>();
            Color c1 = Color.yellow;
            float StartWidth = 0.1f, EndWidth = 0.05f;

            sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.5f);
            sphere.transform.position = transform.position;
            sphere.AddComponent<SphereCollider>();
            SphereLineRenderer = sphere.AddComponent<LineRenderer>();
            SphereLineRenderer.material = LineRenMat;
            SphereLineRenderer.material.color = c1;
            SphereLineRenderer.startWidth = StartWidth;
            SphereLineRenderer.endWidth = EndWidth;
            BulletRb.velocity = new Vector3(0, 0, 700);
            sphereTr.Add(sphere.transform);
            SphereLineRenderer.SetPosition(0, sphere.transform.position);
            
        }
        
        SphereLineRenderer.SetPosition(1, sphere.transform.position);
        
    }*/



    public void Ray()
    {
        
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sag.Emit(1);
            sol.Emit(1);
        }
        
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        Debug.DrawLine(transform.position, this.transform.position-this.transform.forward * 300, Color.white);
    }
    
    
}
