using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class FixAnimatorTransitions
{
    [MenuItem("Tools/Fix Animator Transitions")]
    static void FixTransitions()
    {
        var controller = Selection.activeObject as AnimatorController;
        if (controller == null)
        {
            Debug.LogWarning("Please select an Animator Controller asset first.");
            return;
        }

        int fixedCount = 0;

        foreach (var layer in controller.layers)
        {
            foreach (var state in layer.stateMachine.states)
            {
                foreach (var t in state.state.transitions)
                {
                    t.hasExitTime = false;                      // No waiting
                    t.hasFixedDuration = true;                   // Duration is in seconds
                    t.duration = 0.05f;                          // Snappy blend
                    t.offset = 0f;                               // Start from frame 0
                    t.interruptionSource = TransitionInterruptionSource.Destination; 
                    fixedCount++;
                }
            }
        }

        Debug.Log($"Fixed {fixedCount} transitions in '{controller.name}'!");
        AssetDatabase.SaveAssets();
    }
}
