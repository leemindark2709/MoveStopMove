using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Canvas canvas;
    public List<TargetIndicator> targetIndicators = new List<TargetIndicator>();
    public Camera MainCamera;
    public GameObject TargetIndicatorPrefab;

    void Update()
    {
        for (int i = targetIndicators.Count - 1; i >= 0; i--)
        {
            if (targetIndicators[i] != null)
            {
                targetIndicators[i].UpdateTargetIndicator();
            }
            else
            {
                targetIndicators.RemoveAt(i);
            }
        }
    }

    public void AddTargetIndicator(GameObject target)
    {
        TargetIndicator indicator = Instantiate(TargetIndicatorPrefab, canvas.transform).GetComponent<TargetIndicator>();
        indicator.InitialiseTargetIndicator(target, MainCamera, canvas);
        indicator.gameObject.SetActive(false);
        targetIndicators.Add(indicator);
    }

    public void RemoveTargetIndicator(GameObject target)
    {
        TargetIndicator indicatorToRemove = targetIndicators.Find(indicator => indicator != null && indicator.gameObject == target);
        if (indicatorToRemove != null)
        {
            targetIndicators.Remove(indicatorToRemove);
            Destroy(indicatorToRemove.gameObject);
        }
    }
}
