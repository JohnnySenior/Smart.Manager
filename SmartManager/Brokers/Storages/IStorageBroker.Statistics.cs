﻿using SmartManager.Models.Statistics;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SmartManager.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Statistic> InsertStatisticAsync(Statistic statistic);
        IQueryable<Statistic> SelectAllStatistics();
        ValueTask<Statistic> SelectStatisticByIdAsync(Guid statisticId);
        ValueTask<Statistic> UpdateAppolicantAsync(Statistic statistic);
        ValueTask<Statistic> DeleteStatisticAsync(Statistic statistic);
    }
}
