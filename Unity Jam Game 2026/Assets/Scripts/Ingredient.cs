using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public string ingredientDescription;
    public Sprite ingredientSprite;
    public int ingredientValue;
}
