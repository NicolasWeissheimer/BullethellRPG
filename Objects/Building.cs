using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    SpriteRenderer building;
    byte alpha;

    private void Start()
    {
        building = GetComponent<SpriteRenderer>();
    }

    public IEnumerator HideBuilding()
    {
        int i = 0;

        while (i < 19)
        {
            Color32 colorAlpha = building.color;
            alpha -= 13;
            if (alpha < 0) { alpha = 0; }
            colorAlpha.a = alpha;
            building.color = colorAlpha;
            yield return new WaitForSeconds(0.02f);
            i++;
        }

        Color32 color = building.color;
        alpha = 0;
        color.a = alpha;
        building.color = color;


    }

    public IEnumerator ShowBuilding()
    {
        int i = 0;

        while (i < 19)
        {
            Color32 colorAlpha = building.color;
            alpha += 13;
            if (alpha > 255) { alpha = 0; }
            colorAlpha.a = alpha;
            building.color = colorAlpha;
            yield return new WaitForSeconds(0.02f);
            i++;
        }

        Color32 color = building.color;
        alpha = 255;
        color.a = alpha;
        building.color = color;
    }
}
