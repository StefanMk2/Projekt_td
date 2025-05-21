using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;
    
    void Start()
    {   
        enemy = GetComponent<Enemy>();
        if (enemy == null)
        {
            Debug.LogError("Enemy component missing!", this);
            enabled = false;
            return;
        }

        // Check if Waypoints are properly initialized
        if (Waypoints.points == null || Waypoints.points.Length == 0)
        {
            Debug.LogError("Waypoints not initialized!", this);
            enabled = false;
            return;
        }

        target = Waypoints.points[0];
    }

    void Update()
    {
        if (target == null || enemy == null)
        {
            Destroy(gameObject); // Safety cleanup
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (Waypoints.points == null || wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        // Directly modify PlayerStats (assuming it's a static class)
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}