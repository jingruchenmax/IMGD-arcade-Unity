using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class ArcadeDetector
{
    private static bool m_isArcadeMachine = false;
    public static bool IsArcadeMachine => m_isArcadeMachine;

#if UNITY_WEBGL && !UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void DetectArcade() {
        m_isArcadeMachine = CheckIsArcadeMachine();
    }

    [DllImport("__Internal")]
    private static extern bool CheckIsArcadeMachine();
#endif
}
