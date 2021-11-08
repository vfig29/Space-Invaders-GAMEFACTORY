using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections.Generic;

public class EnemyHorde : MonoBehaviour
{
    public GameObject enemyEntityPrefab;
    public int matrixSideX = 10;
    public int matrixSideY = 10;
    public float xSpace;
    public float ySpace;
    public List<NonPlayerCharacter> horde = new List<NonPlayerCharacter>();


    public void ResetEnemyHorde()
    {
        for (int x = 0; x < matrixSideX; x++)
        {
            for (int y = 0; y < matrixSideY; y++)
            {
                GameObject instantiatedObj = Instantiate(enemyEntityPrefab, new Vector3(x*(xSpace),y*(ySpace)),Quaternion.identity);
                instantiatedObj.transform.parent = transform;
                NonPlayerCharacter addedCharacter = instantiatedObj.GetComponent<NonPlayerCharacter>();
                addedCharacter.matrixPos = new Vector2Int(x, y);
                horde.Add(addedCharacter);
            }
        }
    }

    public void ClearEnemyHorde()
    {
        var list = GetComponentsInChildren<NonPlayerCharacter>();
        foreach (var enemy in list)
        {
            if (enemy.gameObject != gameObject)
            {
                if (enemy.transform.parent == transform)
                {
                    DestroyImmediate(enemy.gameObject);
                }
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(EnemyHorde))]
public class EnemyHordeCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EnemyHorde targ = target as EnemyHorde;
        if (GUILayout.Button("Build Enemy Horde Matrix"))
        {
            targ.ResetEnemyHorde();
        }
        if (GUILayout.Button("Clear Enemy Horde Matrix"))
        {
            targ.ClearEnemyHorde();
        }
    }
}
#endif
