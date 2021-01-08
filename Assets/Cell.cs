using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public enum ColorKind
    {
        blue, red, yellow, orenge,purple
    }
    //Row column
    public int row; //행
    public int column; //열
    public ColorKind colorKind;
    public List<int[]> row_Plus_keys;
    public List<int[]> row_Minus_keys;
    public List<int[]> column_Plus_keys;
    public List<int[]> column_Minus_keys;
    public List<int[]> plus_keys; //수직
    public List<int[]> Minus_keys;
    //public int[] key;

    public void Init()
    {
        for (int i = 0; i < 4; ++i)
        {
            row_Plus_keys.Add(new int[2] { row, column + i + 1 });
            row_Minus_keys.Add(new int[2] { row, column - i - 1 });
            column_Plus_keys.Add(new int[2] { row + i + 1, column });
            column_Minus_keys.Add(new int[2] { row - i - 1, column });
            plus_keys.Add(new int[2] { row + i + 1, column + i + 1 });
            Minus_keys.Add(new int[2] { row - i - 1, column - i - 1 });
        }
    }
    bool CheckSameColor(int index)
    {
        CellMamager c = CellMamager.instansce;
        if (c.cells.ContainsKey(row_Plus_keys[index]))
        {
            if (colorKind == c.cells[row_Plus_keys[index]].colorKind)
            {
                return true;
            }
        }
        return false;
    }
    public List<int[]> GetSameCell()
    {

        if (CheckSameColor(0) && CheckSameColor(1) && CheckSameColor(2) && CheckSameColor(3))
        {
            List<int[]> aa = new List<int[]>();
            aa.Add(row_Plus_keys[0]);
            aa.Add(row_Plus_keys[1]);
            aa.Add(row_Plus_keys[2]);
            aa.Add(row_Plus_keys[3]);
            return aa;
        }
        else if (CheckSameColor(0) && CheckSameColor(1) && CheckSameColor(2))
        {
            List<int[]> aa = new List<int[]>();
            aa.Add(row_Plus_keys[0]);
            aa.Add(row_Plus_keys[1]);
            aa.Add(row_Plus_keys[2]);
            return aa;
        }
        else
        {
            return null;
        }
          
    }
    //파괴
    public void CellDestruction()
    {

    }

    //파괴타임지나고 나서 자리재배정
    public void Relocation()
    {

    }


    /// <summary>
    /// 같은 칼러인지 확인
    /// </summary>
    public void CheckSameColor()
    {
      
        //row_Plus_keys.Add(new int[2] { row, column + 1 });
        //row_Plus_keys.Add(new int[2] { row, column + 2 });
        //row_Plus_keys.Add(new int[2] { row, column + 3 });
        //row_Plus_keys.Add(new int[2] { row, column + 4 });



        //row_Plus_keys.Add(new int[4] { column + 1, column + 2, column + 3, column + 4 });
        //row_Minus_keys.Add(new int[4] { column - 1, column - 2, column - 3, column - 4 });
        //column_Plus_keys.Add(new int[4] { row + 1, row + 2, row + 3, row + 4 });
        //column_Minus_keys.Add(new int[4] { row - 1, row - 2, row - 3, row - 4 });
        //int[] a = { row, column + 1 };
        //int[] b = { row, column + 2 };
        //int[] c = { row, column + 3 };
        //int[] d = { row, column + 4 };
        //if(a[0] )
        //CellMamager c = CellMamager.instansce;
        //c.cells.ContainsKey(new int[key[0], key[1] + 1])
        //for (int i = 0; i < c.cells.Count; ++i)
        //{
        //    for (int j = 0; j < c.cells.Count; ++j)
        //    {

        //    }
        //}

        //if (c.cells.ContainsKey(row))
        //{
        //    c.cells[row]
        //}   
    }
}
