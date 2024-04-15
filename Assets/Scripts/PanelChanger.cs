using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 矢印をクリックしたら特定のPanelを表示する
public class PanelChanger : MonoBehaviour
{
    public static PanelChanger Instance { get; private set; }

    public string CurrentPanelName { get; private set; }

    public GameObject PanelParent;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject BackArrow;

    /// <summary>
    /// パネル位置情報クラス
    /// </summary>
    private class PanelPositionInfo
    {
        public Vector2 Position { get; set; }
        public MoveNames MoveNames { get; set; }
    }

    /// <summary>
    /// 矢印ボタン移動先クラス
    /// それぞれ左、右、下矢印を押したときの移動先の名前
    /// </summary>
    private class MoveNames
    {
        public string Left { get; set; }
        public string Right { get; set; }
        public string Back { get; set; }
    }

    /// <summary>
    /// 全パネルの位置情報
    /// 
    /// ※※※※※※注意※※※※※※
    /// Positionに指定する座標は、プラスマイナスを逆転させる
    /// ※※※※※※注意※※※※※※
    /// </summary>
    private Dictionary<string, PanelPositionInfo> _PanelPositionInfoes = new Dictionary<string, PanelPositionInfo>
    {
        {
            "1",
            new PanelPositionInfo
            {
                Position = new Vector2(0, 0),
                MoveNames = new MoveNames
                {
                    //移動先のパネル名
                    Right = "2",
                    Back = "3"
                }
            }
        },
        {
            "2",
            new PanelPositionInfo
            {
                Position = new Vector2(-1000, 0),
                MoveNames = new MoveNames
                {
                    //移動先のパネル名
                    Left = "1",
                    Back = "4"
                }
            }
        },
        {
            "3",
            new PanelPositionInfo
            {
                Position = new Vector2(0, 1500),
                MoveNames = new MoveNames
                {
                    //移動先のパネル名
                    Right = "4",
                    Back = "1"
                }
            }
        },
        {
            "4",
            new PanelPositionInfo
            {
                Position = new Vector2(-1000, 1500),
                MoveNames = new MoveNames
                {
                    //移動先のパネル名
                    Left = "3",
                    Back = "2"
                }
            }
        },
    };

    void Start()
    {
        Instance = this;

        ChangePanel("1");

        LeftArrow.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangePanel(_PanelPositionInfoes[CurrentPanelName].MoveNames.Left);
        });
        RightArrow.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangePanel(_PanelPositionInfoes[CurrentPanelName].MoveNames.Right);
        });
        BackArrow.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangePanel(_PanelPositionInfoes[CurrentPanelName].MoveNames.Back);
        });
    }

    public void ChangePanel(string panelName)
    {
        if (panelName == null) return;

        CurrentPanelName = panelName;
        PanelParent.transform.localPosition = _PanelPositionInfoes[CurrentPanelName].Position;
        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_PanelPositionInfoes[CurrentPanelName].MoveNames.Left == null)
            LeftArrow.SetActive(false);
        else LeftArrow.SetActive(true);
        if (_PanelPositionInfoes[CurrentPanelName].MoveNames.Right == null)
            RightArrow.SetActive(false);
        else RightArrow.SetActive(true);
        if (_PanelPositionInfoes[CurrentPanelName].MoveNames.Back == null)
            BackArrow.SetActive(false);
        else BackArrow.SetActive(true);
    }
}

