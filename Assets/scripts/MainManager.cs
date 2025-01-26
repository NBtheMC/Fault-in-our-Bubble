using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VNCreator;

public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager Instance;
    public VNCreator_DisplayUI vn;
    public NodeData savedNode;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
