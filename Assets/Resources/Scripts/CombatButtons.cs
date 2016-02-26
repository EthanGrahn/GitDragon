﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatButtons : MonoBehaviour {

    private Image fightIcon;
    private Image itemIcon;
    private Image skillIcon;
    private int selectedIndex;
    private Combat combat;
    private GameObject itemBox;

	void Start () {
        selectedIndex = 2;

        //Initialization of the button images
        fightIcon = GameObject.Find("Fight").GetComponent<Image>();
        itemIcon = GameObject.Find("Item").GetComponent<Image>();
        skillIcon = GameObject.Find("Skill").GetComponent<Image>();

        //Sets the default opacity of the images
        fightIcon.color = new Color(1f, 1f, 1f, 1f);
        itemIcon.color = new Color(1f, 1f, 1f, 0.5f);
        skillIcon.color = new Color(1f, 1f, 1f, 0.5f);

        //Storing the combat script for ease of use
        combat = GameObject.Find("CombatManager").GetComponent<Combat>();

        itemBox = GameObject.Find("ItemBox");
        itemBox.SetActive(false);
    }
	

	void Update () {
        //Update checking for key presses
        if (Input.GetKeyUp("left") && !itemBox.activeSelf)
        {
            //Debug.Log("Left Arrow");
            if (selectedIndex > 1)
            {
                selectedIndex--;
                ColorBrain(selectedIndex);
            }
        } 
        else if (Input.GetKeyUp("right") && !itemBox.activeSelf)
        {
            //Debug.Log("Right Arrow");
            if (selectedIndex < 3)
            {
                selectedIndex++;
                ColorBrain(selectedIndex);
            }
        }

        if (Input.GetKeyUp("return"))
        {
            if (!itemBox.activeSelf)
                ButtonBrain(selectedIndex);
        }

        if (Input.GetKeyUp("escape") && itemBox.activeSelf)
            itemBox.SetActive(false);
    }

    private void ColorBrain(int num)
    {
        switch (num)
        {
            case 1:
                Item();
                break;
            case 2:
                Fight();
                break;
            case 3:
                Skill();
                break;
        }
    }

    private void ButtonBrain(int num)
    {
        switch (num)
        {
            case 1:
                doItem();
                break;
            case 2:
                doFight();
                break;
            case 3:
                doSkill();
                break;
        }
    }

    private void Fight()
    {
        fightIcon.color = new Color(1f, 1f, 1f, 1f);
        itemIcon.color = new Color(1f, 1f, 1f, 0.5f);
        skillIcon.color = new Color(1f, 1f, 1f, 0.5f);
    }

    private void Item()
    {
        fightIcon.color = new Color(1f, 1f, 1f, 0.5f);
        itemIcon.color = new Color(1f, 1f, 1f, 1f);
        skillIcon.color = new Color(1f, 1f, 1f, 0.5f);
    }

    private void Skill()
    {
        fightIcon.color = new Color(1f, 1f, 1f, 0.5f);
        itemIcon.color = new Color(1f, 1f, 1f, 0.5f);
        skillIcon.color = new Color(1f, 1f, 1f, 1f);
    }

    private void doFight()
    {
        Debug.Log("Fighting...");
        combat.Attack();
    }

    private void doItem()
    {
        itemBox.SetActive(true);
    }

    private void doSkill()
    {

    }
}
