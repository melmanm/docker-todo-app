import React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Checkbox from "@mui/material/Checkbox";
import DeleteIcon from "@mui/icons-material/Delete";
import IconButton from "@mui/material/IconButton";

const TodoTable = (props) => {
  return (
    <TableContainer component={Paper}>
      <Table aria-label="simple table">
        <colgroup>
          <col style={{ width: "80%" }} />
          <col style={{ width: "10%" }} />
          <col style={{ width: "10%" }} />
        </colgroup>
        <TableHead>
          <TableRow>
            <TableCell style={{ fontWeight: "bold" }} align="left">
              Todo
            </TableCell>
            <TableCell style={{ fontWeight: "bold" }} align="left">
              Status
            </TableCell>
            <TableCell style={{ fontWeight: "bold" }} align="left"></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.todos.map((row) => (
            <TableRow
              key={row.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.todo}
              </TableCell>
              <TableCell>
                <Checkbox
                  onChange={(e) =>
                    props.onUpdate({ id: row.id, isDone: e.target.checked })
                  }
                  checked={row.isDone}
                />
              </TableCell>
              <TableCell>
                <IconButton onClick={(e) => props.onRemove({ id: row.id })}>
                  <DeleteIcon cursor="hand" />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default TodoTable;
