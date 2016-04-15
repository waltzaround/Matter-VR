using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class TestBallSpawnScalar : MonoBehaviour, IVisPrefabSpawnedTarget
{
    #region IVisPrefabSpawnedTarget Members

    public void OnSpawned(float current, float previous, float difference, float adjustedDifference)
    {
        float scale = VisHelper.ConvertBetweenRanges(adjustedDifference, 0.05f, 0.2f, 4.0f, 16.0f, false);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    #endregion
}