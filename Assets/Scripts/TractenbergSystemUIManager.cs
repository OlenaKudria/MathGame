using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class TractenbergSystemUIManager : MonoBehaviour
{
    public RectTransform title, subtitle;
    public Image[] questionMarks;

    public void TrachtenbergUI()
    {
        title.DOAnchorPos(new Vector2(1, 755), 0.75f);



    }

    public void CloseTrachtenbergUI()
    {

    }
}
