﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
    }
}