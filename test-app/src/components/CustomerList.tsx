import React, { useEffect, useState } from 'react';
import { fetchCustomers } from '../api/customerApi';
import { Customer } from '../types/Customer';

const CustomerList: React.FC = () => {
  const [customers, setCustomers] = useState<Customer[]>([]);

  useEffect(() => {
    fetchCustomers().then(setCustomers).catch(console.error);
  }, []);

  return (
    <div>
      <h2>顧客一覧</h2>
      <ul>
        {customers.map(c => (
          <li key={c.id}>{c.name} ({c.email})</li>
        ))}
      </ul>
    </div>
  );
};

export default CustomerList;