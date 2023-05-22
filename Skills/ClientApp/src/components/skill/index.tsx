import React, { useState, useEffect } from 'react'
import { useTheme } from '@emotion/react'
import makeStyles from '@material-ui/core/styles/makeStyles'
import { DropResult } from 'react-beautiful-dnd'
import DraggableList from '../DraggabeList/DraggableList'
import { reorder } from '../DraggabeList/helpers'
import './styles.css'
import { v4 } from 'uuid'
import _ from 'lodash'
import SkillModel from '../../models/SkillModel'
import TextField from '@mui/material/TextField';
import TableCell from '@mui/material/TableCell'
import TableRow from '@mui/material/TableRow'
import dayjs, { Dayjs } from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import Table from '@mui/material/Table'

import ImageUpload from "./ImageUpload"

//https://codesandbox.io/s/vj1q68zm25?file=/src/ImageUpload.js

const useStyles = makeStyles({
  flexPaper: {
    flex: 1,
    margin: 16,
    minWidth: 350
  },
  root: {
    display: 'flex',
    flexWrap: 'wrap'
  }
})

export default function SkillList () {
  const theme: any = useTheme()
  const classes = useStyles()
  const [name, setName] = useState('')
  const [startDate, setStartDate] = React.useState<Dayjs | null>(dayjs('2022-04-17'));
  const [skillPointCount, setskillPointCount] = useState(0)


  const [subHeadline, setSubHeadline] = useState('')
  const [id, setId] = useState('')
  const [isActive, setIsActive] = useState(false)
  const [items, setItems] = useState<SkillModel[]>([{
    id: v4(),
    createDate: new Date(),
    editDate: new Date(),
    ownerId:'ownerId',
    priority:1,
    skillName:'skillName',
    level:1,
    skillPictureId: 'skillPictureId',
    isMain:1,
    image: undefined
  }])

  const setOrderedItems = (newItems: SkillModel[]) => {
    const orderedItems = _.sortBy(newItems, 'priority')
    setItems(orderedItems)
  }
 

  const setItem = (value: string, id: string) => {
    const newItems = items.map(x => {
      if (x.id === id) {
        x.skillName = value
      }
      return x
    })
    setOrderedItems(newItems)
  }

  const deleteItem = (id: string) => {
    const newItems = items.filter(x => {
      if (x.id !== id) {
        return x
      }
    })
    for (let i = 0; i < newItems.length; i++) {
      newItems[i].priority = i
    }
    setOrderedItems(newItems)
  }

  const addItem = () => {
    const newitems = [...items, {
        id: v4(),
        createDate: new Date(),
        editDate: new Date(),
        ownerId:'ownerId',
        skillName:'skillName',
        level:1,
        skillPictureId: 'skillPictureId',
        isMain:1,
        image: undefined,
        priority: items.length
    }]
    setOrderedItems(newitems)
  }

  const onDragEnd = ({ destination, source }: DropResult) => {
    // dropped outside the list
    if (!destination) return
    const newItems = reorder(items, source.index, destination.index)
    for (let i = 0; i < newItems.length; i++) {
      newItems[i].priority = i
    }
    setOrderedItems(newItems)
  }

  const validateInput = async (skillId: number | '', id: string) => {

  }

  const setStartDateValue =(value: Dayjs | null) => {
    setStartDate(value)
    if(!value){
      return
    }
    const now = new Date();
    const nowYear=now.getFullYear();
    const startYear = value.year()
    const skillPointCount = nowYear + 1 - startYear
    setskillPointCount(skillPointCount)
  }


  const galleryImageList = [
    "https://raw.githubusercontent.com/dxyang/StyleTransfer/master/style_imgs/mosaic.jpg",
    "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/1280px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg",
    "https://raw.githubusercontent.com/ShafeenTejani/fast-style-transfer/master/examples/dora-maar-picasso.jpg",
    "https://pbs.twimg.com/profile_images/925531519858257920/IyYLHp-u_400x400.jpg",
    "https://raw.githubusercontent.com/ShafeenTejani/fast-style-transfer/master/examples/dog.jpg",
    "http://r.ddmcdn.com/s_f/o_1/cx_462/cy_245/cw_1349/ch_1349/w_720/APL/uploads/2015/06/caturday-shutterstock_149320799.jpg"
  ];

  return (<>
  <h4>{name}</h4>
  <ImageUpload cardName="Input Image" imageGallery={galleryImageList} />
  <TextField id="standard-basic" label="Name" variant="standard" value={name} onChange={e=>setName(e.target.value)}/>
    <Table>
      <TableRow>
        <TableCell align="left">
        <LocalizationProvider dateAdapter={AdapterDayjs}>
          <DemoContainer components={['DatePicker', 'DatePicker']}>
            <DatePicker
              label="Controlled picker"
              value={startDate}
              onChange={(newValue) => setStartDateValue(newValue)}
            />
          </DemoContainer>
        </LocalizationProvider>
        </TableCell>
        <TableCell align="right">
        {skillPointCount===0 ? '':skillPointCount}
        </TableCell>
      </TableRow>
    </Table>
  
        <DraggableList items={items} onDragEnd={onDragEnd} setValue={setItem} deleteValue={deleteItem} addItem={addItem} validateInput={validateInput}/>
  </>)
}
