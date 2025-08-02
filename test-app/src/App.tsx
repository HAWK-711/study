import React from 'react';
import './App.css';
import UserList from './components/UserList';

function App() {
  return (
    <div className="App">
      <h1>ユーザー管理</h1>
      <UserList />
    </div>
  );
}

export default App;