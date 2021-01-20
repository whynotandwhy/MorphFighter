using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterStatUpdater : CoreUIElement<ICombatStats>
{
    [SerializeField] protected Image hpBar;
    [SerializeField] protected TMP_Text hpNumber;
    [SerializeField] protected Image concentrationBar;
    [SerializeField] protected TMP_Text concentrationNumber;
    [SerializeField] protected Image consciousnessBar;
    [SerializeField] protected TMP_Text consciousnessNumber;
    [SerializeField] protected Image energyBar;
    [SerializeField] protected TMP_Text energyNumber;
    [SerializeField] protected Image staminaBar;
    [SerializeField] protected TMP_Text staminaNumber;

    public override void UpdateUI(ICombatStats primaryData)
    {
        if (ClearedIfEmpty(primaryData))
            return;

        //This will need to be revisted once we figure out how we want to display this data as a bar
        // % of character max? Feels maybe too small of increments early game. Maybe based on Current Rank?
        SetPercentage(hpBar, primaryData.HP);
        UpdateNumericText(hpNumber, "{0}", primaryData.HP);
        SetPercentage(concentrationBar, primaryData.Concentration);
        UpdateNumericText(hpNumber, "{0}", primaryData.Concentration);
        SetPercentage(consciousnessBar, primaryData.Consciousness);
        UpdateNumericText(hpNumber, "{0}", primaryData.Consciousness);
        SetPercentage(energyBar, primaryData.Energy);
        UpdateNumericText(hpNumber, "{0}", primaryData.Energy);
        SetPercentage(staminaBar, primaryData.Stamina);
        UpdateNumericText(hpNumber, "{0}", primaryData.Stamina);    }

    protected override bool ClearedIfEmpty(ICombatStats newData)
    {
        if (newData != null)
            return false;

        SetPercentage(hpBar, 0f);
        UpdateNumericText(hpNumber, "{0}", newData.HP);
        SetPercentage(concentrationBar, 0f);
        UpdateNumericText(hpNumber, "{0}", newData.Concentration);
        SetPercentage(consciousnessBar, 0f); 
        UpdateNumericText(hpNumber, "{0}", newData.Consciousness);
        SetPercentage(energyBar, 0f); 
        UpdateNumericText(hpNumber, "{0}", newData.Energy);
        SetPercentage(staminaBar, 0f); 
        UpdateNumericText(hpNumber, "{0}", newData.Stamina);

        return true;
    }
}
