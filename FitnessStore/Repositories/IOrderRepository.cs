using FitnessStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessStore.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);

    }
}
