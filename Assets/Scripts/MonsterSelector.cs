using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelector : MonoBehaviour
{
    [SerializeField] private Station playerStation;
    [SerializeField] private Station enemyStation;

    [SerializeField] private List<Monster> playerMonsters;
    [SerializeField] private List<Monster> enemyMonsters;

    public void StartGame()
    {
        playerStation.SendMonster(Instantiate(playerMonsters[0], Vector2.zero, Quaternion.identity));
        enemyStation.SendMonster(Instantiate(enemyMonsters[0], Vector2.zero, Quaternion.identity));
    }
}
