using Controls;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    public AttackCommand attackCommand;
    
    public void ExecuteAttack()
    {
        attackCommand.ExecuteAttack();
    }
    
    public void ResetAttack()
    {
        attackCommand.ResetAttack();
    }
}
