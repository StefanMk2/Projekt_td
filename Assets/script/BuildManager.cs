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

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if ( PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log ("Nie wystarczające fundusze");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

       GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
       node.turret = turret;

       Debug.Log("Wieża zakupiona. Pozostałe fundusze: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
