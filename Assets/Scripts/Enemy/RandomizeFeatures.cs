using UnityEngine;
using Random = UnityEngine.Random;

public class RandomizeFeatures : MonoBehaviour
{
    public GameObject body;
    public Material[] bodyAMats;
    public Material[] bodyBMats;
    public Material[] bodyCMats;
    [Space(20)]
    public GameObject[] heads;
    public Material[] headAMats;
    public Material[] headBMats;
    public Material[] headCMats;
    [Space(20)]
    public GameObject[] hornsA;
    public Material[] hornsAMats;
    [Space(20)]
    public GameObject[] hornsB;
    public Material[] hornsBMats;
    [Space(20)]
    public GameObject[] hornsC;
    public Material[] hornsCMats;

    int matIndex;
    int styleIndex;

    private void Start()
    {
        styleIndex = Random.Range(0, 2);
        matIndex = Random.Range(0, 4);
        StyleSwitch();
    }

    void StyleSwitch()
    {
        switch (styleIndex)
        {
            case 0:
                body.GetComponent<Renderer>().material = bodyAMats[matIndex];
                heads[styleIndex].GetComponent<Renderer>().material = headAMats[matIndex];
                for (int i = 0; i < hornsA.Length - 1; i++)
                {
                    hornsA[i].GetComponent<Renderer>().material = hornsAMats[matIndex];
                }
                break;

            case 1:
                body.GetComponent<Renderer>().material = bodyBMats[matIndex];
                heads[styleIndex].GetComponent<Renderer>().material = headBMats[matIndex];
                for (int i = 0; i < hornsB.Length - 1; i++)
                {
                    hornsB[i].GetComponent<Renderer>().material = hornsBMats[matIndex];
                }
                break;

            case 2:
                body.GetComponent<Renderer>().material = bodyCMats[matIndex];
                heads[styleIndex].GetComponent<Renderer>().material = headCMats[matIndex];
                for (int i = 0; i < hornsC.Length - 1; i++)
                {
                    hornsC[i].GetComponent<Renderer>().material = hornsCMats[matIndex];
                }
                break;
        }
    }
}
