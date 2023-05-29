import React, { useState, useEffect } from 'react'
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import { Button, TextField } from '@mui/material';

export const SkillLevelSelector = () => {
  
    const [skillLevel, setSkillLevet] = useState<number>(1)
    
    const Item = styled(Paper)(({ theme }) => ({
        backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
        ...theme.typography.body2,
        padding: theme.spacing(1),
        textAlign: 'center',
        color: theme.palette.text.secondary,
      }));

      return (
        <Box sx={{ flexGrow: 1 }}>
          <Grid container spacing={2}>
            <Grid item xs={6}>
              <TextField>sdlkfj</TextField>
            </Grid>
                <Grid item xs={6}>
                <Grid container spacing={1} >
                    <Grid item xs={12}>
                        <Button>Button Up</Button>
                    </Grid>
                    <Grid item xs={12}>
                    <Button>Button Down</Button>
                    </Grid>
                </Grid>
                </Grid>
          </Grid>
        </Box>
      );
  }
  
  