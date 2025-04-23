using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake ()
    {
        if(instance != null)
        {
            Debug.Log ("Wiele menadżerów budowy");
            return;
        }
        instance = this;
        
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private GameObject turretToBuild;


    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}
