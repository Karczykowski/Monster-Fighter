using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Station : MonoBehaviour
{
    private Monster _monster;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] Slider hpSlider;
    [SerializeField] SpriteRenderer spritePosition;

    [SerializeField] bool isFront;
    public void SendMonster(Monster monster)
    {
        _monster = monster;
        nameText.text = monster.GetMonsterName();
        hpSlider.maxValue = monster.GetHp().GetFinalStat();
        UpdateHp();
        if (!isFront)
        {
            spritePosition.sprite = monster.GetFrontSprite();
        }
        else
        {
            spritePosition.sprite = monster.GetBackSprite();
        }
    }

    public void UpdateHp()
    {
        hpText.text = $"{_monster.GetHp().currentHp} / {_monster.GetHp().GetFinalStat()}";
        hpSlider.value = _monster.GetHp().currentHp;
    }

}
