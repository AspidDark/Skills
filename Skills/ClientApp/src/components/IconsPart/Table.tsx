import React, { useState } from 'react';
import { makeStyles } from '@mui/styles';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from '@mui/material';
import Image from './Image';

const useStyles = makeStyles({
  table: {
    minWidth: 650,
  },
});

type Row = {
  id: number;
  images: string[];
};

type TableProps = {
  rows: Row[];
};

const CustomTable = ({ rows }: TableProps) => {
  const classes = useStyles();
  const [selectedImages, setSelectedImages] = useState<number[]>([]);

  const handleImageClick = (rowId: number, imageIndex: number) => {
    setSelectedImages((prevSelectedImages) => {
      const index = prevSelectedImages.findIndex(
        (selectedImage) => selectedImage === rowId * 5 + imageIndex
      );
      if (index !== -1) {
        return [...prevSelectedImages.slice(0, index), ...prevSelectedImages.slice(index + 1)];
      } else {
        return [...prevSelectedImages, rowId * 5 + imageIndex];
      }
    });
  };

  return (
    <TableContainer>
      <Table className={classes.table}>
        <TableHead>
          <TableRow>
            <TableCell>Row</TableCell>
            {[...Array(5)].map((_, index) => (
              <TableCell key={index} align="center">
                Image {index + 1}
              </TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow key={row.id}>
              <TableCell component="th" scope="row">
                {row.id + 1}
              </TableCell>
              {row.images.map((image, index) => (
                <TableCell key={index} align="center">
                  <Image
                    src={image}
                    selected={selectedImages.includes(row.id * 5 + index)}
                    onClick={() => handleImageClick(row.id,index)}
                    width={100}
                    height={100}
                  />
                </TableCell>
              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    );
};

export default CustomTable;