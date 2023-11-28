using System.Collections.Generic;
using UnityEngine;

namespace Controls
{
    // The idea behind this class is that action-command bindings depend on the given context
    // The same action (button) can have different commands depending on the context i.e. during gameplay vs. in the menu
    
    [CreateAssetMenu(menuName = "Controls/ActionsCommandsScheme")]
    public class ActionsCommandsScheme : ScriptableObject
    {
        public List<ActionCommandPair> actionCommandList;
    }
}