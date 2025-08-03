import React, { useEffect, useState } from 'react';
import { fetchOrders } from '../api/orderApi';
import { Order } from '../types/Order';

const OrderList: React.FC = () => {
  const [orders, setOrders] = useState<Order[]>([]);

  useEffect(() => {
    fetchOrders().then(setOrders).catch(console.error);
  }, []);

  return (
    <div>
      <h2>注文一覧</h2>
      <ul>
        {orders.map(o => (
          <li key={o.id}>注文ID: {o.id}, ユーザーID: {o.userId}, 商品ID: {o.productId}, 数量: {o.quantity}</li>
        ))}
      </ul>
    </div>
  );
};

export default OrderList;