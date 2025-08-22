using UnityEngine;

public class SheepBlendShapeLoop : MonoBehaviour
{
    int blendShapeCount;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    int playIndex = 0;
    bool isFirstLoop = true;
    float initialDelay;

    void Start ()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;

        // Set a random initial delay for the first loop
        initialDelay = Random.Range(1f, 5f); // Adjust the range as needed
    }

    void Update ()
    {
        if (isFirstLoop)
        {
            // Wait for the initial delay before starting the loop
            initialDelay -= Time.deltaTime;
            if (initialDelay <= 0)
            {
                isFirstLoop = false;
            }
            else
            {
                return; // Wait for the initial delay to complete
            }
        }

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
