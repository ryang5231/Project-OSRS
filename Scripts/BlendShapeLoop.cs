using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeLoop : MonoBehaviour
{
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int playIndex = 0;
    // float blendSpeed = 50f; // Adjust this value to control the speed of the animation

    void Start ()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;
    }

    void Update ()
    {
        // Reset the weight of the previous blend shape
        int previousIndex = (playIndex == 0) ? blendShapeCount - 1 : playIndex - 1;
        skinnedMeshRenderer.SetBlendShapeWeight(previousIndex, 0f);
        
        // Set the weight of the current blend shape to 100
        skinnedMeshRenderer.SetBlendShapeWeight(playIndex, 100f);
        
        // Move to the next blend shape index
        playIndex++;
        
        // Wrap around to the beginning if reached the end
        if(playIndex >= blendShapeCount)
            playIndex = 0;
    }
}
