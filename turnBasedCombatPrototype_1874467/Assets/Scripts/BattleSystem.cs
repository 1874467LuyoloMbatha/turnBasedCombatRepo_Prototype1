using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum battleStates {Start, PlayerAction, PMove, EnemyMove, Busy }

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerU;
    [SerializeField] BattleUnit enemyU;
    [SerializeField] battleHUD playerHUD;
    [SerializeField] battleHUD enemyHUD;
    [SerializeField] BattleDialogueB dialogueBox;

    battleStates state;
    int currentAct;
    int currentM;
    private void Start()
    {
       StartCoroutine (BattleSetUp()); 
    }

    public IEnumerator BattleSetUp() 
    {
        playerU.blSetup();
        enemyU.blSetup();
        playerHUD.dataSetup(playerU.fighters);
        enemyHUD.dataSetup(enemyU.fighters);

        dialogueBox.setMovegama(playerU.fighters.moveS);

        //String interperlation($)// 
        yield return (dialogueBox.typingDialogue($" A random {enemyU.fighters._base.Name} appeared!"));
        yield return new WaitForSeconds(1f);

        PlayerAct();
    }

    public void PlayerAct() 
    {
        state = battleStates.PlayerAction;
        StartCoroutine (dialogueBox.typingDialogue("Choose an action."));
        dialogueBox.enableASelector(true);
    }

    void PlayerMove() 
    {
        state = battleStates.PlayerAction;
        dialogueBox.enableASelector(false);
        dialogueBox.enableDialogue(false);
        dialogueBox.enableMoveSelectoe(true);
    }

    IEnumerator PerformpMove() 
    {
        var move = playerU.fighters.moveS[currentM];
        yield return dialogueBox.typingDialogue($"{playerU.fighters._base.Name} used");

        yield return new WaitForSeconds(1f);

       



    }

    private void Update()
    {
        if (state == battleStates.PlayerAction)
        {
            handleASelection();
        }
        else if (state == battleStates.PMove)
        {
            HandleMSelection();
        }
    }

    void handleASelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAct < 1)
                ++currentAct;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            if (currentAct > 0)
                --currentAct;
        }

        dialogueBox.UpdatedActionSelect(currentAct);
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            if (currentAct == 0)
            {
                //fighter//
                PlayerMove();

            }
            else if (currentAct == 1) 
            {
                //run//

            
            }
        
        }

    }

    void HandleMSelection()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentM < playerU.fighters.moveS.Count - 1)
                ++currentM;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentM > 0)
                --currentM;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentM < playerU.fighters.moveS.Count - 2)
                currentM += 2;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentM > 1)
                currentM -= 2;
        }

        dialogueBox.UpdateMSelection(currentM, playerU.fighters.moveS[currentM]);

        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            dialogueBox.enableMoveSelectoe(false);
            dialogueBox.enableDialogue(true);
            StartCoroutine(PerformpMove());
        
        }
    }
}
