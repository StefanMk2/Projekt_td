using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

        public void SelectMissileLauncher ()
    {
        Debug.Log("Missile Launcher  selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
