import React, { useEffect, useState } from 'react';

type SampleItem = {
  id: number;
  name: string;
  description: string;
};

function App() {
  const [items, setItems] = useState<SampleItem[]>([]);

  useEffect(() => {
    fetch('http://localhost:5000/api/sample') // ポートは環境によって調整
      .then(res => res.json())
      .then(data => setItems(data));
  }, []);

  return (
    <div>
      <h1>サンプル一覧</h1>
      <ul>
        {items.map(item => (
          <li key={item.id}>
            <strong>{item.name}</strong>: {item.description}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;