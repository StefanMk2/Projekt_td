using UnityEngine;

public class wróg : MonoBehaviour
{

    public float speed=10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start ()
    {
        target = droga.punkt[0];
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
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = droga.punkt[wavepointIndex];
    }

}
