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
    [SerializeField] GameObject textPanel;
    [SerializeField] GameObject switchPanel;
    [SerializeField] Button[] moveButtons;
    [SerializeField] Button backFromSwitchButton;
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

    public void SwitchOption(bool isForced = false)
    {
        backFromSwitchButton.interactable = true;
        DisableInfoPanel();
        EnableSwitchPanel();
        if(isForced)
        {
            backFromSwitchButton.interactable = false;
        }
    }

    public void InfoOption()
    {
        DisableAttackPanel();
        DisableSwitchPanel();
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
                moveButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "-";
            }
        }
    }

    public void ShowTextUseMove(Monster monster, Move move)
    {
        DisableAttackPanel();
        EnableTextPanel();
        textPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"{monster.GetMonsterName()} used {move.name}";
    }

    public bool ShowTextEffectiveness(float typeEffectiveness)
    {
        DisableAttackPanel();
        EnableTextPanel();
        if(typeEffectiveness > 1)
        {
            textPanel.GetComponentInChildren<TextMeshProUGUI>().text = "It's super effective!";
            return true;
        }
        else if(typeEffectiveness < 1)
        {
            textPanel.GetComponentInChildren<TextMeshProUGUI>().text = "It's not very effective";
            return true;
        }
        return false;
    }

    public bool ShowTextCriticalHit(float critical)
    {
        if(critical != 1)
        {
            DisableAttackPanel();
            EnableTextPanel();
            textPanel.GetComponentInChildren<TextMeshProUGUI>().text = "It's a critical hit!";
            return true;
        }
        return false;
    }
    public void DisableInfoPanel()
    {
        infoPanel.SetActive(false);
    }
    public void EnableInfoPanel()
    {
        attackPanel.SetActive(false);
        textPanel.SetActive(false);
        switchPanel.SetActive(false);
        infoPanel.SetActive(true);
    }
    public void DisableAttackPanel()
    {
        attackPanel.SetActive(false);
    }
    public void EnableAttackPanel()
    {
        textPanel.SetActive(false);
        infoPanel.SetActive(false);
        switchPanel.SetActive(false);
        attackPanel.SetActive(true);
    }
    public void DisableTextPanel()
    {
        textPanel.SetActive(false);
    }
    public void EnableTextPanel()
    {
        attackPanel.SetActive(false);
        infoPanel.SetActive(false);
        switchPanel.SetActive(false);
        textPanel.SetActive(true);
    }

    public void DisableSwitchPanel()
    {
        switchPanel.SetActive(false);
    }
    public void EnableSwitchPanel()
    {
        attackPanel.SetActive(false);
        infoPanel.SetActive(false);
        textPanel.SetActive(false);
        switchPanel.SetActive(true);
    }
}
