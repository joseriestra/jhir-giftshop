using Business.General;
using Entities.Classes;
using Entities.Constants;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Classes
{
    public class OrderBusiness : BaseBusiness
    {

        public void Save(Order order)
        {
            Factory.OrdersRepository.Save(order);
        }

        public Order FindById(long id, params string[] relationships)
        {
            Order order = Factory.OrdersRepository.FindById(id, relationships);
            if (order != null)
            {
                return order;
            }
            else
            {
                throw new BusinessException(BusinessConstants.ORDER_NOT_FOUND);
            }
        }

        public void Delete(long id)
        {
            Order order = Factory.OrdersRepository.FindById(id);
            if (order == null)
            {
                throw new BusinessException(BusinessConstants.ORDER_NOT_FOUND);
            }
            Factory.OrdersRepository.Delete(order);
        }

        public IList<Order> FindAllOrders()
        {
            return Factory.OrdersRepository.FindAll();
        }

        public Order FindHistoryOrdersByUser(long userId)
        {
            return Factory.OrdersRepository.FindHistoryOrdersByUser(userId);
        }
    }
}
