using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class LevelGoal : MonoBehaviour
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    private void Update()
    {
        if (IsReached() == true)
        {
            FindObjectOfType<GameManager>().LevelCompleted();
        }
    }

    public void CollisionDetected()
    {
        currentAmount++;
    }

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);

    }
}
public enum GoalType
{
    Collison
}