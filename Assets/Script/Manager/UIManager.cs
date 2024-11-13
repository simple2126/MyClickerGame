using TMPro;
using UnityEngine;

public class UIMAnager : MonoBehaviour
{
    public TextMeshProUGUI stageTxt;
    private int stage = 0;

    public TextMeshProUGUI goldtxt;
    private int gold = 0;

    private void Awake()
    {
        UpdateUI(gold);
    }

    private void UpdateStage()
    {
        stage += 1;
        stageTxt.text = $"Stage {stage}";
    }

    public void UpdateGold(int reward)
    {
        gold += reward;
        goldtxt.text = $"{gold} G";
    }

    public void UpdateUI(int reward)
    {
        UpdateStage();
        UpdateGold(reward);
    }
}