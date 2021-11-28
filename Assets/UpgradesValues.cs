using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesData", menuName = "UpgradesData")]
public class UpgradesValues : ScriptableObject
{
    // Upgrades (depois de perder)
    public int[] upgrades = { 0, 0, 0, 0 };
    public double[] upgradesPrice = { 1, 10, 20, 30 };
    public int[] upgradesBasePrice = { 1, 10, 20, 30 };
    public double[] upgradesPriceMulti = { 1.07, 1.15, 1.14, 1.13 };
    public double[] upgradesBuff = { 0.05, 0.20, 0.50, 1 };

    // Perks
    public string[] upgradeNames =
    {
        "Viral Infection",
        "Hearth Attack",
        "Não sei",
        "Pensa amigão"
    };

    // Unlock base upgrades
    public int[] unlockUpgrades = { 1, 1, 0, 0 };
    public int[] unlockUpgradesPrice = { 0, 0, 100, 1000 };

    // Pontos ganhos depois de perder (diferente de DNA points)
    public int points = 0;

    public void addUpgrades(int index)
    {
        upgrades[index]++;
    }

    public int[] getUpgrades()
    {
        return upgrades;
    }

    public void addPoints(int value)
    {
        points += value;
    }

    public int getPoints()
    {
        return points;
    }
}
