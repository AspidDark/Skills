import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import ButtonBase from '@mui/material/ButtonBase';

import Grid from '@mui/material/Grid';
import SkillLevel from '../../models/SkillLevel';

const templateUrl = 'images/'

const ImageButton = styled(ButtonBase)(({ theme }) => ({
  position: 'relative',
  height: 100,
  [theme.breakpoints.down('sm')]: {
    width: '100% !important', // Overrides inline-style
    height: 100,
  },
  '&:hover, &.Mui-focusVisible': {
    zIndex: 1,
    '& .MuiImageBackdrop-root': {
      opacity: 0.15,
    },
    '& .MuiImageMarked-root': {
      opacity: 0,
    },
    '& .MuiTypography-root': {
      border: '4px solid currentColor',
    },
  },
}));

const ImageSrc = styled('span')({
  position: 'absolute',
  left: 0,
  right: 0,
  top: 0,
  bottom: 0,
  backgroundSize: 'cover',
  backgroundPosition: 'center 40%',
});

const ImageBackdrop = styled('span')(({ theme }) => ({
  position: 'absolute',
  left: 0,
  right: 0,
  top: 0,
  bottom: 0,
  backgroundColor: theme.palette.common.black,
  opacity: 0.4,
  transition: theme.transitions.create('opacity'),
}));

export const modalSelector = (skillLevels:SkillLevel[], onSelectedImageClick:(skill:SkillLevel)=>void) => {
  return (
          <Box sx={{ width: '100%' }}>
          <Grid container spacing={10}>
  {skillLevels.map(item => (
    <Grid item xs={2} key={item.id} width={100} height={100} >  
       <Box sx={{ width: 100 }}>
                 <ImageButton
                   focusRipple
                   key={item.id}
                   style={{
                     width: '100%',
                   }}
                   onClick={() => onSelectedImageClick(item)}
                 >
                   <ImageSrc style={{ backgroundImage: `url(${templateUrl}${item.path})` }} />
                   <ImageBackdrop className="MuiImageBackdrop-root" />
                 </ImageButton>
             </Box>
    </Grid>
  ))}
</Grid>
    </Box>
        );
    }
