using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewResponse", menuName = "Dialogue/HonourResponse")]
public class ResponseHonour : Response
{
    public int honourAmmount;
    public override void ResponseEffect()
    {
        base.ResponseEffect();
        PlayerStats.honour += honourAmmount;
    }
}
