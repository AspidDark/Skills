import { FormControl, IconButton, InputLabel, MenuItem, Select, SelectChangeEvent, TableCell, TableContainer, TableRow, TextField } from '@mui/material';
import * as React from 'react';
import { useState } from 'react';
import { useParams } from 'react-router-dom';
import SkillModel from '../../models/SkillModel';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import RemoveCircleOutlineIcon from '@mui/icons-material/RemoveCircleOutline';

export interface SkillDataProps{
    skill: SkillModel
    onSkillValueChanged: () => void
    isLast: boolean
}

export default function SkillData(skill?: SkillDataProps) {

    const [skillName, setSkillName] = useState('')

    const [age, setAge] = React.useState<string | number>('');
    const [open, setOpen] = React.useState(false);
  
    const handleChange = (event: SelectChangeEvent<typeof age>) => {
      setAge(event.target.value);
    };
  
    const handleClose = () => {
      setOpen(false);
    };
  
    const handleOpen = () => {
      setOpen(true);
    };

    return (
       <>
       <TableRow>
            <TableCell>Picture here</TableCell>
            <TableCell align="right"><TextField value={skillName} onChange={(e: any)=> setSkillName(e.target.value)} id="standard-basic" label="Standard" variant="standard" /></TableCell>
            <TableCell align="right">  
                <FormControl sx={{ m: 1, minWidth: 120 }}>
                <InputLabel id="demo-controlled-open-select-label">Age</InputLabel>
                <Select
                labelId="demo-controlled-open-select-label"
                id="demo-controlled-open-select"
                open={open}
                onClose={handleClose}
                onOpen={handleOpen}
                value={age}
                label="Age"
                onChange={handleChange}
                >
                <MenuItem value="">
                    <em>None</em>
                </MenuItem>
                <MenuItem value={10}>Ten</MenuItem>
                <MenuItem value={20}>Twenty</MenuItem>
                <MenuItem value={30}>Thirty</MenuItem>
                </Select>
            </FormControl>
            </TableCell>
            <TableCell align="right">
                <IconButton aria-label="delete">
                <AddCircleOutlineIcon /> 
                </IconButton>
            </TableCell>
            <TableCell align="right">
                <IconButton aria-label="delete">
                <RemoveCircleOutlineIcon />
                </IconButton>
                </TableCell>
     </TableRow>
       </>
  )

}