using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{
    private int luckyNumber;
    int enemyRecipeValue;
    public int playerRecipeValue;

    public List<Ingredient> ingredients = new List<Ingredient>();

    [Header("UI")]
    public Image valueBar;
    public TextMeshProUGUI barText;


    void Start()
    {
        UpdateUI();
        StartNewLevel();
    }

 
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
       valueBar.fillAmount = (float)playerRecipeValue / luckyNumber;
       barText.text = playerRecipeValue + " / " + luckyNumber;

       if(playerRecipeValue > luckyNumber)
       {
           valueBar.color = Color.red;
           
       }
       else
       {
           valueBar.color = Color.rebeccaPurple;
       }
    }

    public void ChooseRandomIngredient()
    {
        Ingredient random = ingredients[Random.Range(0, ingredients.Count)];
        int addValue = Random.Range(random.ingredientMinValue, random.ingredientMaxValue);
        playerRecipeValue += addValue;
    }

    void StartNewLevel()
    {
        luckyNumber = Random.Range(10, 50);
        enemyRecipeValue = Random.Range(10,luckyNumber);

    }

    public void CompareRecipes()
    {
        if (playerRecipeValue == luckyNumber)
        {
            Debug.Log("You win!");
        }
        else if (playerRecipeValue > luckyNumber)
        {
            Debug.Log("You lose! Your recipe value exceeded the lucky number.");
        }
        else if (playerRecipeValue < enemyRecipeValue)
        {
            Debug.Log("You lose! Your recipe value is less than enemy recipe value.");
        }
    }

    
}
