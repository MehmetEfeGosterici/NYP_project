using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public int startMoney = 1000;

    private void Start() // E�er gameMasterdan fiyat de�i�tirmek istersen start� update ile de�i�tir.
    {
        Money = startMoney;
    }



}
