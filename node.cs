using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hovercolor;

    public GameObject turret;

    private SpriteRenderer rend;

    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance; //k�saltma yapmak i�in
           
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //Mouse'un �n�nde bir ui eleman� olup olmad���n� kontrol ediyoruz ki istenmeyen t�klamalar olu�mas�n.
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("You can't build there");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //Mouse'un �n�nde bir ui eleman� olup olmad���n� kontrol ediyoruz ki istenmeyen t�klamalar olu�mas�n.
            return;

        if (buildManager.GetTurretToBuild() == null) //Bunu koydu�umuz i�in kullan�c� sadece koymak �zere bir kule se�ti�i zaman mouse'�n durdu�u alan belli edilecek. Aksi takdirde farkl�la�mas�na ra�men t�kland���nda bir kule koyulamazd�.
            return;

        rend.material.color = hovercolor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
