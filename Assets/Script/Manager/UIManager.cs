using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMAnager : MonoBehaviour
{
    [Header("Upgrade UI")]
    public TextMeshProUGUI stageTxt;
    private int stage = 0;
    public TextMeshProUGUI goldtxt;
    private int gold = 0;

    [Header("UpgradeButton")]
    public GameObject clickUpgrade;
    public TextMeshProUGUI clickUpgradeTxt;
    public int clickUpgradeCost;

    public GameObject autoClickUnlock;
    public TextMeshProUGUI autoClickUnlockTxt;
    public int autoClickUnlockCost;
    public GameObject lockImage;

    public GameObject autoClickUpgrade;
    public TextMeshProUGUI autoClickUpgradeTxt;
    public int autoClickUpgradeCost;

    private void Awake()
    {
        UpdateUI(gold);
    }

    public void UpdateStage()
    {
        stage += 1;
        stageTxt.text = $"Stage {stage}";
    }

    public void UpdateGold(int reward)
    {
        gold += reward;
        goldtxt.text = $"{gold} G";
    }

    private void UpdateUI(int reward)
    {
        UpdateStage();
        UpdateGold(reward);
        clickUpgradeTxt.text = $"{clickUpgradeCost} G";
        autoClickUnlockTxt.text = $"{autoClickUnlockCost} G";
        autoClickUpgradeTxt.text = $"{autoClickUpgradeCost} G";
    }

    public void clickUpgradeButton()
    {
        if (gold >= clickUpgradeCost)
        {
            UpdateGold(-clickUpgradeCost);
            clickUpgradeCost += 10;
            clickUpgradeTxt.text = $"{clickUpgradeCost} G";
            GameManager.Instance.PlayerController.power *= 1.3f;
            GameManager.Instance.PlayerController.clickGold += 1;
        }
    }

    public void autoClickUnlockButton()
    {
        if(gold >= autoClickUnlockCost)
        {
            UpdateGold(-autoClickUnlockCost);
            GameManager.Instance.PlayerController.isAutoClick = true;
            GameManager.Instance.PlayerController.AutoClickStartCoroutine();
            lockImage.SetActive(true);
        }
    }

    public void autoClickUpgradeButton()
    {
        if (gold >= autoClickUpgradeCost && GameManager.Instance.PlayerController.isAutoClick)
        {
            UpdateGold(-autoClickUpgradeCost);
            clickUpgradeCost += 20;
            autoClickUpgradeTxt.text = $"{autoClickUpgradeCost} G";
            float time = GameManager.Instance.PlayerController.autoClickTime;
            GameManager.Instance.PlayerController.autoClickTime = Mathf.Max(0f, time - 0.1f);
        }
    }
}