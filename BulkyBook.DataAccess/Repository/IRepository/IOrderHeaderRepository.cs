﻿using System;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateStripPaymentId(int id, string sessionId, string paymentIntentId);
    }
}

