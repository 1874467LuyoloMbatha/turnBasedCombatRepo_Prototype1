using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum bState {Start, Playerturn, Enmeyturn,Won, Lost }

public class BattleSystem2 : MonoBehaviour
{
    public GameObject playerP;
    public GameObject enemyP;

    public Transform P1BattleStation;
    public Transform enemyBattleStation;

    UnitScript playerUni;
    UnitScript enemyUni;

    public Text dialogueText;

    public bHUD playerHUD;
    public bHUD enemyHUD;




    public bState state;

    void Start()
    {
        state = bState.Start;

        StartCoroutine(bSetup());
    }

    IEnumerator bSetup() //Spawn battle units
    {
        GameObject playerGObject = Instantiate(playerP, P1BattleStation);
        playerGObject.GetComponent<UnitScript>();
        playerUni = playerGObject.GetComponent<UnitScript>();

        GameObject enemyGObject = Instantiate(enemyP, enemyBattleStation);
        enemyUni = enemyGObject.GetComponent<UnitScript>();

        dialogueText.text = " BossMan " + enemyUni.unitGama + " appeared to fight you ";

        playerHUD.setHUD(playerUni);
        enemyHUD.setHUD(enemyUni);

        yield return new WaitForSeconds(2f);

        state = bState.Playerturn;
        PTurn();
    }

    IEnumerator playerAttec()
    {
        bool isdeath = enemyUni.tDamage(playerUni.damage);

        enemyHUD.setHP(enemyUni.currentHealtH);
        dialogueText.text = " attack landed successfully";

        //makes sure damage is dealt
        yield return new WaitForSeconds(2f);

        //check if enemy is dead 
        if (isdeath)
        {
            //battle ends
            state = bState.Won;
            battlePhelile();
        }
        else
        {
            //opponents turn
            state = bState.Enmeyturn;
            StartCoroutine(opponentTurn());
        } 
    }

    IEnumerator opponentTurn() 
    {
        //enemy logic
        dialogueText.text = enemyUni.unitGama + " Attacked You! ";

        yield return new WaitForSeconds(1f);

        bool isdeath = playerUni.tDamage(enemyUni.damage);

        playerHUD.setHP(playerUni.currentHealtH);

        yield return new WaitForSeconds(1f);

        if (isdeath)
        {
            state = bState.Lost;
            battlePhelile();
        }
        else 
        {
            state = bState.Playerturn;
            PTurn();
        
        }


    }

   

    void battlePhelile() 
    {
        if (state == bState.Won)
        {
            dialogueText.text = " Battle Won! ";
        }
        else if (state == bState.Lost) 
        {
            dialogueText.text = " You Died. ";
        }
      
    
    }




    void PTurn() 
    {
        dialogueText.text =" What will you do? ";
    }

    IEnumerator pheal() 
    {
        playerUni.healing(3);

        playerHUD.setHP(playerUni.currentHealtH);
        dialogueText.text = " You regained some of your strangth ";

        yield return new WaitForSeconds(2f);

        state = bState.Enmeyturn;
        StartCoroutine(opponentTurn());


    }

    public void onAttackButton() 
    {
        if (state != bState.Playerturn)
            return;
       StartCoroutine (playerAttec());
    }

    public void onhealButton()
    {
        if (state != bState.Playerturn)
            return;
        StartCoroutine(pheal());
    }

}
