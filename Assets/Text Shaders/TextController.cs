using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    public enum OPTIONS
    {
        None = 0,
        Squash = 1,
        Wave = 2,
        Whirlpool = 3,
        WaveAndWhirlpool = 4,
        ShiftText = 5
    }

    public Material defaultMaterial;
    public Material squashMaterial;
    public Material waveMaterial;
    public Material whirlpoolMaterial;
    public Material combinedMaterial;

    private float animationSpeed = 1;
    private float animationScale = 1;
    [SerializeField]
    private float offset = 0;
    private float effectRange = 1;
    private float frequency = 1;
    private Vector3 stretchDirection = new Vector3(1, 0, 0);
    [SerializeField]
    private Vector3 shiftDirection = new Vector3(1, -1, 0);

    private GameObject duplicateText;

    private float oldAnimationSpeed = 1;
    private float oldAnimationScale = 1;
    private float oldOffset = 0;
    private float oldEffectRange = 1;
    private float oldFrequency = 1;
    private Vector3 oldStretchDirection = new Vector3(1, 0, 0);

    private GameObject trackedObject;
    private Vector3 trackedPos;
    private Material textureMaterial;

    public OPTIONS shaderToUse = OPTIONS.None;
    private OPTIONS lastMat;

    public float AnimationSpeed { get => animationSpeed; set => animationSpeed = value; }
    public float AnimationScale { get => animationScale; set => animationScale = value; }
    public float Offset { get => offset; set => offset = value; }
    public float EffectRange { get => effectRange; set => effectRange = value; }
    public Vector3 StretchDirection { get => stretchDirection; set => stretchDirection = value; }
    public float Frequency { get => frequency; set => frequency = value; }
    public Vector3 ShiftDirection { get => shiftDirection; set => shiftDirection = value; }

    public void ShaderToUse(int shad)
    {
        shaderToUse = (OPTIONS)shad;
    }

    void SetEnumMaterial(OPTIONS mat)
    {
        Destroy(duplicateText);
        switch (mat)
        {
            case OPTIONS.Squash:
                textureMaterial = Material.Instantiate(squashMaterial);
                break;
            case OPTIONS.Wave:
                textureMaterial = Material.Instantiate(waveMaterial);
                break;
            case OPTIONS.Whirlpool:
                textureMaterial = Material.Instantiate(whirlpoolMaterial);
                break;
            case OPTIONS.WaveAndWhirlpool:
                textureMaterial = Material.Instantiate(combinedMaterial);
                break;
            case OPTIONS.ShiftText:
                textureMaterial = Material.Instantiate(defaultMaterial);
                duplicateText = GameObject.Instantiate(this.gameObject);
                Destroy(duplicateText.GetComponent<TextController>());
                duplicateText.transform.SetParent(this.transform.parent);
                duplicateText.transform.localScale = Vector3.one;
                duplicateText.SetActive(true);
                break;
            default:
                textureMaterial = Material.Instantiate(defaultMaterial);
                break;
        }

        this.GetComponent<Text>().material = textureMaterial;

    }

    // Start is called before the first frame update
    void Start()
    {
        if (trackedObject == null)
        {
            trackedPos = Vector3.zero;
        }
        else
        {
            trackedPos = trackedObject.transform.position;
        }

        textureMaterial = Material.Instantiate(defaultMaterial);

        duplicateText = GameObject.Instantiate(this.gameObject);
        Destroy(duplicateText.GetComponent<TextController>());
        duplicateText.transform.SetParent(this.transform.parent);
        duplicateText.transform.localScale = Vector3.one;
        duplicateText.SetActive(false);

        SetEnumMaterial(shaderToUse);
        lastMat = shaderToUse;

        trackedObject = GameObject.FindGameObjectWithTag("EyeTracker");
    }

    public void SetTrackedObject(GameObject obj)
    {
        trackedObject = obj;
        trackedPos = trackedObject.transform.position;
    }

        // Update is called once per frame
    void Update()
    {
        if (lastMat != shaderToUse)
        {
            SetEnumMaterial(shaderToUse);
            lastMat = shaderToUse;
        }

        if (oldAnimationSpeed != animationSpeed || oldAnimationScale != animationScale || oldOffset != offset || oldEffectRange != effectRange || oldFrequency != frequency|| oldStretchDirection != stretchDirection)
        {
            textureMaterial.SetFloat("_AnimSpeed", animationSpeed);
            textureMaterial.SetFloat("_AnimScale", animationScale);
            textureMaterial.SetFloat("_Offset", offset);
            textureMaterial.SetFloat("_EffectRange", effectRange);
            textureMaterial.SetFloat("_Frequency", frequency);
            textureMaterial.SetVector("_StretchVector", stretchDirection);

            oldAnimationSpeed = animationSpeed;
            oldAnimationScale = animationScale;
            oldOffset = offset;
            oldEffectRange = effectRange;
            oldFrequency = frequency;
            oldStretchDirection = stretchDirection;
        }

        if (trackedObject != null)
        {
            trackedPos = new Vector3(trackedObject.transform.position.x, trackedObject.transform.position.y);
        }
        textureMaterial.SetVector("_ObjWorldPos", this.transform.position);
        textureMaterial.SetVector("_TrackedPos", this.trackedPos);

        if (shaderToUse == OPTIONS.ShiftText)
        {
            duplicateText.transform.position = this.transform.position + ShiftDirection * offset;
        }
    }
}
