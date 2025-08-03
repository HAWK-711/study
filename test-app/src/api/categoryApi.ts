import axios from 'axios';
import { Category } from '../types/Category';

export const fetchCategories = async (): Promise<Category[]> => {
  const response = await axios.get('http://localhost:5000/api/categories');
  return response.data;
};