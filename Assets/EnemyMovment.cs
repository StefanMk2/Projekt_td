using UnityEngine;


[RequireComponent(typeof(wróg))]
public class EnemyMovment : MonoBehaviour
{
    private Transform target;
        private int wavepointIndex = 0;
        private wróg enemy;
        void Start ()
        {   
            enemy = GetComponent<wróg>();
            target = droga.punkt[0];
        }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*enemy.speed*Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<= 0.4f)
        {
            nastepny();
        }

        enemy.speed = enemy.startSpeed;
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
