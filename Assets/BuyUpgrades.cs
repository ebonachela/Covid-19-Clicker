using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyUpgrades : MonoBehaviour
{
    [Header("Upgrade Data")]
    public UpgradesValues upgradeData;

    [Header("Points Text")]
    public Text pointsText;

    [Header("Price Text")]
    public Text[] upgradePriceText;

    [Header("Upgrade Name Text")]
    public Text[] upgradeNameText;

    [Header("Unlock Perks Text")]
    public Text[] unlockUpgradeText;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "Points: " + upgradeData.getPoints().ToString();

        updatePrices();
        updateNames();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyUpgrade(int index)
    {
        if (upgradeData.points < upgradeData.upgradesPrice[index] || upgradeData.unlockUpgrades[index] == 0) return;

        upgradeData.addPoints(-1 * (int)upgradeData.upgradesPrice[index]);

        upgradeData.addUpgrades(index);

        upgradeData.upgradesPrice[index] = upgradeData.upgradesBasePrice[index] * Mathf.Pow((float)upgradeData.upgradesPriceMulti[index], upgradeData.upgrades[index]);

        pointsText.text = "Points: " + upgradeData.getPoints().ToString();
        updatePrices();
        updateNames();
    }

    public void updatePrices()
    {
        for(int i = 0; i < upgradePriceText.Length; i++)
        {
            if (upgradeData.unlockUpgrades[i] == 1)
                upgradePriceText[i].text = upgradeData.upgradesPrice[i].ToString("F2") + " POINTS";
            else
                upgradePriceText[i].text = "Locked";
        }
    }

    public void updateNames()
    {
        for(int i = 0; i < upgradeNameText.Length; i++)
        {
            upgradeNameText[i].text = upgradeData.upgradeNames[i].ToString() + ": " + upgradeData.upgrades[i] + "\n" + (upgradeData.upgradesBuff[i] * 100).ToString("F0") + "% DNA";
        }
    }

    public void buyUnlockUpgrade(int index)
    {
        if(upgradeData.points >= upgradeData.unlockUpgradesPrice[index] && upgradeData.unlockUpgrades[index] == 0)
        {
            upgradeData.unlockUpgrades[index] = 1;
            upgradeData.addPoints(-1 * upgradeData.unlockUpgradesPrice[index]);

            pointsText.text = "Points: " + upgradeData.getPoints().ToString();
            refreshUnlockText();
        }
    }

    public void refreshUnlockText()
    {
        for(int i = 0; i < unlockUpgradeText.Length; i++)
        {
            if (upgradeData.unlockUpgrades[i + 2] == 1)
                unlockUpgradeText[i].text = "Unlocked";
        }
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
