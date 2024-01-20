import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import "./component/Flower.js";




import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
        <Flower />
  </React.StrictMode>
);

reportWebVitals();
