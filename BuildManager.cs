using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;

        }
        instance = this;
    }

    public GameObject MoonTurretPrefab;
    public GameObject RedTurretPrefab;
    public GameObject LaserTurretPrefab;

    private TurretBlueprint turretToBuild;
    public node selectedNode;

    public NodeUI nodeUI;


    public bool CanBuild { get { return turretToBuild != null; } } //Shopa t�klay�p t�klamad���m�z� kontrol ediyoruz
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }//

 

    public void SelectNode (node node)
    {
        if (selectedNode == node)
        {
            selectedNode= node;
            nodeUI.Hide();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }
}

