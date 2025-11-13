using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class AnimatorTransitionValidator
{
    [MenuItem("Tools/Validate Animator Transitions")]
    public static void ValidateAnimatorTransitions()
    {
        var animator = Selection.activeObject as AnimatorController;
        if (animator == null)
        {
            Debug.LogError(" Please select your Animator Controller asset (e.g., 'Player Controller') in the Project window first.");
            return;
        }

        int warnings = 0;
        Debug.Log($"=== Validating Animator: {animator.name} ===");

        foreach (var layer in animator.layers)
        {
            foreach (var childState in layer.stateMachine.states)
            {
                var stateName = childState.state.name;

                foreach (var transition in childState.state.transitions)
                {
                    var target = transition.destinationState?.name ?? "Exit";
                    foreach (var cond in transition.conditions)
                    {
                        // ---- Rule 1: Idle states should not require State == 1 ----
                        if (target.ToLower().Contains("idle") && cond.parameter == "State" && Mathf.Approximately(cond.threshold, 1f))
                        {
                            Debug.LogWarning($" Invalid: {stateName} {target} requires State==1 (should be 0).", transition);
                            warnings++;
                        }

                        // ---- Rule 2: Walk states should not require State == 0 ----
                        if (target.ToLower().Contains("walk") && cond.parameter == "State" && Mathf.Approximately(cond.threshold, 0f))
                        {
                            Debug.LogWarning($" Invalid: {stateName}  {target} requires State==0 (should be 1).", transition);
                            warnings++;
                        }

                        // ---- Rule 3: Direction mismatch (Idle/WalkDownLeft etc.) ----
                        if (cond.parameter == "Direction" && target.ToLower().Contains("downleft") && !Mathf.Approximately(cond.threshold, 4f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName} {target} uses Direction={cond.threshold} (expected 4).", transition);
                            warnings++;
                        }
                        if (cond.parameter == "Direction" && target.ToLower().Contains("downright") && !Mathf.Approximately(cond.threshold, 5f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName} {target} uses Direction={cond.threshold} (expected 5).", transition);
                            warnings++;
                        }
                        if (cond.parameter == "Direction" && target.ToLower().Contains("down") && !target.ToLower().Contains("left") && !target.ToLower().Contains("right") && !Mathf.Approximately(cond.threshold, 0f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName}  {target} uses Direction={cond.threshold} (expected 0).", transition);
                            warnings++;
                        }
                        if (cond.parameter == "Direction" && target.ToLower().Contains("left") && !target.ToLower().Contains("down") && !target.ToLower().Contains("up") && !Mathf.Approximately(cond.threshold, 2f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName}  {target} uses Direction={cond.threshold} (expected 2).", transition);
                            warnings++;
                        }
                        if (cond.parameter == "Direction" && target.ToLower().Contains("right") && !target.ToLower().Contains("down") && !target.ToLower().Contains("up") && !Mathf.Approximately(cond.threshold, 3f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName}  {target} uses Direction={cond.threshold} (expected 3).", transition);
                            warnings++;
                        }
                        if (cond.parameter == "Direction" && target.ToLower().Contains("up") && !target.ToLower().Contains("left") && !target.ToLower().Contains("right") && !Mathf.Approximately(cond.threshold, 1f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName}  {target} uses Direction={cond.threshold} (expected 1).", transition);
                            warnings++;
                        }
                        if (cond.parameter == "Direction" && target.ToLower().Contains("upleft") && !Mathf.Approximately(cond.threshold, 6f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName}  {target} uses Direction={cond.threshold} (expected 6).", transition);
                            warnings++;
                        }
                        if (cond.parameter == "Direction" && target.ToLower().Contains("upright") && !Mathf.Approximately(cond.threshold, 7f))
                        {
                            Debug.LogWarning($" Invalid Direction: {stateName}  {target} uses Direction={cond.threshold} (expected 7).", transition);
                            warnings++;
                        }
                    }
                }
            }
        }

        if (warnings == 0)
            Debug.Log(" All transitions have correct State/Direction logic!");
        else
            Debug.LogWarning($" Validation complete: {warnings} issues found.");
    }
}
