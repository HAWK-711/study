import axios from 'axios';
import { Customer } from '../types/Customer';

export const fetchCustomers = async (): Promise<Customer[]> => {
  const response = await axios.get('http://localhost:5000/api/customers');
  return response.data;
};