﻿using ShoppingApp.Entity.Abstract;
using ShoppingApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Concrete
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumOrderType OrderType { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public enum EnumOrderState
    {
        Waiting=0,
        Unpaid=1,
        Completed=2
    }
    public enum EnumOrderType
    {
        CreditCard=0,
        Eft=1
    }
}
