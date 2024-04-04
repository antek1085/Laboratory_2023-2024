using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    int whatTab;
    [Header("Main Buttons")]
    [SerializeField] GameObject bedroomButton;
    [SerializeField] GameObject kitchenButton;
    [SerializeField] GameObject bathroomButton;
    [SerializeField] GameObject workingStationButton;


    public void BedroomButton()
    {
        if (whatTab != 1)
        {
            whatTab = 1;
            bedroomButton.SetActive(true);
            kitchenButton.SetActive(false);
            bathroomButton.SetActive(false);
            workingStationButton.SetActive(false);
        }
    }
    public void KitchenButton()
    {
        if (whatTab != 2)
        {
            whatTab = 2;
            bedroomButton.SetActive(false);
            kitchenButton.SetActive(true);
            bathroomButton.SetActive(false);
            workingStationButton.SetActive(false);
        }
    }
    public void BathroomButton()
    {
        if (whatTab != 3)
        {
            whatTab = 3;
            bedroomButton.SetActive(false);
            kitchenButton.SetActive(false);
            bathroomButton.SetActive(true);
            workingStationButton.SetActive(false);
        }
    }
    public void WorkingStationButton()
    {
        if (whatTab != 4)
        {
            whatTab = 4;
            bedroomButton.SetActive(false);
            kitchenButton.SetActive(false);
            bathroomButton.SetActive(false);
            workingStationButton.SetActive(true);
        }
    }
}
