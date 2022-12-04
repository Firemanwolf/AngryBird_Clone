using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;

public class DataManager : MonoBehaviour
{
    private Rigidbody2D rb;
    public Piggie pig;
    List<Dictionary<string, object>> myData;

    private void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        string filePath = Application.dataPath + "/Game_data.xlsx";
        Excel xls = ExcelHelper.LoadExcel(filePath);
        myData = CSVReader.Read("Game_data");
        for (int i = 0; i < myData.Count; i++)
        {
            if (this.CompareTag((string)myData[i]["name"]))
            {
                rb.mass= System.Convert.ToSingle(myData[i]["mass"]);
                rb.angularDrag = System.Convert.ToSingle(myData[i]["angular drag"]);
                rb.gravityScale = System.Convert.ToSingle(myData[i]["gravity scale"]);
                rb.drag = System.Convert.ToSingle(myData[i]["linear drag"]);
                if(pig != null)
                {
                    pig.MaxSpeed = System.Convert.ToSingle(myData[i]["maximum speed"]);
                    pig.MinSpeed = System.Convert.ToSingle(myData[i]["minimum speed"]);
                    pig.HP = System.Convert.ToSingle(myData[i]["HP"]);
                }
            }
        }
        //xls.Tables[0].
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
