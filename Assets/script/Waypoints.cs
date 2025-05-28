using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static Transform[] points;

    void Awake() {
        if (points == null || points.Length == 0) {
            points = new Transform[transform.childCount];
            for (int i = 0; i < points.Length; i++) {
                points[i] = transform.GetChild(i);
            }
        }
    }

    // Add this to ensure initialization
    void OnEnable() {
        Awake();
    }
}