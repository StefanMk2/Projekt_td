using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

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

        public void SelectLaserBeamer ()
    {
        Debug.Log("Laser Beamer selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
