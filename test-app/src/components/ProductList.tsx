import React, { useEffect, useState } from 'react';
import { fetchProducts } from '../api/productApi';
import { Product } from '../types/Product';

const ProductList: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetchProducts().then(setProducts).catch(console.error);
  }, []);

  return (
    <div>
      <h2>商品一覧</h2>
      <ul>
        {products.map(p => (
          <li key={p.id}>{p.name} - ¥{p.price}</li>
        ))}
      </ul>
    </div>
  );
};

export default ProductList;