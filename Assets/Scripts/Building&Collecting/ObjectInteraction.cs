using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject toInteract;
    public BuildingType buildingType;

    private bool InRange = false;
    private bool HasBeenBuild = false;

    private string WellText = "A well is a sustainable water source that taps into underground aquifers. By using a well, we can access clean and natural groundwater without relying on energy-intensive methods. This promotes sustainability by reducing the reliance on centralized water distribution systems.";
    private string Watermill = "A watermill harnesses the power of flowing water to generate mechanical energy, which can then be converted into electricity. By utilizing the kinetic energy of moving water, watermills provide a renewable and eco-friendly way to produce energy.";
    private string WindTurbineText = "Wind turbines convert the kinetic energy of the wind into electrical power. Their sustainability lies in their ability to generate electricity without emitting greenhouse gases. Wind energy is a clean and renewable resource, contributing to the reduction of reliance on non-renewable energy sources.";
    private string SolarPanelText = "Solar panels convert sunlight into electricity through photovoltaic cells. This sustainable technology harnesses the abundant and renewable energy from the sun, reducing the need for fossil fuels. Solar panels are a clean energy solution that helps combat climate change, decrease air pollution, and promote energy independence. Their low environmental impact makes them an essential component of sustainable energy systems.";

    public enum BuildingType
    {
        Well,
        Watermill,
        WindTurbine,
        SolarPanel
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            switch (buildingType)
            {
                case BuildingType.Well:
                    UIManager.Instance.UpdateText(WellText);
                    break;
                case BuildingType.Watermill:
                    UIManager.Instance.UpdateText(Watermill);
                    break;
                case BuildingType.WindTurbine:
                    UIManager.Instance.UpdateText(WindTurbineText);
                    break;
                case BuildingType.SolarPanel:
                    UIManager.Instance.UpdateText(SolarPanelText);
                    break;
                default:
                    UIManager.Instance.UpdateText("No information available for this object.");
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) UIManager.Instance.ShowInfoButtonUI();
        InRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) UIManager.Instance.HideInfoButtonUI();
        InRange = false;
    }
}