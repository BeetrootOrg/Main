import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import Layout from './Layout';
import { withEmotionCache } from '@emotion/react';
import reportWebVitals from './reportWebVitals';

const Document = withEmotionCache(() => {
  return <React.StrictMode>
    <Layout>
      <App />
    </Layout>
  </React.StrictMode>
})

ReactDOM.render(
  <Document></Document>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
