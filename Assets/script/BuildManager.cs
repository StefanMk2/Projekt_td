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

    public GameObject buildEffect;
    public GameObject sellEffect;
    private TurretBlueprint turretToBuild;
    private Node selectNode;
    
    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode (Node node)
    {
        if (selectNode == node)
        {
            DeselectNode();
            return;
        }
        selectNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
