using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://tech.pjin.jp/blog/2017/04/18/unity_background_scroll/
/// y”wŒi‚ÌƒRƒ“ƒgƒ[ƒ‹—pƒNƒ‰ƒXz
///     ”wŒi‚Í3–‡AƒJƒƒ‰‚©‚çŒ©Ø‚ê‚½‚ç‰ñ‚è‚Ş
/// </summary>

public class BackGroundController : MonoBehaviour
{

    // ”wŒi‚Ì–‡”
    public int spriteCount = 3;
    // ”wŒi‚ª‰ñ‚è‚İ
    float rightOffset = 1.5f;
    float leftOffset = -1.5f;

    Transform bgTfm;
    SpriteRenderer mySpriteRndr;
    float width;

    public Camera camera;

    public float delay;

    void Start()
    {
        bgTfm = transform;
        mySpriteRndr = GetComponent<SpriteRenderer>();
        width = mySpriteRndr.bounds.size.x;
        
    }


    void Update()
    {
        Debug.Log(width);
        // À•W•ÏŠ·
        //Vector3 myViewport = Camera.main.WorldToViewportPoint(bgTfm.position);
        Vector3 myViewport = camera.WorldToViewportPoint(bgTfm.position);
        // ”wŒi‚Ì‰ñ‚è‚İ(ƒJƒƒ‰‚ªX²ƒvƒ‰ƒX•ûŒü‚ÉˆÚ“®)
        if (myViewport.x < leftOffset)
        {
            bgTfm.position += Vector3.right * ((width-delay) * spriteCount);
        }
        // ”wŒi‚Ì‰ñ‚è‚İ(ƒJƒƒ‰‚ªX²ƒ}ƒCƒiƒX•ûŒü‚ÉˆÚ“®)
        else if (myViewport.x > rightOffset)
        {
            // bgTfm.position -= Vector3.right * (width * spriteCount);
        }
    }
}
