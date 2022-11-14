using System.Collections.Generic;
using UnityEngine;

public class Database
{
    private List<StatusModel> statusModels = new List<StatusModel>();

    public List<StatusModel> StatusModels => statusModels;
    public Database()
    {
        //仮の設定
        statusModels.Add(new StatusModel
        {
            name = "test1",
            description = "test content1"
        });
        statusModels.Add(new StatusModel
        {
            name = "test2",
            description = "test content2"
        });
    }
}
