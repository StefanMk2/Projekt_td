using UnityEngine;

public class wróg : MonoBehaviour
{

    public float speed=10f;
    public int health = 100;
    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;

    void Start ()
    {
        target = droga.punkt[0];
    }

    public void TakeDamage(int amount)
    {
        health -=amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject); 
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<= 0.4f)
        {
            nastepny();
        }
    }

    void nastepny()
    {
        if(wavepointIndex >= droga.punkt.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = droga.punkt[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);

    }


}
