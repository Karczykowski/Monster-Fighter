using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterSelector : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;

    [SerializeField] private Station playerStation;
    [SerializeField] private Station enemyStation;

    [SerializeField] private List<Monster> playerMonsters;
    [SerializeField] private List<Monster> enemyMonsters;

    [SerializeField] private List<Button> playerTeamButtons;
    [SerializeField] private List<Button> enemyTeamButtons;

    [SerializeField] private Button attackButton;
    [SerializeField] private Button switchButton;

    [SerializeField] private UI ui;


    public void StartGame()
    {
        playerStation.SendMonster(Instantiate(playerMonsters[0], Vector2.zero, Quaternion.identity));
        enemyStation.SendMonster(Instantiate(enemyMonsters[0], Vector2.zero, Quaternion.identity));
        FillTeamButtons();
        attackButton.interactable = true;
        switchButton.interactable = true;
    }

    private void FillTeamButtons()
    {
        for(int i=0;i<playerMonsters.Count;i++)
        {
            playerTeamButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerMonsters[i].name;
        }
        DisableActiveMonsterSwitch();
    }

    private void DisableActiveMonsterSwitch()
    {
        for (int i = 0; i < playerMonsters.Count; i++)
        {
            if (playerStation.currentMonster.name.Contains(playerTeamButtons[i].GetComponentInChildren<TextMeshProUGUI>().text))
            {
                playerTeamButtons[i].interactable = false;
            }
            else
            {
                playerTeamButtons[i].interactable = true;
            }
        }
    }

    public void SwitchMonster(int index)
    {
        playerStation.SendMonster(Instantiate(playerMonsters[index], Vector2.zero, Quaternion.identity));
        DisableActiveMonsterSwitch();
        turnManager.StartCoroutine(turnManager.PlayTurnEnumerator());
    }
}
