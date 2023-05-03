import { Component } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

import BasicButtons from '../components/InputPart/index'
import SimpleBadge from '../components/IconsPart/index'

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <>
          <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableBody>
              <TableRow>
                <TableCell>
                  <BasicButtons/></TableCell>
                <TableCell align="right">
                  <SimpleBadge/>
                </TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
      </>
    );
  }
}
