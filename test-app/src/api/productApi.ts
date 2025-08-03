import axios from 'axios';
import { Product } from '../types/Product';

export const fetchProducts = async (): Promise<Product[]> => {
  const res = await axios.get('http://localhost:5000/api/products');
  return res.data;
};
