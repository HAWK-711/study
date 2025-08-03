import React, { useState } from 'react';
import UserList from './components/UserList';
import ProductList from './components/ProductList';
import OrderList from './components/OrderList';
import CustomerList from './components/CustomerList';
import CategoryList from './components/CategoryList';

type TableType = 'user' | 'product' | 'order' | 'customer' | 'category';

const App: React.FC = () => {
  const [activeTable, setActiveTable] = useState<TableType>('user');

  const renderTable = () => {
    switch (activeTable) {
      case 'user':
        return <UserList />;
      case 'product':
        return <ProductList />;
      case 'order':
        return <OrderList />;
      case 'customer':
        return <CustomerList />;
      case 'category':
        return <CategoryList />;
      default:
        return null;
    }
  };

  const buttonStyle = (type: TableType) => ({
    marginRight: '10px',
    padding: '8px 16px',
    backgroundColor: activeTable === type ? '#007bff' : '#ccc',
    color: 'white',
    border: 'none',
    borderRadius: '4px',
    cursor: 'pointer',
  });

  return (
    <div style={{ padding: '20px' }}>
      <h1>データ表示切り替え</h1>
      <div style={{ marginBottom: '20px' }}>
        <button style={buttonStyle('user')} onClick={() => setActiveTable('user')}>ユーザー</button>
        <button style={buttonStyle('product')} onClick={() => setActiveTable('product')}>商品</button>
        <button style={buttonStyle('order')} onClick={() => setActiveTable('order')}>注文</button>
        <button style={buttonStyle('customer')} onClick={() => setActiveTable('customer')}>顧客</button>
        <button style={buttonStyle('category')} onClick={() => setActiveTable('category')}>カテゴリ</button>
      </div>
      <div>{renderTable()}</div>
    </div>
  );
};

export default App;