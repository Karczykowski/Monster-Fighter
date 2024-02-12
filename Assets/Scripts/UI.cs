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
        infoPanel.SetActive(false);
        attackPanel.SetActive(true);
        currentStance = StationStance.ATTACK;
    }

    public void InfoOption()
    {
        attackPanel.SetActive(false);
        infoPanel.SetActive(true);
        currentStance = StationStance.DEFAULT;
    }

    public void UpdateMoveText(Monster currentMonster)
    {
        for(int i = 0;i < 4;i++)
        {
            if(currentMonster.GetMove(i) != null)
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
}
