using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{
    public int luckyNumber;
    int enemyRecipeValue;
    public int playerRecipeValue;

    public List<Ingredient> ingredients = new List<Ingredient>();

    [Header("UI")]
    public Image valueBar;
    public TextMeshProUGUI barText;


    void Start()
    {
        UpdateUI();
    }

 
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
       valueBar.fillAmount = (float)playerRecipeValue / luckyNumber;
       barText.text = playerRecipeValue + " / " + luckyNumber;
    }

    void ChooseRandomIngredient()
    {

    }
}
