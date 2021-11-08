using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HordeMovement : MonoBehaviour
{

    EnemyHorde myHordeData => GetComponent<EnemyHorde>();
    private const float speedConstant = 60;
    public float MaxX;
    private float GameRythim
    {
        get 
        {
            float enemyCount = myHordeData.horde.Count;
            float gameRythim = speedConstant / ((enemyCount != 0) ? enemyCount : 1);
            return gameRythim;
        } 
    }

    private float DirectionalSpeed => GameRythim*Mathf.Cos((10 * Time.time * Mathf.Deg2Rad) + Mathf.PI/2);

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (myHordeData.horde.Count > 0)
        {
            for (int i = 0; i < myHordeData.matrixSideY;)
            {
                float referenceTime = (Time.deltaTime);
                foreach (NonPlayerCharacter enemy in myHordeData.horde.Where(enemy => enemy.matrixPos.y == i))
                {
                    enemy.transform.localPosition = enemy.InitialPosition + DirectionalSpeed * Vector3.right * MaxX * referenceTime;
                    yield return null;
                }
            }
        }
    }
}
