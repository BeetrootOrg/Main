import React, { useState, useEffect } from 'react';
import { ThemeProvider } from '@emotion/react';
import CssBaseline from '@mui/material/CssBaseline';
import theme from './theme';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';

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
      <CssBaseline />
      <Grid container spacing={2}>
        {weather?.map((w, index) => (<Grid key={index} item xs={6}>
          <Card>
            <Paper />
            <CardContent>
              <Typography variant="h3" color="text.primary" gutterBottom>
                Weather
              </Typography>
              <Typography variant="h5" component="span">
                Date
              </Typography>
              <Typography sx={{ mb: 1.5 }} color="text.secondary">
                {w.date}
              </Typography>

              <Typography variant="h5" component="span">
                Temperature
              </Typography>
              <Typography sx={{ mb: 1.5 }} color="text.secondary">
                {w.temperatureC}
              </Typography>

              <Typography variant="h5" component="span">
                Summary
              </Typography>
              <Typography sx={{ mb: 1.5 }} color="text.secondary">
                {w.summary}
              </Typography>
            </CardContent>
          </Card>
        </Grid>))}
      </Grid>
    </ThemeProvider>
  );
}

export default App;
