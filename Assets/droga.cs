using UnityEngine;

public class droga : MonoBehaviour
{

    public static Transform[] punkt;

    void Awake ()
    {
        punkt= new Transform[transform.childCount];
        for (int i = 0; i < punkt.Length; i++)
        {
            punkt[i] = transform.GetChild(i);
        }
    }

}
