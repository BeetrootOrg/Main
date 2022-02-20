import React from 'react';
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import Me from './components/me';
import Container from '@mui/material/Container';

function App() {
  return (
    <Container maxWidth="sm">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Me />} />
        </Routes>
      </BrowserRouter>
    </Container>
  );
}

export default App;
