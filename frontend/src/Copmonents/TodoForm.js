import { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@material-ui/core/Grid";
import TextField from '@mui/material/TextField';

const TodoForm = (props) => {
  const [todo, setTodo] = useState("");

  const onClick = (data) => {
    props.onAdd(data);
    setTodo("");
  };

  return (
    <div>
      <form onSubmit={(e) => {
                e.preventDefault();
                onClick({ todo: todo });
              }}>
        <Grid container spacing={3} alignItems="center">
          <Grid item xs={9}>
            <TextField
              label="Type what you need to do"
              value={todo}
              onChange={(e) => setTodo(e.target.value)}
              variant="outlined"
              fullWidth
            />
          </Grid>
          <Grid item xs={3}>
            <Button
              variant="contained"
              fullWidth
              type="submit"
            >
              Add
            </Button>
          </Grid>
        </Grid>
      </form>
    </div>
  );
};

export default TodoForm;
