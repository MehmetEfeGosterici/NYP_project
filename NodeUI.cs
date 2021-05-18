using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private node target;

    public void SetTarget (node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); //target.transform.position kullanm�yoruz ��nk� UI'�n kulenin i�inde de�il �st�ne yer almas�n� istiyoruz

        if (!target.isUpgraded)
        {
            upgradeCost.text = "UPGRADE COST : " + target.turretBlueprint.upgradeCost + " GOLD";
            upgradeButton.interactable = true;
        }else
        {
            //upgradeCost.text = "Maxed out"; (e�er pop-up'�n �st�ne koyacak olursak bunu kullanaca��z)
            upgradeButton.interactable = false;
        }

        sellAmount.text = "SELL COST : " + target.turretBlueprint.GetSellAmount() + " GOLD" ; 

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
