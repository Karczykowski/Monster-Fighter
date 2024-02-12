using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Station : MonoBehaviour
{
    public Monster currentMonster;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] Slider hpSlider;
    [SerializeField] SpriteRenderer spritePosition;

    [SerializeField] bool isFront;
    [SerializeField] UI _ui;
    [SerializeField] TurnManager turnManager;

    public void SendMonster(Monster monster)
    {
        currentMonster = monster;
        nameText.text = monster.GetMonsterName();
        hpSlider.maxValue = monster.GetHp().GetFinalStat();
        UpdateHp();
        if (!isFront)
        {
            spritePosition.sprite = monster.GetFrontSprite();
            _ui.UpdateMoveText(currentMonster);
        }
        else
        {
            spritePosition.sprite = monster.GetBackSprite();
        }
    }

    public void UpdateHp()
    {
        int maxHp = currentMonster.GetHp().GetFinalStat();
        int newHp = currentMonster.GetHp().GetCurrentHp();
        hpText.text = $"{newHp} / {maxHp}";
        hpSlider.value = newHp;
        if(newHp == 0)
        {
            turnManager.GameOver();
        }
    }

}
