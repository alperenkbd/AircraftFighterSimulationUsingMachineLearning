using UnityEngine;

public class TargetHealth : MonoBehaviour
{
    public AudioSource blastSource;
    public AudioClip blastClip;
    public float health = 50.0f;
    public GameObject explodeEffect;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject);
        GameObject blastEffect = Instantiate(explodeEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(blastEffect, 3);
        blastSource.PlayOneShot(blastClip);
    }
}
