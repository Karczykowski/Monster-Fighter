using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private PowerType moveType;
    [SerializeField] private MoveCategory moveCategory;
    [SerializeField] private int movePp;
    [SerializeField] private int movePower;
    [SerializeField] private int moveAccuracy;
    [SerializeField] private bool moveIsContact;
}
