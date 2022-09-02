using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KillType
{
    One,

    All,

    Wall
}
public class BaseObstacle : MonoBehaviour
{
    [SerializeField] private string obstacleName;

    public KillType killType;

    private void OnEnable()
    {
        gameObject.name = obstacleName;

    }
}
