import { makeStyles } from '@mui/styles';

const useStyles = makeStyles({
  imageContainer: {
    position: 'relative',
    display: 'inline-block',
    cursor: 'pointer',
  },
  image: {
    width: '100%',
    height: '100%',
    objectFit: 'cover',
  },
  mask: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
  },
});

type ImageProps = {
  src: string;
  selected: boolean;
  onClick: () => void;
  width: number;
  height: number;
};

const Image = ({ src, selected, onClick, width, height }: ImageProps) => {
  const classes = useStyles();

  return (
    <div
      className={classes.imageContainer}
      style={{ width: `${width}px`, height: `${height}px` }}
      onClick={onClick}
    >
      <img src={src} alt="image" className={classes.image} />
      {selected && <div className={classes.mask} />}
    </div>
  );
};

export default Image;