﻿using BrewUpStore.ReadModel.Abstracts;

namespace BrewUpStore.ReadModel.Models;

public class LastEventPosition : ModelBase
{
    public long CommitPosition { get; set; }
    public long PreparePosition { get; set; }

    protected LastEventPosition()
    {   
    }

    public LastEventPosition(string id)
    {
        Id = id;
        CommitPosition = -1;
        PreparePosition = -1;
    }
}