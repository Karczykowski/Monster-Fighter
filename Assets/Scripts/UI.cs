using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum StationStance { DEFAULT, ATTACK, OTHER }
public class UI : MonoBehaviour
{
    private StationStance currentStance;
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject attackPanel;
    [SerializeField] Button[] moveButtons;
    private void Start()
    {
        currentStance = StationStance.DEFAULT;
    }

    public void AttackOption()
    {
        if (currentStance != StationStance.DEFAULT)
            return;
        DisableInfoPanel();
        EnableAttackPanel();
        currentStance = StationStance.ATTACK;
    }

    public void InfoOption()
    {
        DisableAttackPanel();
        EnableInfoPanel();
        currentStance = StationStance.DEFAULT;
    }

    public void UpdateMoveText(Monster currentMonster)
    {
        for(int i = 0;i < 4;i++)
        {
            if (currentMonster.GetMove(i) != null)
            {
                moveButtons[i].interactable = true;
                moveButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentMonster.GetMove(i).name;
            }
            else
            {
                moveButtons[i].interactable = false;
            }
        }
    }

    public void DisableInfoPanel()
    {
        infoPanel.SetActive(false);
    }
    public void EnableInfoPanel()
    {
        infoPanel.SetActive(true);
    }
    public void DisableAttackPanel()
    {
        attackPanel.SetActive(false);
    }
    public void EnableAttackPanel()
    {
        attackPanel.SetActive(true);
    }
}
