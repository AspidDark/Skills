import React, { useState, useEffect } from 'react'
import Box from '@mui/material/Box';
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


      return (
        <Box sx={{ maxHeight: 90, maxWidth: 50, minWidth:50 }}>
          <Grid container spacing={2}>
                <Grid item xs={6}>
                <Grid container spacing={1} >
                    <Grid item xs={12}>
                      <Box sx={{width:30, minWidth:30, height:40, minHeight:40 }}>
                      {isValidUp() && <IconButton onClick={_ => changeLevel(true)}>
                        <KeyboardArrowUpIcon />
                      </IconButton>}
                      </Box>
                    </Grid>
                    <Grid item xs={12}>
                    <Box sx={{width:30, height:40  }}>
                      {isValidDown() &&  <IconButton onClick={_ => changeLevel(false)}>
                        <KeyboardArrowDownIcon />
                      </IconButton>}
                      </Box>
                    </Grid>
                </Grid>
                </Grid>
          </Grid>
        </Box>
      );
  }
  
  