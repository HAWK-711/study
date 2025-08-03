import axios from 'axios';
import { Order } from '../types/Order';

export const fetchOrders = async (): Promise<Order[]> => {
  const response = await axios.get('http://localhost:5000/api/orders');
  return response.data;
};