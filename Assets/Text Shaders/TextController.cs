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
    }

    public Material defaultMaterial;
    public Material squashMaterial;
    public Material waveMaterial;
    public Material whirlpoolMaterial;

    private float animationSpeed = 1;
    private float animationScale = 1;
    private float offset = 0;
    private float effectRange = 1;
    private Vector3 stretchDirection = new Vector3(1, 0, 0);

    private float oldAnimationSpeed;
    private float oldAnimationScale;
    private float oldOffset;
    private float oldEffectRange;
    private Vector3 oldStretchDirection;

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
    
    
    public void ShaderToUse(int shad)
    {
        shaderToUse = (OPTIONS)shad;
    }

    void SetEnumMaterial(OPTIONS mat)
    {
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
        //textureMaterial = this.GetComponent<Text>().material;

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

        if (oldAnimationSpeed != animationSpeed || oldAnimationScale != animationScale || oldOffset != offset || oldEffectRange != effectRange || oldStretchDirection != stretchDirection)
        {
            textureMaterial.SetFloat("_AnimSpeed", animationSpeed);
            textureMaterial.SetFloat("_AnimScale", animationScale);
            textureMaterial.SetFloat("_Offset", offset);
            textureMaterial.SetFloat("_EffectRange", effectRange);
            textureMaterial.SetVector("_StretchVector", stretchDirection);

            oldAnimationSpeed = animationSpeed;
            oldAnimationScale = animationScale;
            oldOffset = offset;
            oldEffectRange = effectRange;
            oldStretchDirection = stretchDirection;
        }

        if (trackedObject != null)
        {
            trackedPos = new Vector3(trackedObject.transform.position.x, trackedObject.transform.position.y);
            //Debug.Log(trackedPos);
        }
        textureMaterial.SetVector("_ObjWorldPos", this.transform.position);
        textureMaterial.SetVector("_TrackedPos", this.trackedPos);

        //Debug.Log(trackedPos);
    }
}
