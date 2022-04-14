import React from "react";
import { useState, useEffect } from "react";
import TodoForm from "./TodoForm";
import axios from "axios";
import TodoTable from "./TodoTable";
import Grid from "@material-ui/core/Grid";
import Container from "@material-ui/core/Container";
import { Typography } from "@mui/material";

 const API_URL = process.env.REACT_APP_API_URL;
 const IMAGE_VERSION = process.env.REACT_APP_IMAGE_VERSION;
 //const API_URL = "https://localhost:44340";


const App = (params) => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const resp = await axios.get( API_URL + "/api/TodoContoller");
      setData(resp.data);
    };
    fetchData();
  }, []);

  const onSubmit = async (data) => {
    const resp = await axios.post(
      API_URL + "/api/TodoContoller/add",
      {
        todo: data.todo,
      }
    );
    console.log(resp.data);
    setData(resp.data);
  };

  const onUpdate = async (data) => {
    const resp = await axios.post(
      API_URL + "/api/TodoContoller/update",
      {
        id: data.id,
        isDone: data.isDone,
      }
    );

    setData(resp.data);
  };

  const onRemove = async (data) => {
    const resp = await axios.delete(
      API_URL + "/api/TodoContoller/remove",
      { params: { id: data.id } }
    );
    console.log(resp.data);
    setData(resp.data);
  };

  return (
    <Container maxWidth="md">
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Typography variant="h5">ToDo App (image version {IMAGE_VERSION})</Typography>
        </Grid>
        <Grid item xs={12}>
          <TodoForm onAdd={onSubmit} />
        </Grid>
        <Grid item xs={12}>
          <Typography variant="h5">My To Do List</Typography>
        </Grid>
        <Grid item xs={12}>
          <TodoTable todos={data} onUpdate={onUpdate} onRemove={onRemove} />
        </Grid>
      </Grid>
    </Container>
  );
};

export default App;
