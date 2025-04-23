using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret ()
    {
        Debug.Log("Turret selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

        public void PurchaseMissileLauncher ()
    {
        Debug.Log("Missile Launcher  selected");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
