using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

[CreateAssetMenu(fileName = "New Helm", menuName = "Items/Helm")]
public class Helm : Item
{
    public string description = "Something";
    public float life;
    public float mana;
    public float stamina;
    public int attack;
    public int faith;
    public int dexterity;
    public int speed;
    public int defense;
    public int vitality;
    public int wisdom;
    public int resistance;

    public Rarity Rarity { get { return rarity; } }

    public override string ColouredName
    {
        get
        {
            string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColour);
            return $"<color=#{hexColour}>{Name}</color>";
        }
    }

    public override Color color { get { return rarity.textColour; } }

    public override string GetTooltipInfoText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(Rarity.Name).AppendLine();
        builder.Append("\n");
        builder.Append("").Append(description).Append("").AppendLine();
        builder.Append("\n");
        builder.Append("<color=green>On Equip: ").Append("</color>").AppendLine();
        if (life != 0) { builder.Append("Life: ").Append(life).Append("").AppendLine(); }
        if (mana != 0) { builder.Append("Mana: ").Append(mana).Append("").AppendLine(); }
        if (stamina != 0) { builder.Append("Stamina: ").Append(stamina).Append("").AppendLine(); }
        if (attack != 0) { builder.Append("Attack: ").Append(attack).Append("").AppendLine(); }
        if (faith != 0) { builder.Append("Faith: ").Append(faith).Append("").AppendLine(); }
        if (dexterity != 0) { builder.Append("Dexterity: ").Append(dexterity).Append("").AppendLine(); }
        if (speed != 0) { builder.Append("Speed: ").Append(speed).Append("").AppendLine(); }
        if (defense != 0) { builder.Append("Defense: ").Append(defense).Append("").AppendLine(); }
        if (vitality != 0) { builder.Append("Vitality: ").Append(vitality).Append("").AppendLine(); }
        if (wisdom != 0) { builder.Append("Wisdom: ").Append(wisdom).Append("").AppendLine(); }
        if (resistance != 0) { builder.Append("Resistance: ").Append(resistance).Append("").AppendLine(); }
        builder.Append("\n");
        builder.Append("Sell Price: ").Append(SellPrice).Append(" Y");

        return builder.ToString();
    }
}
