using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    private int luckyNumber;
    int enemyRecipeValue;
    public int playerRecipeValue;

    public List<Ingredient> ingredients = new List<Ingredient>();

    [Header("UI")]
    public Image valueBar;
    public TextMeshProUGUI barText;
    public GameObject playerScoreUI;
    public TextMeshProUGUI playerScoreText;
    public GameObject clientScoreUI;
    public TextMeshProUGUI clientScoreText;

    float originalScoreY;

    private Sequence compareSequence;

    void Start()
    {
        UpdateUI();
        StartNewLevel();

        originalScoreY = playerScoreUI.transform.position.y;
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
         //  valueBar.color = Color.red;
           
       }
       else
       {
         //  valueBar.color = Color.rebeccaPurple;
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

        playerScoreText.text = playerRecipeValue + " / " + luckyNumber;
        clientScoreText.text = enemyRecipeValue + " / " + luckyNumber;
        PopupCompareUI();
    }

    private void PopupCompareUI()
    {
        // Kill previous animation if still running
        compareSequence?.Kill();

        compareSequence = DOTween.Sequence();

        // Player score popup
        compareSequence.Append(playerScoreUI.transform.DOLocalMoveY(0f, 0.3f)
            .SetEase(Ease.OutBack));

        compareSequence.Join(playerScoreUI.transform.DOScale(
            new Vector3(0.75f, 0.75f, 1f), 0.15f));

        compareSequence.Append(playerScoreUI.transform.DOScale(
            new Vector3(0.85f, 1.15f, 1f), 0.12f));

        compareSequence.Append(playerScoreUI.transform.DOScale(Vector3.one, 0.15f));

        compareSequence.AppendInterval(1f);

        // Client score popup
        compareSequence.Append(clientScoreUI.transform.DOLocalMoveY(0f, 0.3f)
            .SetEase(Ease.OutBack));

        compareSequence.Join(clientScoreUI.transform.DOScale(
            new Vector3(0.75f, 0.75f, 1f), 0.15f));

        compareSequence.Append(clientScoreUI.transform.DOScale(
            new Vector3(0.85f, 1.15f, 1f), 0.12f));

        compareSequence.Append(clientScoreUI.transform.DOScale(Vector3.one, 0.15f));
    }
}
