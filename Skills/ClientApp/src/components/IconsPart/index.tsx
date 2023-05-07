
import React, { useState } from "react";
import CustomTable from './Table';

const pictures = [
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
  { src: 'https://via.placeholder.com/150', selected: false },
];

const rows = [
  {
    id: 1,
    images: [
      'https://picsum.photos/seed/1/100/100',
      'https://picsum.photos/seed/2/100/100',
      'https://picsum.photos/seed/3/100/100',
      'https://picsum.photos/seed/4/100/100',
      'https://picsum.photos/seed/5/100/100',
    ],
  },
  {
    id: 2,
    images: [
      'https://picsum.photos/seed/6/100/100',
      'https://picsum.photos/seed/7/100/100',
      'https://picsum.photos/seed/8/100/100',
      'https://picsum.photos/seed/9/100/100',
      'https://picsum.photos/seed/10/100/100',
    ],
  },
  {
    id: 3,
    images: [
      'https://picsum.photos/seed/11/100/100',
      'https://picsum.photos/seed/12/100/100',
      'https://picsum.photos/seed/13/100/100',
      'https://picsum.photos/seed/14/100/100',
      'https://picsum.photos/seed/15/100/100',
    ],
  },
];

function IconsPart() {
  return (
    <div className="IconsPart">
      <CustomTable rows={rows} />
    </div>
  );
}

export default IconsPart;