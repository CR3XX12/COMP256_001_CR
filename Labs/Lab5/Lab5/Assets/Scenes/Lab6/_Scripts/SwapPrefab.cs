using UnityEngine;
using TMPro;

public class SwapPrefab : MonoBehaviour
{
    public Food[] AvailableFoods;  // List of food objects
    private int CurrentFoodIndex = 0;
    private ARPlacePrefab ARPrefabPlacement;

    void Start()
    {
        ARPrefabPlacement = Object.FindFirstObjectByType<ARPlacePrefab>();

        // Set the first food item as the default when the scene starts
        if (AvailableFoods.Length > 0)
        {
            ARPrefabPlacement.ObjectToPlace = AvailableFoods[0].prefab;
        }
    }

    public void SwapFoodPrefab()
    {
        // Move to the next food item in the list (loop back if at the end)
        CurrentFoodIndex = (CurrentFoodIndex + 1) % AvailableFoods.Length;
        ARPrefabPlacement.ObjectToPlace = AvailableFoods[CurrentFoodIndex].prefab;
        ARPrefabPlacement.PlaceObject();

        // Update the displayed food info
        ARPrefabPlacement.InfoText.text =
            $"<b>Name:</b> {AvailableFoods[CurrentFoodIndex].name}\n" +
            $"<b>Ingredients:</b> {AvailableFoods[CurrentFoodIndex].ingredients}\n" +
            $"<b><color=red>Calories:</color></b> {AvailableFoods[CurrentFoodIndex].calories}\n" +
            $"<b>Diet Type:</b> {AvailableFoods[CurrentFoodIndex].dietType}";
    }

    public void SwapToPreviousFoodPrefab()
    {
        // Move to the previous food item in the list (loop back if at the start)
        CurrentFoodIndex--;
        if (CurrentFoodIndex < 0)
        {
            CurrentFoodIndex = AvailableFoods.Length - 1;
        }

        ARPrefabPlacement.ObjectToPlace = AvailableFoods[CurrentFoodIndex].prefab;
        ARPrefabPlacement.PlaceObject();

        // Update the displayed food info
        ARPrefabPlacement.InfoText.text =
            $"<b>Name:</b> {AvailableFoods[CurrentFoodIndex].name}\n" +
            $"<b>Ingredients:</b> {AvailableFoods[CurrentFoodIndex].ingredients}\n" +
            $"<b><color=red>Calories:</color></b> {AvailableFoods[CurrentFoodIndex].calories}\n" +
            $"<b>Diet Type:</b> {AvailableFoods[CurrentFoodIndex].dietType}";
    }

    public Food GetCurrentFood()
    {
        return AvailableFoods[CurrentFoodIndex];
    }
}
