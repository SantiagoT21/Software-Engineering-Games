﻿using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public static Die Die_Instance;
    [SerializeField] public GameObject backward_button;
    [SerializeField] public GameObject forward_button;
    [SerializeField] public GameObject roll_button;
    [SerializeField] public GameObject yes_button;
    [SerializeField] public GameObject no_button;
    public Text die_Text;
    public Text HC_Text;
    public int random;
    public int roll_counter;
    public bool back;
    public bool forw;
    public bool shortcut;
    

    public void Awake()
    {
        die_Text.text = "";
        if (Die_Instance == null)
        {
            Die_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Die.Die_Instance.backward_button.SetActive(false);
        Die.Die_Instance.forward_button.SetActive(false);
        Die.Die_Instance.yes_button.SetActive(false);
        Die.Die_Instance.no_button.SetActive(false);
        Die.Die_Instance.roll_button.SetActive(false);
    }

    public void RollDie()
    {
        int aux;
        if (GameController.GCcardNumber==1 && Card.Instance.hammer_counter > 0)
        {
            random = Random.Range(1, 7);
            aux = random;
        }
        else if (GameController.GCcardNumber == 3)
        {
            random = Random.Range(1, 7) + Card.Instance.saw_counter - Card.Instance.bridge_counter;
            aux = random + Card.Instance.bridge_counter + Card.Instance.saw_counter;
        }
        else if (GameController.GCcardNumber == 5)
        {
            random = Random.Range(1, 7) - Card.Instance.screwdriver_counter - Card.Instance.bridge_counter;
            aux = random + Card.Instance.bridge_counter + Card.Instance.screwdriver_counter;
        }
        else
        {
            random = Random.Range(1, 7) - Card.Instance.bridge_counter;
            aux = random + Card.Instance.bridge_counter;
        }
        die_Text.text = "" + aux;
        roll_counter++;
    }
}
