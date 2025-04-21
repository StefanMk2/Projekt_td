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

        public void PurchaseAnotherTurret ()
    {
        Debug.Log("Turret other selected");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}
