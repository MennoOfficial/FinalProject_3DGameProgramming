using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject toInteract;
    private bool InRange = false;
    private bool HasBeenBuild = false;

    private string WellText = "A well is a sustainable water source that taps into underground aquifers. By using a well, we can access clean and natural groundwater without relying on energy-intensive methods. This promotes sustainability by reducing the reliance on centralized water distribution systems and decreasing the carbon footprint associated with water transportation.";
    private string WatermillText = "Explanation: A watermill harnesses the power of flowing water to generate mechanical energy, which can then be converted into electricity. By utilizing the kinetic energy of moving water, watermills provide a renewable and eco-friendly way to produce energy.";
    private string WindTurbineText = "Wind turbines convert the kinetic energy of the wind into electrical power. Their sustainability lies in their ability to generate electricity without emitting greenhouse gases. Wind energy is a clean and renewable resource, contributing to the reduction of reliance on non-renewable energy sources.";
    private string SolarPanelText = "Solar panels convert sunlight into electricity through photovoltaic cells. This sustainable technology harnesses the abundant and renewable energy from the sun, reducing the need for fossil fuels. Solar panels are a clean energy solution that helps combat climate change, decrease air pollution, and promote energy independence. Their low environmental impact makes them an essential component of sustainable energy systems.";

    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Assuming the TextMeshPro component is attached to the same GameObject as this script
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = ""; // Set an initial empty text
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            switch (toInteract.tag)
            {
                case "Well":
                    textMeshPro.text = WellText;
                    break;
                case "Watermill":
                    textMeshPro.text = WatermillText;
                    break;
                case "WindTurbine":
                    textMeshPro.text = WindTurbineText;
                    break;
                case "SolarPanel":
                    textMeshPro.text = SolarPanelText;
                    break;
                default:
                    textMeshPro.text = "No information available for this object.";
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) InRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = false;
            textMeshPro.text = "";
        }
    }
}
