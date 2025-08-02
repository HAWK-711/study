import axios from 'axios';
import { User } from '../types/User';

const BASE_URL = 'http://localhost:5000/api/users'; // ASP.NET Core の URL に合わせて変更

export const fetchUsers = async (): Promise<User[]> => {
  const response = await axios.get<User[]>(BASE_URL);
  return response.data;
};