using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleDialogueB : MonoBehaviour
{
    [SerializeField] int letterPerS;
    [SerializeField] Color pickedColour; 

    [SerializeField] Text dialogueText;
    [SerializeField] GameObject aSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetail;

    //Reference for the two texts in the "aSelector"
    [SerializeField] List<Text> actionText;
    public List<Text> moveText;

    public Text PPText;
    public Text typeText;

    public void dialogueSet(string dialogue) 
    {
        dialogueText.text = dialogue;
    }

    public IEnumerator typingDialogue(string dialogue) 
    {
        //Creates typing effect
        dialogueText.text = "";
        foreach (var letter in dialogue.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / letterPerS);
        }
    }

    public void enableDialogue(bool enabled) 
    {
        dialogueText.enabled = enabled;
    }

    public void enableASelector(bool enabled) 
    {
        aSelector.SetActive(enabled);
    }

    public void enableMoveSelectoe(bool enabled) 
    {
        moveSelector.SetActive(enabled);
        moveDetail.SetActive(enabled);
    }

    public void UpdatedActionSelect(int selectedAct)
    {
        for (int i = 0; i < actionText.Count; ++i) 
        {
            if (i == selectedAct)
                actionText[i].color = pickedColour;
            else
                actionText[i].color = Color.black;
        }
    }

    public void UpdateMSelection(int selectedMove,MoveScript move)
    {
        for (int i = 0; i < moveText.Count; ++i)
        {
            if (i == selectedMove)
                moveText[i].color = pickedColour;
            else
                moveText[i].color = Color.black
;
        }
        PPText.text = $"PP{move.PP}/{move.Base.PP}";
        typeText.text = move.Base.Type.ToString();
    }

    public void setMovegama(List<MoveScript> moves) 
    {
        for (int i = 0; i < moveText.Count; ++i) 
        {
            // Sets name of action/move to moveText //
            if (i < moves.Count)
                moveText[i].text = moves[i].Base.Name;
            else
                moveText[i].text = "-";// if player level is too low//
        }
    
    }
}
