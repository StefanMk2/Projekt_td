using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{   
    public Color  hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
     [HideInInspector]
    public TurretBlueprint turretBlueprint;
     [HideInInspector]
     public bool isUpgraded = false;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager =BuildManager.instance;
    }


    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;

       BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret (TurretBlueprint blueprint)
    {
         if ( PlayerStats.Money < blueprint.cost)
        {
            Debug.Log ("Nie wystarczające fundusze");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

       GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
       turret = _turret;

        turretBlueprint = blueprint;

       GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

       Debug.Log("Wieża zakupiona.");
    }

    public void UpgradeTurret()
    {
            if ( PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log ("Nie wystarczające fundusze na ulepszenie");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

       GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
       turret = _turret;

       GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

       Debug.Log("Wieża ulepszona. ");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter ()
    {
                    Debug.Log("Kursor nad Nodem");

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

            if (buildManager.HasMoney)
            {
                rend.material.color = hoverColor;
            } else
            {
                rend.material.color = notEnoughMoneyColor;
            }

        
    }

    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }


}
