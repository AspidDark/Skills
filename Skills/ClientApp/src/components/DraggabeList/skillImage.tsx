import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import ButtonBase from '@mui/material/ButtonBase';
import Typography from '@mui/material/Typography';
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
      border: 0,
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

const Image = styled('span')(({ theme }) => ({
  position: 'absolute',
  left: 0,
  right: 0,
  top: 0,
  bottom: 0,
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  color: theme.palette.common.white,
}));

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

export default function ButtonBases(skillLevel: SkillLevel, onImageButtonClick : (id:string, level: number) => void) {
  const completeUrl = `${templateUrl}${skillLevel.path}`

  const showSkillLevel = (value:number):string => {
    switch (value){
      case 0 : {
        return 'Junior'
      }
      case 1 : {
        return 'Middle'
      }
      case 2 : {
        return 'Senior'
      }
      default : {
        return ''
      }
    }
  }

  return (
    <Box sx={{ width: 100 }}>
        <ImageButton
          focusRipple
          key={skillLevel.id}
          style={{
            width: '100%',
          }}
          onClick={() => onImageButtonClick(skillLevel.skillId, skillLevel.level)}
        >
          <ImageSrc style={{ backgroundImage: `url(${completeUrl})` }} />
          <ImageBackdrop className="MuiImageBackdrop-root" />
          <Image>
            <Typography
              component="span"
              variant="subtitle1"
            >
              {showSkillLevel(skillLevel.level)}
            </Typography>
          </Image>
        </ImageButton>
    </Box>
  );
}