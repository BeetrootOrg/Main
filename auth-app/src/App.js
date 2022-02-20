import React, { useState, useEffect } from 'react';
import { ThemeProvider } from '@emotion/react';
import Layout from './Layout'
import theme from './theme';

function App() {
  const [weather, setWeather] = useState();

  const fetchWeather = async () => {
    const response = await fetch('/weatherForecast');
    const result = await response.json();
    setWeather(result);
  };

  useEffect(() => {
    if (!weather) {
      fetchWeather();
    }
  }, [weather]);

  return (
    <ThemeProvider theme={theme}>
      <Layout>
        {weather?.map((w, index) => (<div key={index}>
          <div>
            <b>Date</b>: <span>{w.date}</span>
          </div>
          <div>
            <b>Temperature</b>: <span>{w.temperatureC}</span>
          </div>
          <div>
            <b>Summary</b>: <span>{w.summary}</span>
          </div>
        </div>))}
      </Layout>
    </ThemeProvider>
  );
}

export default App;
