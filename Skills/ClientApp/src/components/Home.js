import { Component } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

import { InputData} from '../components/InputPart/index'
import SimpleBadge from './IconsPart/index'

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
                                <InputData /></TableCell>
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
