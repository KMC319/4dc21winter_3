using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://tech.pjin.jp/blog/2017/04/18/unity_background_scroll/
/// �y�w�i�̃R���g���[���p�N���X�z
///     �w�i��3���A�J�������猩�؂ꂽ���荞��
/// </summary>

public class BackGroundController : MonoBehaviour
{

    // �w�i�̖���
    public int spriteCount = 3;
    // �w�i����荞��
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
        // ���W�ϊ�
        //Vector3 myViewport = Camera.main.WorldToViewportPoint(bgTfm.position);
        Vector3 myViewport = camera.WorldToViewportPoint(bgTfm.position);
        // �w�i�̉�荞��(�J������X���v���X�����Ɉړ���)
        if (myViewport.x < leftOffset)
        {
            bgTfm.position += Vector3.right * ((width-delay) * spriteCount);
        }
        // �w�i�̉�荞��(�J������X���}�C�i�X�����Ɉړ���)
        else if (myViewport.x > rightOffset)
        {
            // bgTfm.position -= Vector3.right * (width * spriteCount);
        }
    }
}
