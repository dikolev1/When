using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaryUI : MonoBehaviour
{
    public Inventary inventary;

    //prefabs
    public GameObject cellPrefab;
    public RectTransform inventaryUI;
    //

    private List<Image> _cellImages = new List<Image>();

    private void Awake()
    {
        inventary.SizeUpdate();
        DrawCells();
        UpdateCells();
    }

    // delete this shit later
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            EditorUpdateInventory();
    }
    public void EditorUpdateInventory()
    {
        //inventary.SizeUpdate();
        DrawCells();
        UpdateCells();
        //Debug.Log("Inventary updated");
    }
    //

    public void UpdateCells()
    {
        InventaryCell[,] cellsGrid = inventary.inventaryGrid.cellsGrid;
        int childID = 0;

        for (int x = 0; x < inventary.width; x++)
        {
            for (int y = 0; y < inventary.height; y++)
            {
                InventaryCell cell = cellsGrid[x, y];
                Image image = _cellImages[childID];

                if (cell != null)
                {
                    image.enabled = true;
                    image.sprite = cell.itemData.icon;
                    Debug.Log("Icon set!");
                }
                else
                {
                    image.enabled = false;
                    Debug.Log("Icon did not set!");
                }

                childID++;
            }
        }
    }

    private void DrawCells()
    {
        GetComponent<GridLayoutGroup>().constraintCount = inventary.width;
        int neededCells = inventary.width * inventary.height;
        while (inventaryUI.childCount > neededCells)
        {
            DestroyImmediate(inventaryUI.GetChild(0).gameObject);
        }

        while (inventaryUI.childCount < neededCells)
        {
            Instantiate(cellPrefab, inventaryUI);
        }

        _cellImages.Clear();
        for (int i = 0; i < inventaryUI.childCount; i++)
        {
            Image image = inventaryUI.GetChild(i).GetChild(0).GetComponent<Image>();
            _cellImages.Add(image);
        }
    }

    public void SizeChanged() { DrawCells(); UpdateCells(); }
}
