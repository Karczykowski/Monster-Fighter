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

    public void ShowTextUseMove(Monster monster, Move move)
    {
        DisableAttackPanel();
        EnableTextPanel();
        textPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"{monster.GetMonsterName()} used {move.name}";
    }

    public void ShowTextEffectiveness(float typeEffectiveness)
    {
        DisableAttackPanel();
        EnableTextPanel();
        if(typeEffectiveness > 1)
            textPanel.GetComponentInChildren<TextMeshProUGUI>().text = "It's super effective!";
        else if(typeEffectiveness < 1)
            textPanel.GetComponentInChildren<TextMeshProUGUI>().text = "It's not very effective"; 
    }
    public void DisableInfoPanel()
    {
        infoPanel.SetActive(false);
    }
    public void EnableInfoPanel()
    {
        attackPanel.SetActive(false);
        textPanel.SetActive(false);
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
        textPanel.SetActive(true);
    }
}
