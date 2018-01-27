﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerRessources : MonoBehaviour
{

    [SerializeField]
    float maxOxygen;
    float oxygen;
    public Slider oxygenSlider;

    [SerializeField]
    Text vitaminText;
    [SerializeField]
    Text calciumText;
    [SerializeField]
    Text proteinsText;

    [SerializeField]
    float vitamins;
    [SerializeField]
    float calcium;
    [SerializeField]
    float proteins;

    // Use this for initialization
    void Start ()
    {
        oxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = oxygen;

        vitaminText.text = vitamins.ToString();
        calciumText.text = calcium.ToString();
        proteinsText.text = proteins.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void looseOxygen(float damages)
    {
        oxygen -= damages;
        oxygenSlider.value = oxygen;
        if (oxygen <= 0)
            oxygenSlider.gameObject.transform.Find("Fill Area").gameObject.SetActive(false);
    }

    public bool payVitamins(float price)
    {
        if (vitamins > price)
        {
            vitamins -= price;
            vitaminText.text = vitamins.ToString();
            return (true);
        }
        return (false);
    }

    public bool payProteins(float price)
    {
        if (proteins > price)
        {
            proteins -= price;
            proteinsText.text = proteins.ToString();
            return (true);
        }
        return (false);
    }

    public bool payCalcium(float price)
    {
        if (calcium > price)
        {
            calcium -= price;
            calciumText.text = calcium.ToString();
            return (true);
        }
        return (false);
    }

    public bool payRessources(float vitaminPrice, float proteinPrice, float calciumPrice)
    {
        bool returnValue = true;

        if (vitamins > vitaminPrice)
        {
            vitamins -= vitaminPrice;
            vitaminText.text = vitamins.ToString();
        }
        else
            returnValue = false;

        if (calcium > calciumPrice)
        {
            calcium -= calciumPrice;
            calciumText.text = calcium.ToString();
        }
        else
            returnValue = false;

        if (proteins > proteinPrice)
        {
            proteins -= proteinPrice;
            proteinsText.text = proteins.ToString();
        }
        else
            returnValue = false;

        return (returnValue);
    }
}