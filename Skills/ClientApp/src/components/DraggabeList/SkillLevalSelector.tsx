import React, { useState, useEffect } from 'react'
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import IconButton from "@material-ui/core/IconButton";
import KeyboardArrowDownIcon from '@material-ui/icons/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@material-ui/icons/KeyboardArrowUp';

export interface SkillLevelProps {
  currentSkillLevel:number
  changeSkillValue(isUp:boolean):void
}

export const SkillLevelSelector = ({currentSkillLevel, changeSkillValue}:SkillLevelProps) => {

  const changeLevel =(isUp:boolean) =>{
    console.log("click")
    if(isUp && isValidUp()) {
      changeSkillValue(true)
      return
    }
    if(!isUp && isValidDown()) {
      changeSkillValue(false)
      return
    }
  }

  const isValidUp = ():boolean=>(currentSkillLevel+1 <= 3)

  const isValidDown = ():boolean =>(currentSkillLevel-1 >= 1)

    
    const Item = styled(Paper)(({ theme }) => ({
        ...theme.typography.body2,
        padding: theme.spacing(1),
        textAlign: 'center',
        color: theme.palette.text.secondary,
      }));

      return (
        <Box sx={{ flexGrow: 1 }}>
          <Grid container spacing={2}>
            <Grid item xs={6}>
              <h5>{currentSkillLevel}</h5>
            </Grid>
                <Grid item xs={6}>
                <Grid container spacing={1} >
                    <Grid item xs={12}>
                      {isValidUp() && <IconButton onClick={_ => changeLevel(true)}>
                        <KeyboardArrowUpIcon />
                      </IconButton>}
                    </Grid>
                    <Grid item xs={12}>
                      {isValidDown() &&  <IconButton onClick={_ => changeLevel(false)}>
                        <KeyboardArrowDownIcon />
                      </IconButton>}
                    </Grid>
                </Grid>
                </Grid>
          </Grid>
        </Box>
      );
  }
  
  