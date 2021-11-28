using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    [Header("Points")]
    public Text mortesTexto;
    public Text dnaTexto;
    public Slider slider;

    [Header("Upgrade Button Price")]
    public Text[] upgradeTexto;

    [Header("Upgrade Text Price Count")]
    public Text[] upgradeCountTexto;

    [Header("Upgrade Data")]
    public UpgradesValues upgradeData;

    [Header("Dna Rate Text")]
    public Text dnaRateText;

    private double mortes = 1;
    private double dnaPoints = 4;
    private double deathRate = 0;
    private double dnaRate = 0;

    private double timeLimit = 0;
    private double timeLimitBase = 0;

    private int[] dnaUpgrades = { 0, 0, 0, 0 };
    private double[] dnaUpgradesMulti = { 1.07, 1.15, 1.14, 1.13 };
    private double[] dnaUpgradesPrice = { 4.00, 60.00, 720.00, 8000.00 };
    private int[] dnaUpgradesBasePrice = { 4, 60, 720, 8000 };

    void Start()
    {
        refreshUpgradesPrice();
        setTimeLimit();
        //upgradeData.startValues();
    }

    void Update()
    {
        mortes += deathRate * Time.deltaTime;
        mortesTexto.text = "Deaths: " + mortes.ToString("F0");

        timeLimit -= 10 * Time.deltaTime;

        dnaPoints += dnaRate * Time.deltaTime;
        dnaTexto.text = "DNA Points: " + dnaPoints.ToString("F0");

        slider.value = (float)(timeLimit / timeLimitBase);

        if(mortes >= 7833203717)
        {
            SceneManager.LoadScene("ZerandoOJogo");
        }

        if (timeLimit <= 0)
        {
            SceneManager.LoadScene("UpgradesScene");
            upgradeData.addPoints(1 + (int)mortes / 100);
        }
    }

    public void upgradeDNA(int upgradeIndex)
    {
        if (dnaPoints < dnaUpgradesPrice[upgradeIndex] || upgradeData.unlockUpgrades[upgradeIndex] != 1) return;
        dnaPoints -= dnaUpgradesPrice[upgradeIndex];
        dnaUpgrades[upgradeIndex]++;
        dnaUpgradesPrice[upgradeIndex] = dnaUpgradesBasePrice[upgradeIndex] * (Mathf.Pow((float)dnaUpgradesMulti[upgradeIndex], dnaUpgrades[upgradeIndex]));
        refreshDnaRate();
        refreshUpgradesPrice();
    }

    private void refreshDnaRate()
    {
        dnaRate = 0;
        int soma = 0;
        double multi = 1.00f;

        for(int i = 0; i < dnaUpgrades.Length; i++)
        {
            if (dnaUpgrades[i] == 0) continue;
            dnaRate += 1.32f * dnaUpgrades[i];
        }

        for (int i = 0; i < upgradeData.upgrades.Length; i++)
        {
            multi += upgradeData.upgradesBuff[i] * upgradeData.upgrades[i];
            soma += upgradeData.upgrades[i];
        }

        deathRate = dnaRate / 7 * 3f;
        dnaRate *= multi;

        dnaRateText.text = "DNA Rate: " + dnaRate.ToString("F2");
    }

    private void refreshUpgradesPrice()
    {
        for(int i = 0; i < upgradeTexto.Length; i++)
        {
            if(upgradeData.unlockUpgrades[i] == 1)
            {
                upgradeTexto[i].text = dnaUpgradesPrice[i].ToString("F2") + " POINTS";
            }
            else
            {
                upgradeTexto[i].text = "Locked";
            }
        }
        
        for(int i = 0; i < upgradeCountTexto.Length; i++)
        {
            upgradeCountTexto[i].text = upgradeData.upgradeNames[i] + ": " + dnaUpgrades[i].ToString();
        }
    }

    [Header("Config Time Limit")]
    public int firstTime = 50;
    public int upgradesTimeMulti = 100;

    private void setTimeLimit()
    {
        int soma = 0;
        for (int i = 0; i < upgradeData.upgrades.Length; i++) soma += upgradeData.upgrades[i];
        timeLimitBase = firstTime + upgradesTimeMulti * soma;
        timeLimit = timeLimitBase;
    }
}
