using UnityEngine;

public class FireSystem : MonoBehaviour
{
    [SerializeField] GameObject SolSilah;
    [SerializeField] GameObject SagSilah;
    [SerializeField] float damage=10.0f;

    private ParticleSystem sag;
    private ParticleSystem sol;
    

    RaycastHit hit;

    private void Start()
    {
        
        sag = SagSilah.GetComponent<ParticleSystem>();
        sol = SolSilah.GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        Ray();
    }


    public void Ray()
    {
        if(PlayerPrefs.GetInt("toggle") == 1)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                sag.Emit(1);
                sol.Emit(1);
                Shoot();
            }
        } else if (PlayerPrefs.GetInt("toggle") == 0)
        {
            if (ArduinoSerial.valueOfFire == 0)
            {
                sag.Emit(1);
                sol.Emit(1);
                Shoot();
            }
        }
        
        
        
        
    }
    
    private void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hit, 1000))
        {
            TargetHealth targethealth = hit.transform.GetComponent<TargetHealth>();
            if (targethealth != null)
            {
                targethealth.TakeDamage(damage);
            }
        }
        Debug.DrawLine(transform.position, this.transform.position - this.transform.forward * 300, Color.white);
    }    
}
