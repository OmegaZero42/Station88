using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplay : MonoBehaviour {

    //UI text to pass in editor
    [SerializeField]
    Text HPText;
    [SerializeField]
    Text attackMText;
    [SerializeField]
    Text attackDText;
    [SerializeField]
    Text defenseText;
    [SerializeField]
    Text speedText;
    [SerializeField]
    GameObject player;

    void Start () {
        		
	}
	
	void Update () {
        HPText.text = "HP: " + player.GetComponent<HealthAndDamageSystem>().CurrentHp;
        attackDText.text = "AttackD: " + player.GetComponent<PlayerPlatformerController>().AttackD;
        attackMText.text = "AttackM: " + player.GetComponent<PlayerPlatformerController>().AttackM;
        defenseText.text = "Defense: " + player.GetComponent<PlayerPlatformerController>().Defense;
        speedText.text = "Speed: " + player.GetComponent<PlayerPlatformerController>().Speed;
    }
}
