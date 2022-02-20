import React, { useState, useEffect } from "react";
import Box from "@mui/material/Box";

const Me = () => {
  const [user, setUser] = useState();

  const fetchUser = async () => {
    const response = await fetch("/me");
    const user = await response.json();
    setUser(user);
  };

  useEffect(() => {
    if (!user) {
      fetchUser();
    }
  }, [user]);

  return (
    <Box>
      <div>
        <b>Username</b>: <span>{user?.username}</span>
      </div>
      <div>
        <b>Age</b>: <span>{user?.age}</span>
      </div>
    </Box>
  );
};

export default Me;
