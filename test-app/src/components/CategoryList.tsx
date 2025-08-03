import React, { useEffect, useState } from 'react';
import { fetchCategories } from '../api/categoryApi';
import { Category } from '../types/Category';

const CategoryList: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([]);

  useEffect(() => {
    fetchCategories().then(setCategories).catch(console.error);
  }, []);

  return (
    <div>
      <h2>カテゴリ一覧</h2>
      <ul>
        {categories.map(c => (
          <li key={c.id}>{c.name}</li>
        ))}
      </ul>
    </div>
  );
};

export default CategoryList;